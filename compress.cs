using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace FileSplitter
{
    public partial class compress : Form
    {
        public compress(string name)
        {
            InitializeComponent();
        }

        private void compress_Load(object sender, EventArgs e)
        {

        }
        public static void Compress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Prevent compressing hidden and 
                // already compressed files.
                if ((File.GetAttributes(fi.FullName) 
                	& FileAttributes.Hidden)
                	!= FileAttributes.Hidden & fi.Extension != ".gz")
                {
                    // Create the compressed file.
                    using (FileStream outFile = 
                    			File.Create(fi.FullName + ".gz"))
                    {
                        using (GZipStream Compress = 
                        	new GZipStream(outFile, 
                        	CompressionMode.Compress))
                        {
                            // Copy the source file into 
                            // the compression stream.
                     //   inFile.CopyTo(Compress);

                            Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                                fi.Name, fi.Length.ToString(), outFile.Length.ToString());
                        }
                    }
                }
            }
        }

        public static void Decompress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Get original file extension, for example
                // "doc" from report.doc.gz.
                string curFile = fi.FullName;
                string origName = curFile.Remove(curFile.Length - 
                		fi.Extension.Length);

                //Create the decompressed file.
                using (FileStream outFile = File.Create(origName))
                {
                    using (GZipStream Decompress = new GZipStream(inFile,
                            CompressionMode.Decompress))
                    {
                        // Copy the decompression stream 
                        // into the output file.
            		  //  Decompress..CopyTo(outFile);
            		    
                        Console.WriteLine("Decompressed: {0}", fi.Name);

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = textBox1.Text;
            GZipStream outStream = new GZipStream(File.OpenWrite("E:\\test.zip"), CompressionMode.Compress);
            StreamWriter sw = new StreamWriter(outStream);
            sw.Write(data);
            sw.Close();
            MessageBox.Show("Data Compressed to file test.zip!!");
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog d=new OpenFileDialog();
            d.ShowDialog();
            textBox1.Text = d.FileName;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ReadData = "";
            GZipStream instream = new GZipStream(File.OpenRead("F:\\test.zip"), CompressionMode.Decompress);

            StreamReader reader = new StreamReader(instream);

            ReadData = reader.ReadToEnd();
            reader.Close();
            textBox1.Text = ReadData;
            MessageBox.Show("Data Read Successfully!!");
        }

    }
}

