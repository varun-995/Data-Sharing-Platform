//INSTANT C# NOTE: Formerly VB.NET project-level imports:
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

using System.IO;
using System.Security;
using System.Security.Cryptography;

namespace EncryptFile
{
	public class encmain : System.Windows.Forms.Form
	{

	#region  Windows Form Designer generated code 

		public encmain() : base()
		{

			//This call is required by the Windows Form Designer.
			InitializeComponent();

			//Add any initialization after the InitializeComponent() call

		}

		//Form overrides dispose to clean up the component list.
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.TextBox txtDestinationEncrypt;
		internal System.Windows.Forms.Button btnEncrypt;
		internal System.Windows.Forms.TextBox txtConPassEncrypt;
		internal System.Windows.Forms.TextBox txtPassEncrypt;
		internal System.Windows.Forms.TextBox txtFileToEncrypt;
		internal System.Windows.Forms.ProgressBar pbStatus;
		internal System.Windows.Forms.TextBox txtDestinationDecrypt;
		internal System.Windows.Forms.Button btnDecrypt;
		internal System.Windows.Forms.TextBox txtConPassDecrypt;
		internal System.Windows.Forms.TextBox txtPassDecrypt;
		internal System.Windows.Forms.TextBox txtFileToDecrypt;
		internal System.Windows.Forms.Button btnChangeEncrypt;
		internal System.Windows.Forms.Button btnBrowseEncrypt;
		internal System.Windows.Forms.Button btnChangeDecrypt;
		internal System.Windows.Forms.Button btnBrowseDecrypt;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog;
		internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btnChangeEncrypt = new System.Windows.Forms.Button();
            this.txtDestinationEncrypt = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtConPassEncrypt = new System.Windows.Forms.TextBox();
            this.txtPassEncrypt = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnBrowseEncrypt = new System.Windows.Forms.Button();
            this.txtFileToEncrypt = new System.Windows.Forms.TextBox();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.btnChangeDecrypt = new System.Windows.Forms.Button();
            this.txtDestinationDecrypt = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtConPassDecrypt = new System.Windows.Forms.TextBox();
            this.txtPassDecrypt = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.btnBrowseDecrypt = new System.Windows.Forms.Button();
            this.txtFileToDecrypt = new System.Windows.Forms.TextBox();
            this.pbStatus = new System.Windows.Forms.ProgressBar();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(384, 144);
            this.TabControl1.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TabPage1.Controls.Add(this.btnChangeEncrypt);
            this.TabPage1.Controls.Add(this.txtDestinationEncrypt);
            this.TabPage1.Controls.Add(this.Label4);
            this.TabPage1.Controls.Add(this.btnEncrypt);
            this.TabPage1.Controls.Add(this.txtConPassEncrypt);
            this.TabPage1.Controls.Add(this.txtPassEncrypt);
            this.TabPage1.Controls.Add(this.Label1);
            this.TabPage1.Controls.Add(this.Label3);
            this.TabPage1.Controls.Add(this.Label2);
            this.TabPage1.Controls.Add(this.btnBrowseEncrypt);
            this.TabPage1.Controls.Add(this.txtFileToEncrypt);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Size = new System.Drawing.Size(376, 118);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Encrypt File";
            // 
            // btnChangeEncrypt
            // 
            this.btnChangeEncrypt.Enabled = false;
            this.btnChangeEncrypt.Location = new System.Drawing.Point(296, 32);
            this.btnChangeEncrypt.Name = "btnChangeEncrypt";
            this.btnChangeEncrypt.Size = new System.Drawing.Size(72, 21);
            this.btnChangeEncrypt.TabIndex = 11;
            this.btnChangeEncrypt.Text = "Change";
            this.btnChangeEncrypt.Click += new System.EventHandler(this.btnChangeEncrypt_Click);
            // 
            // txtDestinationEncrypt
            // 
            this.txtDestinationEncrypt.Location = new System.Drawing.Point(104, 32);
            this.txtDestinationEncrypt.Name = "txtDestinationEncrypt";
            this.txtDestinationEncrypt.ReadOnly = true;
            this.txtDestinationEncrypt.Size = new System.Drawing.Size(184, 20);
            this.txtDestinationEncrypt.TabIndex = 10;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(8, 32);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(88, 16);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "File destination:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Enabled = false;
            this.btnEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(296, 72);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(72, 32);
            this.btnEncrypt.TabIndex = 8;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtConPassEncrypt
            // 
            this.txtConPassEncrypt.Location = new System.Drawing.Point(104, 88);
            this.txtConPassEncrypt.Name = "txtConPassEncrypt";
            this.txtConPassEncrypt.PasswordChar = '*';
            this.txtConPassEncrypt.Size = new System.Drawing.Size(184, 20);
            this.txtConPassEncrypt.TabIndex = 7;
            // 
            // txtPassEncrypt
            // 
            this.txtPassEncrypt.Location = new System.Drawing.Point(104, 64);
            this.txtPassEncrypt.Name = "txtPassEncrypt";
            this.txtPassEncrypt.PasswordChar = '*';
            this.txtPassEncrypt.Size = new System.Drawing.Size(184, 20);
            this.txtPassEncrypt.TabIndex = 6;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(16, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(80, 16);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "File to encrypt:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(-8, 88);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(104, 16);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Confirm password:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(8, 64);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(88, 16);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Type password:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBrowseEncrypt
            // 
            this.btnBrowseEncrypt.Location = new System.Drawing.Point(296, 8);
            this.btnBrowseEncrypt.Name = "btnBrowseEncrypt";
            this.btnBrowseEncrypt.Size = new System.Drawing.Size(72, 21);
            this.btnBrowseEncrypt.TabIndex = 2;
            this.btnBrowseEncrypt.Text = "Browse";
            this.btnBrowseEncrypt.Click += new System.EventHandler(this.btnBrowseEncrypt_Click);
            // 
            // txtFileToEncrypt
            // 
            this.txtFileToEncrypt.Location = new System.Drawing.Point(104, 8);
            this.txtFileToEncrypt.Name = "txtFileToEncrypt";
            this.txtFileToEncrypt.ReadOnly = true;
            this.txtFileToEncrypt.Size = new System.Drawing.Size(184, 20);
            this.txtFileToEncrypt.TabIndex = 1;
            this.txtFileToEncrypt.Text = "Click Browse to load file.";
            // 
            // TabPage2
            // 
            this.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TabPage2.Controls.Add(this.btnChangeDecrypt);
            this.TabPage2.Controls.Add(this.txtDestinationDecrypt);
            this.TabPage2.Controls.Add(this.Label5);
            this.TabPage2.Controls.Add(this.btnDecrypt);
            this.TabPage2.Controls.Add(this.txtConPassDecrypt);
            this.TabPage2.Controls.Add(this.txtPassDecrypt);
            this.TabPage2.Controls.Add(this.Label6);
            this.TabPage2.Controls.Add(this.Label7);
            this.TabPage2.Controls.Add(this.Label8);
            this.TabPage2.Controls.Add(this.btnBrowseDecrypt);
            this.TabPage2.Controls.Add(this.txtFileToDecrypt);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Size = new System.Drawing.Size(376, 118);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Decrypt File";
            // 
            // btnChangeDecrypt
            // 
            this.btnChangeDecrypt.Enabled = false;
            this.btnChangeDecrypt.Location = new System.Drawing.Point(296, 32);
            this.btnChangeDecrypt.Name = "btnChangeDecrypt";
            this.btnChangeDecrypt.Size = new System.Drawing.Size(72, 21);
            this.btnChangeDecrypt.TabIndex = 22;
            this.btnChangeDecrypt.Text = "Change";
            this.btnChangeDecrypt.Click += new System.EventHandler(this.btnChangeDecrypt_Click);
            // 
            // txtDestinationDecrypt
            // 
            this.txtDestinationDecrypt.Location = new System.Drawing.Point(104, 32);
            this.txtDestinationDecrypt.Name = "txtDestinationDecrypt";
            this.txtDestinationDecrypt.ReadOnly = true;
            this.txtDestinationDecrypt.Size = new System.Drawing.Size(184, 20);
            this.txtDestinationDecrypt.TabIndex = 21;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(8, 32);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(88, 16);
            this.Label5.TabIndex = 20;
            this.Label5.Text = "File destination:";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Enabled = false;
            this.btnDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrypt.Location = new System.Drawing.Point(296, 72);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(72, 32);
            this.btnDecrypt.TabIndex = 19;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtConPassDecrypt
            // 
            this.txtConPassDecrypt.Location = new System.Drawing.Point(104, 88);
            this.txtConPassDecrypt.Name = "txtConPassDecrypt";
            this.txtConPassDecrypt.PasswordChar = '*';
            this.txtConPassDecrypt.Size = new System.Drawing.Size(184, 20);
            this.txtConPassDecrypt.TabIndex = 18;
            // 
            // txtPassDecrypt
            // 
            this.txtPassDecrypt.Location = new System.Drawing.Point(104, 64);
            this.txtPassDecrypt.Name = "txtPassDecrypt";
            this.txtPassDecrypt.PasswordChar = '*';
            this.txtPassDecrypt.Size = new System.Drawing.Size(184, 20);
            this.txtPassDecrypt.TabIndex = 17;
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(16, 8);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(80, 16);
            this.Label6.TabIndex = 16;
            this.Label6.Text = "File to decrypt:";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(-8, 88);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(104, 16);
            this.Label7.TabIndex = 15;
            this.Label7.Text = "Confirm password:";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label8
            // 
            this.Label8.Location = new System.Drawing.Point(8, 64);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(88, 16);
            this.Label8.TabIndex = 14;
            this.Label8.Text = "Type password:";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBrowseDecrypt
            // 
            this.btnBrowseDecrypt.Location = new System.Drawing.Point(296, 8);
            this.btnBrowseDecrypt.Name = "btnBrowseDecrypt";
            this.btnBrowseDecrypt.Size = new System.Drawing.Size(72, 21);
            this.btnBrowseDecrypt.TabIndex = 13;
            this.btnBrowseDecrypt.Text = "Browse";
            this.btnBrowseDecrypt.Click += new System.EventHandler(this.btnBrowseDecrypt_Click);
            // 
            // txtFileToDecrypt
            // 
            this.txtFileToDecrypt.Location = new System.Drawing.Point(104, 8);
            this.txtFileToDecrypt.Name = "txtFileToDecrypt";
            this.txtFileToDecrypt.ReadOnly = true;
            this.txtFileToDecrypt.Size = new System.Drawing.Size(184, 20);
            this.txtFileToDecrypt.TabIndex = 12;
            this.txtFileToDecrypt.Text = "Click Browse to load file.";
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(0, 144);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(384, 16);
            this.pbStatus.TabIndex = 1;
            // 
            // encmain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(382, 156);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "encmain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encrypt / Decrypt File (Using Rijndael)";
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.ResumeLayout(false);

		}

