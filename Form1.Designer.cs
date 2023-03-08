namespace RoyalDecrypt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblInfo = new Label();
            txtPrivateKey = new TextBox();
            lblPrivateKey = new Label();
            lblTitle = new Label();
            lblFileBrowse = new Label();
            txtFilePath = new TextBox();
            btnChooseFile = new Button();
            btnStart = new Button();
            openFileDialog1 = new OpenFileDialog();
            lblStartInfo = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            btnChooseFolder = new Button();
            chkSubDir = new CheckBox();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(17, 83);
            lblInfo.Margin = new Padding(4, 0, 4, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(890, 63);
            lblInfo.TabIndex = 0;
            lblInfo.Text = resources.GetString("lblInfo.Text");
            lblInfo.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtPrivateKey
            // 
            txtPrivateKey.AcceptsReturn = true;
            txtPrivateKey.AcceptsTab = true;
            txtPrivateKey.Location = new Point(17, 177);
            txtPrivateKey.Margin = new Padding(4, 5, 4, 5);
            txtPrivateKey.Multiline = true;
            txtPrivateKey.Name = "txtPrivateKey";
            txtPrivateKey.ScrollBars = ScrollBars.Vertical;
            txtPrivateKey.Size = new Size(888, 262);
            txtPrivateKey.TabIndex = 1;
            // 
            // lblPrivateKey
            // 
            lblPrivateKey.AutoSize = true;
            lblPrivateKey.Cursor = Cursors.IBeam;
            lblPrivateKey.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrivateKey.Location = new Point(17, 147);
            lblPrivateKey.Margin = new Padding(4, 0, 4, 0);
            lblPrivateKey.Name = "lblPrivateKey";
            lblPrivateKey.Size = new Size(149, 25);
            lblPrivateKey.TabIndex = 2;
            lblPrivateKey.Text = "RSA Private Key";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(17, 15);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(890, 68);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "RoyalDecryptor";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblFileBrowse
            // 
            lblFileBrowse.AutoSize = true;
            lblFileBrowse.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblFileBrowse.Location = new Point(17, 447);
            lblFileBrowse.Margin = new Padding(4, 0, 4, 0);
            lblFileBrowse.Name = "lblFileBrowse";
            lblFileBrowse.Size = new Size(108, 25);
            lblFileBrowse.TabIndex = 4;
            lblFileBrowse.Text = "File or Path";
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(133, 449);
            txtFilePath.Margin = new Padding(4, 5, 4, 5);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(772, 31);
            txtFilePath.TabIndex = 5;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Location = new Point(343, 488);
            btnChooseFile.Margin = new Padding(4, 5, 4, 5);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(169, 34);
            btnChooseFile.TabIndex = 6;
            btnChooseFile.Text = "Choose File";
            btnChooseFile.UseVisualStyleBackColor = true;
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(700, 535);
            btnStart.Margin = new Padding(4, 5, 4, 5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(207, 67);
            btnStart.TabIndex = 7;
            btnStart.Text = "Start Decrypting";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Royal File|*.royal_w";
            // 
            // lblStartInfo
            // 
            lblStartInfo.Location = new Point(17, 535);
            lblStartInfo.Margin = new Padding(4, 0, 4, 0);
            lblStartInfo.Name = "lblStartInfo";
            lblStartInfo.Size = new Size(674, 67);
            lblStartInfo.TabIndex = 8;
            lblStartInfo.Text = "This will place the file next to the royal_w file. Once you have confirmed everything look good you can delete the royal_w file.\r\n";
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // btnChooseFolder
            // 
            btnChooseFolder.Location = new Point(519, 488);
            btnChooseFolder.Name = "btnChooseFolder";
            btnChooseFolder.Size = new Size(169, 34);
            btnChooseFolder.TabIndex = 10;
            btnChooseFolder.Text = "Choose Folder";
            btnChooseFolder.UseVisualStyleBackColor = true;
            btnChooseFolder.Click += btnChooseFolder_Click;
            // 
            // chkSubDir
            // 
            chkSubDir.AutoSize = true;
            chkSubDir.Location = new Point(696, 492);
            chkSubDir.Name = "chkSubDir";
            chkSubDir.Size = new Size(211, 29);
            chkSubDir.TabIndex = 11;
            chkSubDir.Text = "Include subdirectories";
            chkSubDir.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(17, 607);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(890, 51);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Waiting...";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 667);
            Controls.Add(lblStatus);
            Controls.Add(chkSubDir);
            Controls.Add(btnChooseFolder);
            Controls.Add(lblStartInfo);
            Controls.Add(btnStart);
            Controls.Add(btnChooseFile);
            Controls.Add(txtFilePath);
            Controls.Add(lblFileBrowse);
            Controls.Add(lblTitle);
            Controls.Add(lblPrivateKey);
            Controls.Add(txtPrivateKey);
            Controls.Add(lblInfo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MaximumSize = new Size(946, 723);
            MinimumSize = new Size(946, 723);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "";
            Text = "RoyalDecryptor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInfo;
        private TextBox txtPrivateKey;
        private Label lblPrivateKey;
        private Label lblTitle;
        private Label lblFileBrowse;
        private TextBox txtFilePath;
        private Button btnChooseFile;
        private Button btnStart;
        private OpenFileDialog openFileDialog1;
        private Label lblStartInfo;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button btnChooseFolder;
        private CheckBox chkSubDir;
        private Label lblStatus;
    }
}