namespace CompressFolders
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gbxAddFiles = new System.Windows.Forms.GroupBox();
            this.lblFiles = new System.Windows.Forms.Label();
            this.lstFilePaths = new System.Windows.Forms.ListBox();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtAddFile = new System.Windows.Forms.TextBox();
            this.lblAddFile = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbxDestination = new System.Windows.Forms.GroupBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveBrowse = new System.Windows.Forms.Button();
            this.txtSaveTo = new System.Windows.Forms.TextBox();
            this.lblSaveTo = new System.Windows.Forms.Label();
            this.gbxExit = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.gbxAddFiles.SuspendLayout();
            this.gbxDestination.SuspendLayout();
            this.gbxExit.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxAddFiles
            // 
            this.gbxAddFiles.Controls.Add(this.lblFiles);
            this.gbxAddFiles.Controls.Add(this.lstFilePaths);
            this.gbxAddFiles.Controls.Add(this.btnRemoveFile);
            this.gbxAddFiles.Controls.Add(this.btnAddFile);
            this.gbxAddFiles.Controls.Add(this.btnBrowse);
            this.gbxAddFiles.Controls.Add(this.txtAddFile);
            this.gbxAddFiles.Controls.Add(this.lblAddFile);
            this.gbxAddFiles.Location = new System.Drawing.Point(11, 10);
            this.gbxAddFiles.Name = "gbxAddFiles";
            this.gbxAddFiles.Size = new System.Drawing.Size(409, 224);
            this.gbxAddFiles.TabIndex = 0;
            this.gbxAddFiles.TabStop = false;
            this.gbxAddFiles.Text = "Add Files To Folder";
            this.gbxAddFiles.Enter += new System.EventHandler(this.gbxAddFiles_Enter);
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point(23, 52);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(31, 13);
            this.lblFiles.TabIndex = 6;
            this.lblFiles.Text = "Files:";
            // 
            // lstFilePaths
            // 
            this.lstFilePaths.FormattingEnabled = true;
            this.lstFilePaths.Location = new System.Drawing.Point(56, 49);
            this.lstFilePaths.Name = "lstFilePaths";
            this.lstFilePaths.Size = new System.Drawing.Size(254, 160);
            this.lstFilePaths.TabIndex = 5;
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Location = new System.Drawing.Point(316, 80);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFile.TabIndex = 4;
            this.btnRemoveFile.Text = "Remove File";
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(316, 50);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(75, 23);
            this.btnAddFile.TabIndex = 3;
            this.btnAddFile.Text = "Add File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(316, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtAddFile
            // 
            this.txtAddFile.Location = new System.Drawing.Point(56, 22);
            this.txtAddFile.Name = "txtAddFile";
            this.txtAddFile.Size = new System.Drawing.Size(254, 20);
            this.txtAddFile.TabIndex = 1;
            // 
            // lblAddFile
            // 
            this.lblAddFile.AutoSize = true;
            this.lblAddFile.Location = new System.Drawing.Point(6, 25);
            this.lblAddFile.Name = "lblAddFile";
            this.lblAddFile.Size = new System.Drawing.Size(48, 13);
            this.lblAddFile.TabIndex = 0;
            this.lblAddFile.Text = "Add File:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gbxDestination
            // 
            this.gbxDestination.Controls.Add(this.lblUpdate);
            this.gbxDestination.Controls.Add(this.btnSave);
            this.gbxDestination.Controls.Add(this.btnSaveBrowse);
            this.gbxDestination.Controls.Add(this.txtSaveTo);
            this.gbxDestination.Controls.Add(this.lblSaveTo);
            this.gbxDestination.Location = new System.Drawing.Point(13, 240);
            this.gbxDestination.Name = "gbxDestination";
            this.gbxDestination.Size = new System.Drawing.Size(407, 79);
            this.gbxDestination.TabIndex = 1;
            this.gbxDestination.TabStop = false;
            this.gbxDestination.Text = "Save Compressed Folder";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(54, 46);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(134, 13);
            this.lblUpdate.TabIndex = 7;
            this.lblUpdate.Text = "Zipping files, please wait ...";
            this.lblUpdate.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(314, 46);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Zip Now";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveBrowse
            // 
            this.btnSaveBrowse.Location = new System.Drawing.Point(314, 17);
            this.btnSaveBrowse.Name = "btnSaveBrowse";
            this.btnSaveBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnSaveBrowse.TabIndex = 5;
            this.btnSaveBrowse.Text = "Browse...";
            this.btnSaveBrowse.UseVisualStyleBackColor = true;
            this.btnSaveBrowse.Click += new System.EventHandler(this.btnSaveBrowse_Click);
            // 
            // txtSaveTo
            // 
            this.txtSaveTo.Location = new System.Drawing.Point(54, 19);
            this.txtSaveTo.Name = "txtSaveTo";
            this.txtSaveTo.Size = new System.Drawing.Size(254, 20);
            this.txtSaveTo.TabIndex = 4;
            // 
            // lblSaveTo
            // 
            this.lblSaveTo.AutoSize = true;
            this.lblSaveTo.Location = new System.Drawing.Point(2, 22);
            this.lblSaveTo.Name = "lblSaveTo";
            this.lblSaveTo.Size = new System.Drawing.Size(51, 13);
            this.lblSaveTo.TabIndex = 3;
            this.lblSaveTo.Text = "Save To:";
            // 
            // gbxExit
            // 
            this.gbxExit.Controls.Add(this.btnExit);
            this.gbxExit.Location = new System.Drawing.Point(13, 323);
            this.gbxExit.Name = "gbxExit";
            this.gbxExit.Size = new System.Drawing.Size(407, 54);
            this.gbxExit.TabIndex = 2;
            this.gbxExit.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(314, 19);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(565, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 387);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbxExit);
            this.Controls.Add(this.gbxDestination);
            this.Controls.Add(this.gbxAddFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compress Folders";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbxAddFiles.ResumeLayout(false);
            this.gbxAddFiles.PerformLayout();
            this.gbxDestination.ResumeLayout(false);
            this.gbxDestination.PerformLayout();
            this.gbxExit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAddFiles;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtAddFile;
        private System.Windows.Forms.Label lblAddFile;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.ListBox lstFilePaths;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox gbxDestination;
        private System.Windows.Forms.GroupBox gbxExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveBrowse;
        private System.Windows.Forms.TextBox txtSaveTo;
        private System.Windows.Forms.Label lblSaveTo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Button button1;
    }
}

