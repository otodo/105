using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace _105bank
{
    class CSV2OFX105
    {
        private string inputfile, outputfile;
        private string startdate,enddate;
        private int count = 1;
        private changename chg;

        struct journalBook
        {
            public  string  date;
            public  string comment;
            public  int payment;
            public  int post;
            public  string who;
            public  int balance;
            public  int store;
        }

        private journalBook[] amountdata = new journalBook[1];

        public void getdata(string inputfilename)
        {
            inputfile = inputfilename;
            string tablefile = Application.StartupPath + "\\changetable.txt";
            chg = new changename(tablefile);
            StreamReader reader = new StreamReader(inputfile, Encoding.Default);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (!line.StartsWith("\"日付\"")) //先頭行の読み飛ばし
                {
                    line = line.Replace("\r", "").Replace("\n", "");
                    line = Regex.Replace(line, @"\s+", "");
                    line = Regex.Replace(line, @"(\d+)(,)(\d+)(,?)(\d+)", "$1$3$5");
                    line = Regex.Replace(line, "\"", "");
                    line = Regex.Replace(line, @"\\", "");
                    string[] col = line.Split(',');
                    if (count != 1)
                    {
                        amountdata.CopyTo(amountdata = new journalBook[count], 0);
                    }
                    amountdata[count - 1].date = Regex.Replace(col[0], @"/", "");
                    amountdata[count - 1].comment = col[1];
                    if (col[2] != "")
                    {
                        amountdata[count - 1].payment = int.Parse(col[2]);
                        amountdata[count - 1].post = 0;
                    }
                    else
                    {
                        amountdata[count - 1].payment = 0;
                        amountdata[count - 1].post = int.Parse(col[3]);
                    }
                    if (chg.chkdata(col[4]) != "0")
                    {
                        amountdata[count - 1].who = chg.chkdata(col[4]);
                    }
                    else
                    {
                        amountdata[count - 1].who = col[4];
                    }
                    amountdata[count - 1].balance = int.Parse(col[5]);
                    amountdata[count - 1].store = int.Parse(col[6]);

                    count++;
                }
            }
            reader.Close();
            startdate = amountdata[0].date;
            enddate = amountdata[amountdata.Length-1].date;
            //message();
            //MessageBox.Show(gettime());
        }

        private string gettime()
        {
            DateTime dt = DateTime.Now;
            TimeSpan utcOffset = System.TimeZoneInfo.Local.GetUtcOffset(dt);
            string utctime = Regex.Replace(utcOffset.ToString(), ":00", "");
            utctime = Regex.Replace(utctime,@"^0(\d)","$1");
            
            //DTSERVERへの書式整形
            string dtserver = dt.ToString();
            dtserver = Regex.Replace(dtserver, @"[/\s:]", "");
            dtserver = dtserver + "[+" + utctime + ":CET]";
            return (dtserver);
        }

        public void outdata(string outputfilename)
        {
            outputfile = outputfilename;
            printfile();
        }
        public void outdata()
        {
            outputfile = Regex.Replace(inputfile,@"(.+)(\.\w+)$","$1.ofx");
            printfile();
        }

        private void printfile()
        {
            string initialfile = Application.StartupPath + "\\105_initialtext.txt";
            StreamWriter ofxfile = new StreamWriter(new FileStream(outputfile, FileMode.Create));
            StreamReader init = new StreamReader(initialfile, Encoding.Default);
            string line;
            while ((line = init.ReadLine()) != null)
            {
                if (line.StartsWith("<DTSERVER>"))
                {
                    line = line.Replace("\r", "").Replace("\n", "");
                    line = line + gettime();
                }
                ofxfile.WriteLine(line);
            }
            ofxfile.WriteLine("<DTSTART>{0}000000[+9:JST]", amountdata[0].date);
            ofxfile.WriteLine("<DTEND>{0}000000[+9:JST]",amountdata[amountdata.Length-1].date);
            init.Close();
            
            //データの書き出し
            foreach(journalBook eachdata in amountdata)
            {
                ofxfile.WriteLine("<STMTTRN>");
                ofxfile.WriteLine("<TRNTYPE>OTHER");
                ofxfile.WriteLine("<DTPOSTED>{0}000000[+9:JST]", eachdata.date);
                ofxfile.WriteLine("<TRNAMT>{0}",eachdata.post-eachdata.payment);
                ofxfile.WriteLine("<FITID>{0}1",eachdata.date);
                ofxfile.WriteLine("<NAME>{0}", eachdata.comment);
                ofxfile.WriteLine("<MEMO>{0}",eachdata.who);
                ofxfile.WriteLine("</STMTTRN>");
            }

            //OFX終端作業
            ofxfile.WriteLine("</BANKTRANLIST>\n<LEDGERBAL>\n<BALAMT>0");
            ofxfile.WriteLine("<DTASOF>{0}000000[+9:JST]",enddate);
            ofxfile.WriteLine("</LEDGERBAL>\n<AVAILBAL>\n<BALAMT>0");
            ofxfile.WriteLine("<DTASOF>{0}000000[+9:JST]", enddate);
            ofxfile.WriteLine("</AVAILBAL>\n</STMTRS>\n</STMTTRNRS>\n</BANKMSGSRSV1>\n</OFX>");
            ofxfile.Close();
        }


        private void message()
        {
            foreach (journalBook eachitem in amountdata)
            {
                string line = eachitem.date + " " + eachitem.comment + " " + eachitem.payment + " "
                    +eachitem.post + " " + eachitem.who + " " + eachitem.balance + " " + eachitem.store;
                MessageBox.Show(line);
            }
        }
    }


    class changename
    {
        private string tablename;
        private Hashtable changedata = new Hashtable();

        public changename(string source)
        {
            tablename = source;
            getdata();
        }

        private void getdata()
        {
            StreamReader datatable = new StreamReader(tablename, Encoding.Default);
            string line;
            while ((line = datatable.ReadLine()) != null)
            {
                if (!(line.StartsWith("#")))
                {
                    line = line.Replace("\r", "").Replace("\n", "");
                    line = Regex.Replace(line, @"\s+", "");
                    string[] col = line.Split(';');
                    changedata.Add(col[0],col[1]);
                }
            }
            datatable.Close();
        }

        public string chkdata(string keyword)
        {
            if (changedata.ContainsKey(keyword))
            {
                return ((string)changedata[keyword]);
            }
            else
            {
                return ("0");
            }
        }
    }
}