	#endregion



	#region 1. Global Variables 

		//*************************
		//** Global Variables
		//*************************

		private string strFileToEncrypt;
		private string strFileToDecrypt;
		private string strOutputEncrypt;
		private string strOutputDecrypt;
		private System.IO.FileStream fsInput;
		private System.IO.FileStream fsOutput;

	#endregion


	#region 2. Create A Key 

		//*************************
		//** Create A Key
		//*************************

		private byte[] CreateKey(string strPassword)
		{
			//Convert strPassword to an array and store in chrData.
			char[] chrData = strPassword.ToCharArray();
			//Use intLength to get strPassword size.
			int intLength = chrData.GetUpperBound(0);
			//Declare bytDataToHash and make it the same size as chrData.
			byte[] bytDataToHash = new byte[intLength + 1];

			//Use For Next to convert and store chrData into bytDataToHash.
			for (int i = 0; i <= chrData.GetUpperBound(0); i++)
			{
				bytDataToHash[i] = System.Convert.ToByte(System.Convert.ToInt32(chrData[i]));
			}

			//Declare what hash to use.
			System.Security.Cryptography.SHA512Managed SHA512 = new System.Security.Cryptography.SHA512Managed();
			//Declare bytResult, Hash bytDataToHash and store it in bytResult.
			byte[] bytResult = SHA512.ComputeHash(bytDataToHash);
			//Declare bytKey(31).  It will hold 256 bits.
			byte[] bytKey = new byte[32];

			//Use For Next to put a specific size (256 bits) of 
			//bytResult into bytKey. The 0 To 31 will put the first 256 bits
			//of 512 bits into bytKey.
			for (int i = 0; i <= 31; i++)
			{
				bytKey[i] = bytResult[i];
			}

			return bytKey; //Return the key.
		}

