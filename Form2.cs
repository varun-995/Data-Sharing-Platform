using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;

namespace howto_crypt_file
{
    public partial class Form2 : Form
    {
        public Form2(string name)
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void EncryptFile(string inputFile, string outputFile)
        {

            try
            {
                string password = @"myKey123"; // Your Key Here
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);


                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

              

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch
            {
                MessageBox.Show("Encryption failed!", "Error");
            }
        }
      
        private void DecryptFile(string inputFile, string outputFile)
        {

            {
                string password = @"myKey123"; // Your Key Here

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename=string.Empty;
            OpenFileDialog file=new OpenFileDialog();         
          
            if(file.ShowDialog()==DialogResult.OK)
            {
                filename=file.FileName;
            }
            SaveFileDialog sdialog = new SaveFileDialog();
            sdialog.ShowDialog();
            string path = sdialog.FileName;
            EncryptFile(filename, path);
            MessageBox.Show("Encrypt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog=new OpenFileDialog();
            dialog.ShowDialog();
            string fiename=dialog.FileName;
            SaveFileDialog dialog1=new SaveFileDialog();
            dialog1.ShowDialog();
            string decryptfile=dialog1.FileName;
            DecryptFile(fiename, decryptfile);
            MessageBox.Show("decrypt");
        }
    }
}
