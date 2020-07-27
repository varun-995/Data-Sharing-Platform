using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace FileSplitter
{
    public partial class share : Form
    {
        public share()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Server 1")
            {
               
                string ftplocation = "ftp://107.180.1.81";
                string file = lblfilepath.Text; // Or on FreeBSD: "/usr/home/jared/test2.txt";
                string user = "lbsim";
                string password = "sim@9599929953";
                UploadToFTP(ftplocation, file, user, password);
                save s = new save();
                s.insert("insert into Share(Friendid,Filename,Servername) values('" + textBox1.Text + "','" + label3.Text + "','" + comboBox1.Text + "')");
                MessageBox.Show("Successfully Shared");
            }
            if (comboBox1.Text == "Server 2")
            {
                
                string ftplocation = "ftp://107.180.1.81";
                string file = lblfilepath.Text; // Or on FreeBSD: "/usr/home/jared/test2.txt";
                string user = "lbsim";
                string password = "sim@9599929953";
                UploadToFTP(ftplocation, file, user, password);
                save s = new save();
                s.insert("insert into Share(Friendid,Filename,Servername) values('" + textBox1.Text + "','" + label3.Text + "','" + comboBox1.Text + "')");
                MessageBox.Show("Successfully Shared");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            label3.Text = file.SafeFileName;
            lblfilepath.Text = file.FileName;
           // MessageBox.Show(filename);

        }
        static void UploadToFTP(String inFTPServerAndPath, String inFullPathToLocalFile, String inUsername, String inPassword)
        {
            // Get the local file name: C:\Users\Rhyous\Desktop\File1.zip
            // and get just the filename: File1.zip. This is so we can add it
            // to the full URI.
            String filename = Path.GetFileName(inFullPathToLocalFile);

            // Open a request using the full URI, c/file.ext
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(inFTPServerAndPath + "/" + filename);

            // Configure the connection request
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(inUsername, inPassword);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            // Create a stream from the file
            FileStream stream = File.OpenRead(inFullPathToLocalFile);
            byte[] buffer = new byte[stream.Length];

            
            // Read the file into the  local stream
            stream.Read(buffer, 0, buffer.Length);
            
            // Close the local stream
            stream.Close();

            // Create a stream to the FTP server
            Stream reqStream = request.GetRequestStream();
            

            // Write the local stream to the FTP stream
            // 2 bytes at a time
            int offset = 0;
            int chunk = (buffer.Length > 2048) ? 2048 : buffer.Length;
            while (offset < buffer.Length)
            {
                reqStream.Write(buffer, offset, chunk);            
                offset += chunk;
                chunk = (buffer.Length - offset < chunk) ? (buffer.Length - offset) : chunk;
                
            }
            // Close the stream to the FTP server
            reqStream.Close();
        }

        private void share_Load(object sender, EventArgs e)
        {

        }
    }

}