	#endregion


	#region 3. Create An IV 

		//*************************
		//** Create An IV
		//*************************

		private byte[] CreateIV(string strPassword)
		{
			//Convert strPassword to an array and store in chrData.
			char[] chrData = strPassword.ToCharArray();
			//Use intLength to get strPassword size.
			int intLength = chrData.GetUpperBound(0);
			//Declare bytDataToHash and make it the same size as chrData.
			byte[] bytDataToHash = new byte[intLength + 1];

			//Use For Next to convert and store chrData into bytDataToHash.
			for (int i = 0; i <= chrData.GetUpperBound(0); i++)
			{
				bytDataToHash[i] = System.Convert.ToByte(System.Convert.ToInt32(chrData[i]));
			}

			//Declare what hash to use.
			System.Security.Cryptography.SHA512Managed SHA512 = new System.Security.Cryptography.SHA512Managed();
			//Declare bytResult, Hash bytDataToHash and store it in bytResult.
			byte[] bytResult = SHA512.ComputeHash(bytDataToHash);
			//Declare bytIV(15).  It will hold 128 bits.
			byte[] bytIV = new byte[16];

			//Use For Next to put a specific size (128 bits) of 
			//bytResult into bytIV. The 0 To 30 for bytKey used the first 256 bits.
			//of the hashed password. The 32 To 47 will put the next 128 bits into bytIV.
			for (int i = 32; i <= 47; i++)
			{
				bytIV[i - 32] = bytResult[i];
			}

			return bytIV; //return the IV
		}

