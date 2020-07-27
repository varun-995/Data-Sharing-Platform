using System;
using System.Collections;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;
using System.IO.Compression;


namespace CompressFolders
{
    public partial class frmMain : Form
    {

        public frmMain(string name)
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Select files for subsequent addition to the list of
        /// files to be archived
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // configure the open file dialog
            openFileDialog1.Title = "Add File";
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FileName = "";

            // return if the user cancels the operation
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            // set a local variable to contain the file name
            // captured from the open file dialog
            string sFilePath;
            sFilePath = openFileDialog1.FileName;
            if (sFilePath == "")
                return;

            // make sure the file exists before adding 
            // its path to the list of files to be
            // compressed
            if (System.IO.File.Exists(sFilePath) == false)
                return;
            else
                txtAddFile.Text = sFilePath;

        }


        /// <summary>
        /// Button click event handler used to add files from the browse
        /// textbox to the listbox control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            // Check for content in the text box
            if (txtAddFile.Text == string.Empty)
            {
                MessageBox.Show("Use the browse button to search for " +
                "the file to be added.", "Missing File Name");
                return;
            }

            // Only allow the file to be added if the file is not a duplicate
            for (int i = 0; i < lstFilePaths.Items.Count; i++)
            {
                if (lstFilePaths.Items[i].ToString() == txtAddFile.Text.ToString())
                {
                    MessageBox.Show("That file has already been added to the list.", 
                        "Duplicate");
                    return;
                }
            }

            // Add the file to the listbox list
            if (txtAddFile.Text != string.Empty)
                lstFilePaths.Items.Add(txtAddFile.Text.ToString());

            // clear the textbox and move the focus back to the textbox
            txtAddFile.Text = string.Empty;
            txtAddFile.Focus();
        }


        /// <summary>
        /// Button click handler to remove selected items from
        /// the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            try
            {
                lstFilePaths.Items.Remove(lstFilePaths.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }



        /// <summary>
        /// Button click handler used to set the path to
        /// the zipped file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveBrowse_Click(object sender, EventArgs e)
        {
            // clear the folder path
            txtSaveTo.Text = string.Empty;

            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSaveTo.Text = folderBrowserDialog1.SelectedPath;
            }
        }


        /// <summary>
        /// Collect the files into a common folder location, zip the
        /// files up, and delete the copied files and folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // make sure there are files to zip
            if (lstFilePaths.Items.Count < 1)
            {
                MessageBox.Show("There are no files queued for the zip operation", "Empty File Set");
                return;
            }

            // make sure there is a destination defined
            if (txtSaveTo.Text == string.Empty)
            {
                MessageBox.Show("No destination file has been defined.", "Save To Empty");
                return;
            }

            lblUpdate.Visible = true;
            lblUpdate.Refresh();

            // name the zip file whatever the folder is named
            // by splitting the file path to get the folder name
            string[] sTemp = txtSaveTo.Text.Split('\\');
            string sZipFileName = sTemp[sTemp.Length - 1].ToString();

            // check to see if zipped file already exists
            // user may rename it in the text box if it does.
            FileInfo fi = new FileInfo(txtSaveTo.Text + "\\" + sZipFileName + ".zip");
            if (fi.Exists)
            {
                // move it to the folder
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("The file " + sZipFileName + " already exists. ");
                    sb.Append("You may rename it in the save to text box.");
                    MessageBox.Show(sb.ToString(), "Existing File Name");
                    txtSaveTo.Focus();
                    return;
                }
                catch
                {
                    MessageBox.Show("Rename the file or select a new location.", "File Error");
                    return;
                }
            }


            // Check for the existence of the target folder and
            // create it if it does not exist
            if (!System.IO.Directory.Exists(txtSaveTo.Text + "\\TempZipFile\\"))
            {
                System.IO.Directory.CreateDirectory(txtSaveTo.Text + "\\TempZipFile\\");
            }

            // Set up a string to hold the path to the temp folder
            string sTargetFolderPath = (txtSaveTo.Text + "\\TempZipFile\\");

            // Process the files and move each into the target folder
            for (int i = 0; i < lstFilePaths.Items.Count; i++)
            {
                string filePath = lstFilePaths.Items[i].ToString();
                FileInfo fi2 = new FileInfo(filePath);
                if (fi2.Exists)
                {
                    // move it to the folder
                    try
                    {
                        fi2.CopyTo(sTargetFolderPath + fi2.Name, true);
                    }
                    catch
                    {
                        // clean up if the operation failed
                        System.IO.Directory.Delete(sTargetFolderPath);
                        MessageBox.Show("Could not copy files to temp folder.", "File Error");
                        return;
                    }
                }
            }


            // zip up the files
            try
            {
                lblUpdate.Visible = true;
                lblUpdate.Refresh();

                string[] filenames = Directory.GetFiles(sTargetFolderPath);

                // Zip up the files - From SharpZipLib Demo Code
                using (ZipOutputStream s = new ZipOutputStream(File.Create(txtSaveTo.Text + "\\" + sZipFileName + ".zip")))
                {
                    s.SetLevel(9); // 0-9, 9 being the highest level of compression

                    byte[] buffer = new byte[4096];

                    foreach (string file in filenames)
                    {

                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));

                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);

                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);

                            } while (sourceBytes > 0);
                        }
                    }
                    s.Finish();
                    s.Close();
                }

                // remove the progress bar
                lblUpdate.Visible = false;

                // clean up files by deleting the temp folder and its content
                System.IO.Directory.Delete(txtSaveTo.Text + "\\TempZipFile\\", true);

                // Notify user
                MessageBox.Show("Zip file " + txtSaveTo.Text + " created.");

                // empty everything
                lstFilePaths.Items.Clear();
                txtSaveTo.Text = string.Empty;
                txtAddFile.Text = string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Zip Operation Error");
            }
        }


        /// <summary>
        /// Exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void gbxAddFiles_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }


    }
}