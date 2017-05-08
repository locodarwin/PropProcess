namespace PropProcess
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lisStatus = new System.Windows.Forms.ListBox();
            this.butBrowse = new System.Windows.Forms.Button();
            this.texDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butProcess = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.texCitnum = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // lisStatus
            // 
            this.lisStatus.FormattingEnabled = true;
            this.lisStatus.Location = new System.Drawing.Point(6, 87);
            this.lisStatus.Name = "lisStatus";
            this.lisStatus.Size = new System.Drawing.Size(602, 251);
            this.lisStatus.TabIndex = 0;
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(533, 8);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(75, 23);
            this.butBrowse.TabIndex = 1;
            this.butBrowse.Text = "Browse";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.button1_Click);
            // 
            // texDir
            // 
            this.texDir.Location = new System.Drawing.Point(64, 10);
            this.texDir.Name = "texDir";
            this.texDir.Size = new System.Drawing.Size(463, 20);
            this.texDir.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Directory:";
            // 
            // butProcess
            // 
            this.butProcess.Location = new System.Drawing.Point(12, 36);
            this.butProcess.Name = "butProcess";
            this.butProcess.Size = new System.Drawing.Size(94, 43);
            this.butProcess.TabIndex = 4;
            this.butProcess.Text = "Process";
            this.butProcess.UseVisualStyleBackColor = true;
            this.butProcess.Click += new System.EventHandler(this.butProcess_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Citnum to Search For:";
            // 
            // texCitnum
            // 
            this.texCitnum.Location = new System.Drawing.Point(240, 48);
            this.texCitnum.Name = "texCitnum";
            this.texCitnum.Size = new System.Drawing.Size(103, 20);
            this.texCitnum.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 345);
            this.Controls.Add(this.texCitnum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butProcess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.texDir);
            this.Controls.Add(this.butBrowse);
            this.Controls.Add(this.lisStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propdump Processor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lisStatus;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.TextBox texDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox texCitnum;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