	#endregion


	#region 4. Encrypt / Decrypt File 

		//****************************
		//** Encrypt/Decrypt File
		//****************************

		private enum CryptoAction: int
		{
			//Define the enumeration for CryptoAction.
			ActionEncrypt = 1,
			ActionDecrypt = 2
		}

		private void EncryptOrDecryptFile(string strInputFile, string strOutputFile, byte[] bytKey, byte[] bytIV, CryptoAction Direction)
		{
			try //In case of errors.
			{

				//Setup file streams to handle input and output.
				fsInput = new System.IO.FileStream(strInputFile, FileMode.Open, FileAccess.Read);
				fsOutput = new System.IO.FileStream(strOutputFile, FileMode.OpenOrCreate, FileAccess.Write);
				fsOutput.SetLength(0); //make sure fsOutput is empty

				//Declare variables for encrypt/decrypt process.
				byte[] bytBuffer = new byte[4097]; //holds a block of bytes for processing
				long lngBytesProcessed = 0; //running count of bytes processed
				long lngFileLength = fsInput.Length; //the input file's length
				int intBytesInCurrentBlock = 0; //current bytes being processed
				CryptoStream csCryptoStream = null;
				//Declare your CryptoServiceProvider.
				System.Security.Cryptography.RijndaelManaged cspRijndael = new System.Security.Cryptography.RijndaelManaged();
				//Setup Progress Bar
				pbStatus.Value = 0;
				pbStatus.Maximum = 100;

				//Determine if ecryption or decryption and setup CryptoStream.
				switch (Direction)
				{
					case CryptoAction.ActionEncrypt:
						csCryptoStream = new CryptoStream(fsOutput, cspRijndael.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write);

						break;
					case CryptoAction.ActionDecrypt:
						csCryptoStream = new CryptoStream(fsOutput, cspRijndael.CreateDecryptor(bytKey, bytIV), CryptoStreamMode.Write);
						break;
				}

				//Use While to loop until all of the file is processed.
				while (lngBytesProcessed < lngFileLength)
				{
					//Read file with the input filestream.
					intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096);
					//Write output file with the cryptostream.
					csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock);
					//Update lngBytesProcessed
					lngBytesProcessed = lngBytesProcessed + System.Convert.ToInt64(intBytesInCurrentBlock);
					//Update Progress Bar
					pbStatus.Value = System.Convert.ToInt32((lngBytesProcessed / (double)lngFileLength) * 100);
				}

				//Close FileStreams and CryptoStream.
				csCryptoStream.Close();
				fsInput.Close();
				fsOutput.Close();

				//If encrypting then delete the original unencrypted file.
				if (Direction == CryptoAction.ActionEncrypt)
				{
					FileInfo fileOriginal = new FileInfo(strFileToEncrypt);
					fileOriginal.Delete();
				}

				//If decrypting then delete the encrypted file.
				if (Direction == CryptoAction.ActionDecrypt)
				{
					FileInfo fileEncrypted = new FileInfo(strFileToDecrypt);
					fileEncrypted.Delete();
				}

