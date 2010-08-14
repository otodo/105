namespace _105bank
{
    partial class Hyakugo
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.inputFileOpen = new System.Windows.Forms.Button();
            this.saveFileOpen = new System.Windows.Forms.Button();
            this.Source = new System.Windows.Forms.Label();
            this.OutFile = new System.Windows.Forms.Label();
            this.Convert = new System.Windows.Forms.Button();
            this.sourceFile = new System.Windows.Forms.TextBox();
            this.convertFile = new System.Windows.Forms.TextBox();
            this.closeButtoｎ = new System.Windows.Forms.Button();
            this.selectFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // inputFileOpen
            // 
            this.inputFileOpen.Location = new System.Drawing.Point(380, 56);
            this.inputFileOpen.Name = "inputFileOpen";
            this.inputFileOpen.Size = new System.Drawing.Size(75, 23);
            this.inputFileOpen.TabIndex = 0;
            this.inputFileOpen.Text = "開く";
            this.inputFileOpen.UseVisualStyleBackColor = true;
            this.inputFileOpen.Click += new System.EventHandler(this.inputFileOpen_Click);
            // 
            // saveFileOpen
            // 
            this.saveFileOpen.Location = new System.Drawing.Point(380, 140);
            this.saveFileOpen.Name = "saveFileOpen";
            this.saveFileOpen.Size = new System.Drawing.Size(75, 23);
            this.saveFileOpen.TabIndex = 1;
            this.saveFileOpen.Text = "保存";
            this.saveFileOpen.UseVisualStyleBackColor = true;
            this.saveFileOpen.Click += new System.EventHandler(this.saveFileOpen_Click);
            // 
            // Source
            // 
            this.Source.AutoSize = true;
            this.Source.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Source.Location = new System.Drawing.Point(30, 25);
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(69, 19);
            this.Source.TabIndex = 2;
            this.Source.Text = "変換元";
            // 
            // OutFile
            // 
            this.OutFile.AutoSize = true;
            this.OutFile.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OutFile.Location = new System.Drawing.Point(34, 105);
            this.OutFile.Name = "OutFile";
            this.OutFile.Size = new System.Drawing.Size(69, 19);
            this.OutFile.TabIndex = 3;
            this.OutFile.Text = "変換後";
            // 
            // Convert
            // 
            this.Convert.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Convert.Location = new System.Drawing.Point(167, 201);
            this.Convert.Name = "Convert";
            this.Convert.Size = new System.Drawing.Size(113, 53);
            this.Convert.TabIndex = 4;
            this.Convert.Text = "変換";
            this.Convert.UseVisualStyleBackColor = true;
            this.Convert.Click += new System.EventHandler(this.Convert_Click);
            // 
            // sourceFile
            // 
            this.sourceFile.Location = new System.Drawing.Point(34, 60);
            this.sourceFile.Name = "sourceFile";
            this.sourceFile.Size = new System.Drawing.Size(313, 19);
            this.sourceFile.TabIndex = 5;
            // 
            // convertFile
            // 
            this.convertFile.Location = new System.Drawing.Point(34, 140);
            this.convertFile.Name = "convertFile";
            this.convertFile.Size = new System.Drawing.Size(313, 19);
            this.convertFile.TabIndex = 6;
            // 
            // closeButtoｎ
            // 
            this.closeButtoｎ.Location = new System.Drawing.Point(380, 219);
            this.closeButtoｎ.Name = "closeButtoｎ";
            this.closeButtoｎ.Size = new System.Drawing.Size(75, 23);
            this.closeButtoｎ.TabIndex = 7;
            this.closeButtoｎ.Text = "終了";
            this.closeButtoｎ.UseVisualStyleBackColor = true;
            this.closeButtoｎ.Click += new System.EventHandler(this.closeButtoｎ_Click);
            // 
            // selectFile
            // 
            this.selectFile.Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            this.selectFile.InitialDirectory = "D:\\HouseholdAccounts\\明細\\百五銀行";
            this.selectFile.Title = "105Bank Data";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "OFX file(*.ofx)|*.ofx|text file(*.txt)||*.txt||All files(*.*)|*.*";
            this.saveFileDialog1.Title = "105Bank OFX DATA";
            // 
            // Hyakugo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 266);
            this.Controls.Add(this.closeButtoｎ);
            this.Controls.Add(this.convertFile);
            this.Controls.Add(this.sourceFile);
            this.Controls.Add(this.Convert);
            this.Controls.Add(this.OutFile);
            this.Controls.Add(this.Source);
            this.Controls.Add(this.saveFileOpen);
            this.Controls.Add(this.inputFileOpen);
            this.Name = "Hyakugo";
            this.Text = "百五銀行 OFX変換";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button inputFileOpen;
        private System.Windows.Forms.Button saveFileOpen;
        private System.Windows.Forms.Label Source;
        private System.Windows.Forms.Label OutFile;
        private System.Windows.Forms.Button Convert;
        private System.Windows.Forms.TextBox sourceFile;
        private System.Windows.Forms.TextBox convertFile;
        private System.Windows.Forms.Button closeButtoｎ;
        private System.Windows.Forms.OpenFileDialog selectFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

