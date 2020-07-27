using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Security.AccessControl;
using System.Xml;



namespace FileSplitter
{
    public partial class splitnjoin : Form
    {
       
        public splitnjoin(string name)
        {
            
             
            InitializeComponent();
            
        }


        private void SplitFile(string InputPath, string OutputPath, int OutputFiles)
        {
            // Store the file in a byte array
            Byte[] byteSource = System.IO.File.ReadAllBytes(InputPath);
            // Get file info
            FileInfo fiSource = new FileInfo(txtSourceFile.Text);
            // Calculate the size of each part
            int partSize = (int)Math.Ceiling((double)(fiSource.Length / OutputFiles));
            // The offset at which to start reading from the source file
            int fileOffset = 0;

            // Stores the name of each file part
            string currPartPath;
            // The file stream that will hold each file part
            FileStream fsPart;
            // Stores the remaining byte length to write to other files
            int sizeRemaining = (int)fiSource.Length;

            // Loop through as many times we need to create the partial files
            for (int i = 0; i < OutputFiles; i++)
            {
                // Store the path of the new part
                currPartPath = OutputPath + "\\" + fiSource.Name + "." + String.Format(@"{0:D4}", i) + ".part";
                // A filestream for the path
                if (!File.Exists(currPartPath))
                {
                    fsPart = new FileStream(currPartPath, FileMode.CreateNew);
                    // Calculate the remaining size of the whole file
                    sizeRemaining = (int)fiSource.Length - (i * partSize);
                    // The size of the last part file might differ because a file doesn't always split equally
                    if (sizeRemaining < partSize)
                    {
                        partSize = sizeRemaining;
                    }



                    fsPart.Write(byteSource, fileOffset, partSize);
                    fsPart.Close();
                    fileOffset += partSize;
                    //}
                    //FileStream sourceFileStream = File.OpenRead(txtSourceFile.Text);
                    //FileStream destFileStream = File.Create(currPartPath);
                    //GZipStream compressingStream = new GZipStream(destFileStream, CompressionMode.Compress);
                    //byte[] bytes = new byte[2048];
                    //int bytesRead;

                    //while ((bytesRead = sourceFileStream.Read(bytes, 0, bytes.Length)) != 0)
                    //{
                    //    compressingStream.Write(bytes, 0, bytesRead);
                    //}
                    //sourceFileStream.Close();
                    //compressingStream.Close();
                    //destFileStream.Close();
                }

            }
        }
       
        private void JoinFiles(string FolderInputPath, string FileOutputPath)
        {
            try
            {
                DirectoryInfo diSource = new DirectoryInfo(FolderInputPath);
                FileStream fsSource = new FileStream(FileOutputPath, FileMode.Append);

                foreach (FileInfo fiPart in diSource.GetFiles(@"*.part"))
                {
                    Byte[] bytePart = System.IO.File.ReadAllBytes(fiPart.FullName);
                    fsSource.Write(bytePart, 0, bytePart.Length);
                     
                }
                fsSource.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFolder.ShowDialog() == DialogResult.OK)
                {
                    txtSourceFolder.Text = openFolder.SelectedPath;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveOutput.ShowDialog() == DialogResult.OK)
                {
                    JoinFiles(txtSourceFolder.Text, saveOutput.FileName);                    
                    string folderpath = txtSourceFolder.Text;  
         
                   
                    MessageBox.Show("Merge successful");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (openSource.ShowDialog() == DialogResult.OK)
                {
                    txtSourceFile.Text = openSource.FileName;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveToFolder.ShowDialog() == DialogResult.OK)
                {
                    SplitFile(txtSourceFile.Text, saveToFolder.SelectedPath, (int)numOutputs.Value);                   
                    string folderpath = saveToFolder.SelectedPath;                    
                    MessageBox.Show("Split successful");
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }
         private bool checkpassword()
        {
            XmlTextReader read = new XmlTextReader(folderBrowserDialog1.SelectedPath + "\\p.xml");
            if (read.ReadState == ReadState.Error)
                return true;
            else
            {
                try
                {
                    while (read.Read())
                        if (read.NodeType == XmlNodeType.Text)
                        {
                            checkpassword c = new checkpassword();
                            c.pass = read.Value;
                            if (c.ShowDialog() == DialogResult.OK)
                            {
                                read.Close();
                                return c.status;
                            }

                        }
                }
                catch { return true; }
                
            }
            read.Close();
            return false;
        }

        private Boolean setpassword(string path)
        {
            password p = new password();
            p.path = path;
            p.ShowDialog();
            return true;
        }       

    }
        
  }