				//Update the user when the file is done.
				string Wrap = "\r" + "\n";
				if (Direction == CryptoAction.ActionEncrypt)
				{
					MessageBox.Show("Encryption Complete" + Wrap + Wrap + "Total bytes processed = " + lngBytesProcessed.ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

					//Update the progress bar and textboxes.
					pbStatus.Value = 0;
					txtFileToEncrypt.Text = "Click Browse to load file.";
					txtPassEncrypt.Text = "";
					txtConPassEncrypt.Text = "";
					txtDestinationEncrypt.Text = "";
					btnChangeEncrypt.Enabled = false;
					btnEncrypt.Enabled = false;

				}
				else
				{
					//Update the user when the file is done.
					MessageBox.Show("Decryption Complete" + Wrap + Wrap + "Total bytes processed = " + lngBytesProcessed.ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

					//Update the progress bar and textboxes.
					pbStatus.Value = 0;
					txtFileToDecrypt.Text = "Click Browse to load file.";
					txtPassDecrypt.Text = "";
					txtConPassDecrypt.Text = "";
					txtDestinationDecrypt.Text = "";
					btnChangeDecrypt.Enabled = false;
					btnDecrypt.Enabled = false;
				}


				//Catch file not found error.
			}
//TODO: INSTANT C# TODO TASK: There is no C# equivalent to 'When'
//TODO: INSTANT C# TODO TASK: Calls to the VB 'Err' object are not converted by Instant C#:
			catch // When Err.Number = 53 //if file not found
			{
				MessageBox.Show("Please check to make sure the path and filename" + "are correct and if the file exists.", "Invalid Path or Filename", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				//Catch all other errors. And delete partial files.
			
				fsInput.Close();
				fsOutput.Close();

				if (Direction == CryptoAction.ActionDecrypt)
				{
					FileInfo fileDelete = new FileInfo(txtDestinationDecrypt.Text);
					fileDelete.Delete();
					pbStatus.Value = 0;
					txtPassDecrypt.Text = "";
					txtConPassDecrypt.Text = "";

					MessageBox.Show("Please check to make sure that you entered the correct" + "password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					FileInfo fileDelete = new FileInfo(txtDestinationEncrypt.Text);
					fileDelete.Delete();

					pbStatus.Value = 0;
					txtPassEncrypt.Text = "";
					txtConPassEncrypt.Text = "";

					MessageBox.Show("This file cannot be encrypted.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				}

			}
		}

	#endregion


	#region 5. Browse / Change Button 

		//******************************
		//** Browse/Change Buttons
		//******************************

		private void btnBrowseEncrypt_Click(object sender, System.EventArgs e)
		{
			//Setup the open dialog.
			OpenFileDialog.FileName = "";
			OpenFileDialog.Title = "Choose a file to encrypt";
			OpenFileDialog.InitialDirectory = "C:\\";
			OpenFileDialog.Filter = "All Files (*.*) | *.*";

			//Find out if the user chose a file.
			if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				strFileToEncrypt = OpenFileDialog.FileName;
				txtFileToEncrypt.Text = strFileToEncrypt;

				int iPosition = 0;
				int i = 0;

				//Get the position of the last "\" in the OpenFileDialog.FileName path.
				//-1 is when the character your searching for is not there.
				//IndexOf searches from left to right.
				while (strFileToEncrypt.IndexOf('\\', i) != -1)
				{
					iPosition = strFileToEncrypt.IndexOf('\\', i);
					i = iPosition + 1;
				}

				//Assign strOutputFile to the position after the last "\" in the path.
				//This position is the beginning of the file name.
				strOutputEncrypt = strFileToEncrypt.Substring(iPosition + 1);
				//Assign S the entire path, ending at the last "\".
				string S = strFileToEncrypt.Substring(0, iPosition + 1);
				//Replace the "." in the file extension with "_".
				strOutputEncrypt = strOutputEncrypt.Replace('.', '_');
				//The final file name.  XXXXX.encrypt
				txtDestinationEncrypt.Text = S + strOutputEncrypt + ".encrypt";
				//Update buttons.
				btnEncrypt.Enabled = true;
				btnChangeEncrypt.Enabled = true;

			}

		}

		private void btnBrowseDecrypt_Click(object sender, System.EventArgs e)
		{
			//Setup the open dialog.
			OpenFileDialog.FileName = "";
			OpenFileDialog.Title = "Choose a file to decrypt";
			OpenFileDialog.InitialDirectory = "C:\\";
			OpenFileDialog.Filter = "Encrypted Files (*.encrypt) | *.encrypt";

			//Find out if the user chose a file.
			if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				strFileToDecrypt = OpenFileDialog.FileName;
				txtFileToDecrypt.Text = strFileToDecrypt;
				int iPosition = 0;
				int i = 0;
				//Get the position of the last "\" in the OpenFileDialog.FileName path.
				//-1 is when the character your searching for is not there.
				//IndexOf searches from left to right.

				while (strFileToDecrypt.IndexOf('\\', i) != -1)
				{
					iPosition = strFileToDecrypt.IndexOf('\\', i);
					i = iPosition + 1;
				}

				//strOutputFile = the file path minus the last 8 characters (.encrypt)
				strOutputDecrypt = strFileToDecrypt.Substring(0, strFileToDecrypt.Length - 8);
				//Assign S the entire path, ending at the last "\".
				string S = strFileToDecrypt.Substring(0, iPosition + 1);
				//Assign strOutputFile to the position after the last "\" in the path.
				strOutputDecrypt = strOutputDecrypt.Substring((iPosition + 1));
				//Replace "_" with "."
				txtDestinationDecrypt.Text = S + strOutputDecrypt.Replace('_', '.');
				//Update buttons
				btnDecrypt.Enabled = true;
				btnChangeDecrypt.Enabled = true;

			}
		}

		private void btnChangeEncrypt_Click(object sender, System.EventArgs e)
		{
			//Setup up folder browser.
			FolderBrowserDialog.Description = "Select a folder to place the encrypted file in.";
			//If the user selected a folder assign the path to txtDestinationEncrypt.
			if (FolderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				txtDestinationEncrypt.Text = FolderBrowserDialog.SelectedPath + "\\" + strOutputEncrypt + ".encrypt";
			}
		}

		private void btnChangeDecrypt_Click(object sender, System.EventArgs e)
		{
			//Setup up folder browser.
			FolderBrowserDialog.Description = "Select a folder for to place the decrypted file in.";
			//If the user selected a folder assign the path to txtDestinationDecrypt.
			if (FolderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				txtDestinationDecrypt.Text = FolderBrowserDialog.SelectedPath + "\\" + strOutputDecrypt.Replace('_', '.');
			}
		}

	#endregion


	#region 6. Encrypt / Decrypt Buttons 

		//******************************
		//** Encrypt/Decrypt Buttons
		//******************************

		private void btnEncrypt_Click(object sender, System.EventArgs e)
		{
			//Make sure the password is correct.
			if (txtConPassEncrypt.Text == txtPassEncrypt.Text)
			{
				//Declare variables for the key and iv.
				//The key needs to hold 256 bits and the iv 128 bits.
				byte[] bytKey = null;
				byte[] bytIV = null;
				//Send the password to the CreateKey function.
				bytKey = CreateKey(txtPassEncrypt.Text);
				//Send the password to the CreateIV function.
				bytIV = CreateIV(txtPassEncrypt.Text);
				//Start the encryption.
				EncryptOrDecryptFile(strFileToEncrypt, txtDestinationEncrypt.Text, bytKey, bytIV, CryptoAction.ActionEncrypt);
			}
			else
			{
				MessageBox.Show("Please re-enter your password.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtPassEncrypt.Text = "";
				txtConPassEncrypt.Text = "";
			}
		}

		private void btnDecrypt_Click(object sender, System.EventArgs e)
		{
			//Make sure the password is correct.
			if (txtConPassDecrypt.Text == txtPassDecrypt.Text)
			{
				//Declare variables for the key and iv.
				//The key needs to hold 256 bits and the iv 128 bits.
				byte[] bytKey = null;
				byte[] bytIV = null;
				//Send the password to the CreateKey function.
				bytKey = CreateKey(txtPassDecrypt.Text);
				//Send the password to the CreateIV function.
				bytIV = CreateIV(txtPassDecrypt.Text);
				//Start the decryption.
				EncryptOrDecryptFile(strFileToDecrypt, txtDestinationDecrypt.Text, bytKey, bytIV, CryptoAction.ActionDecrypt);
			}
			else
			{
				MessageBox.Show("Please re-enter your password.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtPassDecrypt.Text = "";
				txtConPassDecrypt.Text = "";
			}
		}

	#endregion





		

	}

} //end of root namespace