using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace _105bank
{
    public partial class Hyakugo : Form
    {
        public Hyakugo()
        {
            InitializeComponent();
        }

        private void inputFileOpen_Click(object sender, EventArgs e)
        {
            if (selectFile.ShowDialog()== DialogResult.OK)
            {
                sourceFile.Text = selectFile.FileName;
            }

            if (convertFile.Text == "")
            {
                convertFile.Text = Regex.Replace(sourceFile.Text,@"(.+)(\.\w+$)","$1.ofx");
            }
        }

        private void saveFileOpen_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                convertFile.Text = saveFileDialog1.FileName;
            }
        }

        private void closeButtoｎ_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader chkinput = new StreamReader(sourceFile.Text);
                chkinput.Close();
                CSV2OFX105 csvdata = new CSV2OFX105();
                csvdata.getdata(sourceFile.Text);
                csvdata.outdata(convertFile.Text);
                MessageBox.Show(convertFile.Text + " に保存しました。", "実行完了");
            }
            catch (FileNotFoundException er)
            {
                MessageBox.Show("ファイル: " + er.FileName + "が見つかりません","エラー");
            }
            catch (ArgumentException er)
            {
                MessageBox.Show(er.Message, "エラー");
            }
        }

    }
}
