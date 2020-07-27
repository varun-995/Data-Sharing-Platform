

    
    using System;
    using System.Drawing;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.IO ;
    using System.Security;
    using System.Security.Cryptography;
namespace SaurabhCrypto
{
    /// <summary>
    ///    Class which will Encrypt and Decrypt files
    /// </summary>
    public class SymEncryptor : Form {

        /// <summary> 
        ///    Required by the Win Forms designer 
        /// </summary>
	private System.ComponentModel.Container components;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;

    private System.Windows.Forms.StatusBar statusBar1;
    private System.Windows.Forms.Button decryptb;
    private System.Windows.Forms.Button encryptb;
    private System.Windows.Forms.RadioButton radioButton2;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.Label infol;
    private System.Windows.Forms.TextBox passt;
    private System.Windows.Forms.Label passl;
    private System.Windows.Forms.Button saveb;
    private System.Windows.Forms.Button openb;
    private System.Windows.Forms.TextBox savet;
    private System.Windows.Forms.TextBox opent;
    private System.Windows.Forms.Label savel;
    private System.Windows.Forms.Label openl;
    
    //these byte arrays will contain the 'KEY' and 'Vector' used in encryption and decryption 
    private byte[] symKey ;
    private byte[] symIV ;  
    
    	///<summary>
    	///		This is the constructor of the class.
    	///		It calls only one method 'InitlizeComponent' which draws the WinForm .
    	///</summary>  
        public SymEncryptor() {

            // Call the method to make the WinForm
            InitializeComponent();

        }

        /// <summary>
		/// 	This method is called when the WinForm exits and it
        ///    Cleans up any resources being used
        /// </summary>
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }


        /// <summary>
        ///    The main entry point for the application.
        /// </summary>
        public static void Main(string[] args) {
            Application.Run(new SymEncryptor());
        }


        /// <summary>
        ///    Method called from the constructor
        ///		It initlises all the WinForm components
        /// </summary>
        private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.passt = new System.WinForms.TextBox();
		this.openb = new System.WinForms.Button();
		this.openl = new System.WinForms.Label();
		this.infol = new System.WinForms.Label();
		this.radioButton2 = new System.WinForms.RadioButton();
		this.saveFileDialog1 = new System.WinForms.SaveFileDialog();
		this.statusBar1 = new System.WinForms.StatusBar();
		this.radioButton1 = new System.WinForms.RadioButton();
		this.encryptb = new System.WinForms.Button();
		this.openFileDialog1 = new System.WinForms.OpenFileDialog();
		this.savet = new System.WinForms.TextBox();
		this.opent = new System.WinForms.TextBox();
		this.passl = new System.WinForms.Label();
		this.saveb = new System.WinForms.Button();
		
		this.savel = new System.WinForms.Label();
		this.decryptb = new System.WinForms.Button();
		
		
		passt.Location = new System.Drawing.Point(112, 88);
		//set the 'PasswordChar' property on the textbox so that it works like a Password field.
		passt.PasswordChar = '*';
		passt.TabIndex = 2;
		passt.Size = new System.Drawing.Size(168, 20);
		
		openb.Location = new System.Drawing.Point(304, 16);
		openb.ForeColor = System.Drawing.Color.White;
		openb.Size = new System.Drawing.Size(72, 24);
		openb.TabIndex = 3;
		openb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold);
		openb.Text = "Open";
		openb.Click += new System.EventHandler(openb_click);
		
		openl.Location = new System.Drawing.Point(8, 16);
		openl.Text = "Open File";
		openl.Size = new System.Drawing.Size(88, 20);
		openl.BorderStyle = System.WinForms.BorderStyle.Fixed3D;
		openl.ForeColor = System.Drawing.SystemColors.WindowText;
		openl.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold);
		openl.TabIndex = 13;
		openl.BackColor = System.Drawing.Color.DarkOrange;
		openl.TextAlign = System.WinForms.HorizontalAlignment.Center;
		
		infol.Location = new System.Drawing.Point(63, 128);
		infol.Text = "Choose Symmetric Algorithm";
		infol.Size = new System.Drawing.Size(264, 20);
		infol.ForeColor = System.Drawing.SystemColors.WindowText;
		infol.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold);
		infol.TabIndex = 10;
		infol.BackColor = System.Drawing.Color.DarkOrange;
		infol.TextAlign = System.WinForms.HorizontalAlignment.Center;
		
		radioButton2.Location = new System.Drawing.Point(80, 224);
		radioButton2.Text = "RC2";
		radioButton2.Size = new System.Drawing.Size(168, 23);
		radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Bold);
		radioButton2.TabIndex = 6;
		
		
		saveFileDialog1.CreatePrompt = true;
		saveFileDialog1.FileName = "File1";
		
		statusBar1.BackColor = System.Drawing.SystemColors.Control;
		statusBar1.Location = new System.Drawing.Point(0, 351);
		statusBar1.Size = new System.Drawing.Size(390, 20);
		statusBar1.TabIndex = 1;
		statusBar1.Text = "Ready";
		
		radioButton1.Location = new System.Drawing.Point(80, 176);
		radioButton1.Text = "Data Encryption Standard-DES";
		radioButton1.Size = new System.Drawing.Size(248, 23);
		radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Bold);
		radioButton1.TabIndex = 5;
		radioButton1.Checked=true ;
		
		encryptb.Location = new System.Drawing.Point(72, 280);
		encryptb.ForeColor = System.Drawing.Color.White;
		encryptb.Size = new System.Drawing.Size(96, 24);
		encryptb.TabIndex = 7;
		encryptb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold);
		encryptb.Text = "Encrypt";
		encryptb.Click += new System.EventHandler(encryptb_click);
		
		
		
		savet.Location = new System.Drawing.Point(112, 52);
		savet.TabIndex = 1;
		savet.Size = new System.Drawing.Size(168, 20);
		
		opent.Location = new System.Drawing.Point(112, 16);
		opent.TabIndex = 0;
		opent.Size = new System.Drawing.Size(168, 20);
		
		passl.Location = new System.Drawing.Point(8, 88);
		passl.Text = "Password";
		passl.Size = new System.Drawing.Size(88, 20);
		passl.ForeColor = System.Drawing.Color.Black;
		passl.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold);
		passl.TabIndex = 11;
		passl.BackColor = System.Drawing.Color.DarkOrange;
		passl.TextAlign = System.WinForms.HorizontalAlignment.Center;
		
		saveb.Location = new System.Drawing.Point(304, 52);
		saveb.ForeColor = System.Drawing.Color.White;
		saveb.Size = new System.Drawing.Size(72, 24);
		saveb.TabIndex = 4;
		saveb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold);
		saveb.Text = "Save";
		saveb.Click += new System.EventHandler(saveb_click);
		
		
		
		savel.Location = new System.Drawing.Point(8, 52);
		savel.Text = "Save File";
		savel.Size = new System.Drawing.Size(88, 20);
		savel.BorderStyle = System.WinForms.BorderStyle.Fixed3D;
		savel.ForeColor = System.Drawing.SystemColors.WindowText;
		savel.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold);
		savel.TabIndex = 12;
		savel.BackColor = System.Drawing.Color.DarkOrange;
		savel.TextAlign = System.WinForms.HorizontalAlignment.Center;
		
		decryptb.Location = new System.Drawing.Point(200, 280);
		decryptb.ForeColor = System.Drawing.Color.White;
		decryptb.Size = new System.Drawing.Size(96, 24);
		decryptb.TabIndex = 8;
		decryptb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold);
		decryptb.Text = "Decrypt";
		decryptb.Click += new System.EventHandler(decryptb_click);
		this.Text = "Symmetric Encryption beta 1, by Saurabh Nandu";
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.BorderStyle = System.WinForms.FormBorderStyle.Fixed3D;
		this.ForeColor = System.Drawing.Color.DarkOrange;
		this.BackColor = System.Drawing.SystemColors.Desktop;
		this.ClientSize = new System.Drawing.Size(390, 371);
		
		
		this.Controls.Add(statusBar1);
		this.Controls.Add(decryptb);
		this.Controls.Add(encryptb);
		this.Controls.Add(radioButton2);
		this.Controls.Add(radioButton1);
		this.Controls.Add(infol);
		this.Controls.Add(passt);
		this.Controls.Add(passl);
		this.Controls.Add(saveb);
		this.Controls.Add(openb);
		this.Controls.Add(savet);
		this.Controls.Add(opent);
		this.Controls.Add(savel);
		this.Controls.Add(openl);
	}
	
	///<summary>
	///	<para>
	///		This method is called when the 'Decrypt' button is clicked by the user.
	///		It first checks the file type and then calls the required methods to decrypt the 
	///  	file .
	///	</para>
	///</summary>
    protected void decryptb_click(object sender, System.EventArgs e)
	{
		//call the method 'ValidateBoxes()' which checks all the fields of the WinForm and 
		//returns a 'true' if everything is filled properly
		//if there are some errors it returns a 'false'	
		if(ValidateBoxes())
		{
			//if all the Fields of the WinForm are valid then call the method 'DecryptData() '
			//this method takes care of all the decrypting to do
			DecryptData();
			
			//after decrypting set all the TextBoxes to their default values
			//this is not necessary but more user friendly...
			opent.Text="";
			savet.Text="" ;
			passt.Text="" ;
			radioButton1.Checked=true ;
		}
	}
	
	///<summary>
	///	<para>
	///		This method is called when the 'Encrypt' button is pressed in the WinForm.
	///		It checks the file and encrypts it according to the algoritm specified by the user.
	///	</para>
	///</summary>
    protected void encryptb_click(object sender, System.EventArgs e)
	{
		//a method 'ValidateBoxes()' is called which returns a true only if all the fields of the 
		//WinForm are properly filled in
		if(ValidateBoxes())
		{
			//Here we make a call the a method 'GenerateKee(bool variable)' 
			//this method takes in a bool value and genrates the Hash 'Key'
			//and 'Initilization Vector' which will be used in encryption / decryption
			//it returns a 'true' if everything is properly genrated
			//Here we Pass the 'radioButton1.Checked' as an argument since the method genrates 
			//'key' and 'vector' depending on which algorithm to use
			//so if 'radioButton1.Checked=true' it means we are using the 'DES' algorithm
			//else we are using the 'RC2' algorithm
			if(GenerateKee(radioButton1.Checked))
			{
				//call the method 'EncryptData()' which will take care of all the encrypting
				EncryptData() ;
				
				//Set the TextBoxes to their default values
				//this can be ommited , but its more user friendly
				opent.Text="";
				savet.Text="" ;
				passt.Text="" ;
				radioButton1.Checked=true ;
			}
			
		}
	}
	
	///<summary>
	///	<para>
	///		This method is called when the 'Save' button is clicked
	///		It opens a 'SaveFileDialog' and takes the file to be saved to
	///	</para>
	///</summary>
    protected void saveb_click(object sender, System.EventArgs e)
	{
		//diffrent parameters of the 'SaveFileDialog' are set here
		saveFileDialog1.Filter = "All files (*.*)|*.* | Encryptor files (*.enc)|*.enc"  ;
    	saveFileDialog1.FilterIndex = 2 ;
    	saveFileDialog1.RestoreDirectory = true ;
    	//check if the user has already typed a file to save in the TextBox
		if(savet.Text!="")
		{
					//if the user has typed a filename in the TextBox then assign that to the dialogs 'FileName' property
			saveFileDialog1.FileName=savet.Text ;
		}
    		if(saveFileDialog1.ShowDialog() == DialogResult.OK)
    		{
    			//when the user presses 'Ok' on the 'SaveFileDialog' then set the text of the TextBox 'savet' 
    			//to the file selected
        		savet.Text = saveFileDialog1.FileName ;
    		}
	
	}
	
	///<summary>
	///	<para>
	///		This method is called when the 'Open' button is clicked by the user
	///	</para>
	///</summary>
    protected void openb_click(object sender, System.EventArgs e)
	{
	//Set the various properties of the 'OpenFileDialog'	
    	openFileDialog1.Filter = "Encryptor files (*.enc)|*.enc|All files (*.*)|*.*"  ;
    	openFileDialog1.FilterIndex = 2 ;
    	openFileDialog1.RestoreDirectory = true ;
    	//check if the user has already typed the file to open in the textbox
		if(opent.Text!="")
		{
				//Then assign the Dialog the Filename from the TextBox
			openFileDialog1.FileName = opent.Text ;
		}
		
    		if(openFileDialog1.ShowDialog() == DialogResult.OK)
    		{
    			//if the user presses 'Ok' in the 'OpenFileDialog' then assign the
    			//file selected to the textbox
        		opent.Text = openFileDialog1.FileName ;
       	}
	}
	
		///<summary>
		///	<para>
		///		this method checks if any of the TextBoxes are left empty by the user 
		///		and it generates the error required
		///		it returns 'true' if all values are proper
		///	</para>
		///</summary>
	private bool ValidateBoxes()
	{
			//check the 'Open' File textbox	
		if(opent.Text=="")
		{
			MessageBox.Show("Please Enter the file to Encrypt / Decrypt !") ;
			return false ;
		}
			//check the 'Save' file textbox
		if(savet.Text=="")
		{
			MessageBox.Show("Please Enter the filename to save !") ;
			return false ;
		}
			//check the password textbox
		if(passt.Text=="")
		{
			MessageBox.Show("Please Enter the Password Encrypt / Decrypt your file with.") ;
			return false ;
		}
			//if everything is alright return true
		return true ;
	}
	
		///<summary>
		///	<para>
		///		This Method computes the 'Key' and the 'Initilization Vector' to be used in encrypting / decrypting.
		///		It generates the key according to the algorithm.
		///		It returns is key generation is sucessful 
		///	</para>
		///	<para>
		///		If the algorithm to be used is 'DES' then it generates a 64bit Key and 64bit Vector
		///		from the provided 'Password' .Then this is stored in to a 'byte' array having 'length' '8'. 
		///		since 1 byte = 8 bits , hence a byte array having length '8' will contain a key of
		///		8 x 8 =64 bits.
		///		We use a 64bit key since DES supports a minimum 64 bit key
		///	</para >
		///	<para>
		///		If the algorithm to be used is 'RC2' then it generates a 40bit Key and a 40 bit Vector
		///		from the provided 'Password'.
		///		We use a 40 bit key here since RC2 supports a minimum 40 bit key (it does not support a 64bit key).
		///	</para>
		///</summary> 
	private bool GenerateKee(bool isDES)
	{
			//try-catch block
		try{
			//store the password in a string 
		string pass =passt.Text ;
		int i ;
		int len ;
			//convert the password in to a Char array
		char[] cp = pass.ToCharArray() ;
		len = cp.GetLength(0) ;
		//initilize a byte array 
		byte[] bt = new byte[len] ;
		//convert the Char array of the Password to a byte array
		for(i=0 ; i<len ;i++)
		{
			bt[i] =(byte) cp[i];
		}
		
			//if we are producing a Key-Vector for the 'DES' algotithm
		if(isDES)
		{
					//initilize the byte arrays which will contain the 'Key' and the 'Vector' respectively
					//to a length of '8' (see above why we use a array of length '8')
			symKey=new byte[8] ;
			symIV = new byte[8] ;
			
					//make a instance of the class 'SHA1_CSP()' 
					//this class is usefull in coverting 'byte' into 'Hash'.			
			SHA1_CSP sha = new SHA1_CSP() ;
					//write the Hash of the byte array containing the password
			sha.Write(bt) ;
					//close the stream
			sha.CloseStream() ;
			
					//now Initilize the 'Key' array with the lower 64bits of the Hash of the 'Password' provided by the 
					//user
			for(i=0 ; i<8 ; i++)
			{
				symKey[i] = sha.Hash[i] ;
			}
					//initilize the 'Vector' array wiht the higher 64 bits of Hash of the 'Password' provided by
					//the user
			for(i=8 ; i<16 ; i++)
			{
				symIV[i-8]= sha.Hash[i] ;
			}
			
		}
		else
		{
					//if the algorithm is 'RC2' then genrate the following Key
					
					//inilize the Key and Vector arrays to a length of '5' (see above why we use '5') 
			symKey=new byte[5] ;
			symIV = new byte[5] ;
			
					//make a instance of the class 'SHA1_CSP' 
					//this class wreites the hash of a given byte			
			SHA1_CSP sha = new SHA1_CSP() ;
					//write the Hash of the byte array containing the user password
			sha.Write(bt) ;
					//close the stream
			sha.CloseStream() ;
					//now Initilize the Key array to lower 40 bits of the Hash of the 'Password' provided by the user 
			for(i=0 ; i<5 ; i++)
			{
				symKey[i] = sha.Hash[i] ;
			}
					//initilize the Vector array to 40bits of hash 
			for(i=5 ; i<10 ; i++)
			{
				symIV[i-5]= sha.Hash[i] ;
			}
		}
			//since every thing went properly return 'true'
		return true ;	
	}
	catch(Exception e)
	{
		MessageBox.Show("A Exception Occured in Generating Keys :"+e.ToString()) ;
			//retuen false since there was a error
		return false ;
	}
	}
	
	
	///<summary>
	///	<para>
	///		This method encrypts the given input file in either of the 2 algorithms 'DES' or 'RC2'.
	///		Then it writes out the encrypted file
	///	</para>
	/// <para>
	///		This method first reads the input file to check to see if its already encrypted by this
	///		same program. If its already encrypted it gives a error.
	///	</para>
	/// <para>
	///		According to the algorithm specified it then encrypts the file.
	///		Also in the first 8 bytes of the new Encrypted it writes out "[saudes]" or "[saurc2]"
	///		This is done so the while decrypting the program can know which algorithm was used to
	///		encrypt the file. Also it used to check if the file has already encrypted
	/// </para>
	///</summary>
	private void EncryptData()
	{
			//try-catch block
		try{	
			bool algo ;  //a boolean variable to check which algorithm to use in encrypting
					//open the 'FileStream' on the file to be encrypted
			FileStream fin = new FileStream(opent.Text , FileMode.Open , FileAccess.Read) ;
					//Make a file to save the encrypted data to and open a 'FileStream' on it
			FileStream fout = new FileStream(savet.Text , FileMode.OpenOrCreate , FileAccess.Write) ;
					//set the position of the 'cursor' to the start of the file
			fout.SetLength(0) ;
					//make a byte array of the size 64 bits
					//this is called the 'Buffer Size' of the algorithm
					//i.e. while encrypting blocks of the size 64bits are processed at a single time
					//later other blocks are of the same size.
					//we use 64bits because both 'DES' and 'RC2' both algorithms have 64 bit 'Buffer Size'
			byte[] bin = new byte[4096] ;
					//set the total length of the file to me encrypted to a variable 
			long totlen = fin.Length ;
			long rdlen=0;
			int len ;
					//the code below is used to check if the file has already been encrypted by this program
			//make a byte array of length '4' 
				  byte[] tag = new byte[4];
				  //read the first 4 bytes from the file to be encrypted
            	  fin.Read(tag,0,tag.Length);
            	//if it contains the chars "[sau" then it has been already encrypted by this program
            if ((tag[0]==(byte)'[') && (tag[1]==(byte)'S') && (tag[2]==(byte)'a') && (tag[3]==(byte)'u') )
             {
               	//genrate a error to let the user know of the error
                	MessageBox.Show("This file is already Encrypted or in Invalid format!") ;
                	statusBar1.Text="Error - Invalid File Format !!"  ;               
            }
            
            else {
            	//if the file if ok the proceed with encryption
                	statusBar1.Text="Encrypting...";
                	//set the file read cursor back to the 'Begning' of the opened file 
                	fin.Seek(0, SeekOrigin.Begin);
                	
            }
			//make a object of the class 'SymmetricAlgorithm'
			SymmetricAlgorithm des ;
            if(radioButton1.Checked)
            {
            		//if the algorithm to be used is 'DES' then initilize the 'SymmetricAlgorithm' to 'DES_CSP'
            	des = new DES_CSP();
            		//set the variable to true because we are using 'DES' algorithm.
            	algo=true ;
            }
            else
            {
            	//if the algorithm to be used is 'RC2' then initilize the variable 'des' to 'RC2_CSP'
            	des=new RC2_CSP() ;
            	//set the key size of the algorithm to 40 bits since we are using a 40 bit key
            	des.KeySize=40 ;
            	
					//uncomment the below code to kind out the bits of keys supported by RC2 algorithm             	
            	/*KeySizes[] ks = des.LegalKeySizes ;
            	Console.WriteLine("Key Sizes Supported :") ;
            	Console.WriteLIne("Minimum Size:" +ks[0].MinSize) ;
            	Console.WriteLine("Skip size of key: "+ks[0].SkipSize) ;
            	  Console.WriteLine("Maximum Size: "+ks[0].MaxSize) ;
            	*/
            	
            		//set the bool variable to false since we are using the RC2 algorithm
            	algo=false ;
      
            }
            
            	//Make a object of the inner class 'StoreCryptoStream' we pass the bool variable
            	//containing the algotithm information and the FileStream 
            	StoreCryptoStream scs = new StoreCryptoStream(algo,fout);
            	
            	//make an object of the 'SymmetricStreamEncryptor' class and pass it the 'Key and the 'Vector'
            	//this starem helps to encrypt data according to the algorithm used
            	SymmetricStreamEncryptor sse = des.CreateEncryptor(symKey, symIV);
                
                // a little extra feature here to show how to compose crypto 
                // components that support ICryptoStream
                SHA1_CSP sha = new SHA1_CSP();
                
                // wire up the encryptor - hash - StoreCryptoStream
                sse.SetSink(sha);	
                sha.SetSource(sse);
                sha.SetSink(scs);	
                scs.SetSource(sha);
                
                //read from the file to encrypt 
                while (rdlen < totlen) {
                	//set the number of bytes read
                    len = fin.Read(bin,0,4096);
                    //write the encrypted data
                    sse.Write(bin,0,len);
                    //increase the size of bytes read
                    rdlen = rdlen + len;
                   
                }
                //free up the resources
                sse.CloseStream();
                
				fin.Close();
				fout.Close() ;
				statusBar1.Text="Encryption Compelete !" ;
		}
		catch(Exception e)
		{
			MessageBox.Show("An exception occured while encrypting :"+e.ToString()) ;
			statusBar1.Text="Error" ;
		}
	
	
	}
	
	///<summary>
	///	<para>
	///		This method decrypts the given input file in either of the 2 algorithms 'DES' or 'RC2'.
	///		Then it writes out the decrypted file
	///	</para>
	/// <para>
	///		This method first reads the input file to check to see if its encrypted by which
	///		algorithm. then it automatically decrypts the file. 
	///	</para>
	/// <para>
	///		It reads the first 8 bytes of the encrypted file to find the custom tag that we place
	/// 	while encrypting.
	///		If it finds "[saudes]" it uses the 'DES' algorithm to decrypt
	///		If it finds "[saurc2]" it uses the 'RC2' algorithm to decrypt
	/// </para>
	///</summary>

	private void DecryptData()
	{
			//try-catch block
		try{
				statusBar1.Text="Decrypting...." ;
						//open file streams to the input and outfiles 
				FileStream fin = new FileStream(opent.Text , FileMode.Open , FileAccess.Read) ;
				FileStream fout = new FileStream(savet.Text , FileMode.OpenOrCreate , FileAccess.Write) ;
				fout.SetLength(0) ;
				
						//a variable to check the validity of the input file
				bool filecheck = false ;
				
						//make a byte array of the size 64 bits
						//this is called the 'Buffer Size' of the algorithm
						//i.e. while encrypting blocks of the size 64bits are processed at a single time
						//later other blocks are of the same size.
						//we use 64bits because both 'DES' and 'RC2' both algorithms have 64 bit 'Buffer Size'

				byte[] bin = new byte[4096] ;
				long totlen = fin.Length ;
				long rdlen=8;
				int len ;
				// declare a object of type 'SymmetricAlgorithm'
				SymmetricAlgorithm des ;
						//set a tempory variable to length '8' (we use '8' since the size of the tag put in the file is 8 chars long)
				byte[] tag = new byte[8];
					//read the first 8 bytes from the input file to check which algrothim is used to encrypt the file
            	fin.Read(tag,0,tag.Length);
            	
            	if ((tag[0]==(byte)'[') && (tag[1]==(byte)'S') && (tag[2]==(byte)'a') && (tag[3]==(byte)'u')&&(tag[4]==(byte)'d')&&(tag[5]==(byte)'e')&&(tag[6]==(byte)'s')&&(tag[7]==(byte)']')) 
				{
					//If this is true then the 'DES' algorithm has been used to encrypt the file
								//so set the variable 'des' to new 'DES_CSP' 
					des = new DES_CSP() ;
								//set the variable to true since the file is encrypted
					filecheck=true ;
								//generate the Key and Vector from the given password
								//we send 'true' here since the algorithm used is 'DES' 
					GenerateKee(true) ;
				}
				else if ((tag[0]==(byte)'[') && (tag[1]==(byte)'S') && (tag[2]==(byte)'a') && (tag[3]==(byte)'u')&&(tag[4]==(byte)'r')&&(tag[5]==(byte)'c')&&(tag[6]==(byte)'2')&&(tag[7]==(byte)']')) 
				{
					//if this is true then the 'RC2' algorithm has been used to encrypt the file
								//so we set the variable 'des' to new 'RC2_CSP'
					des = new RC2_CSP() ;
								//set the keysize of the algorithm
					des.KeySize=40 ;
								//set thevariable to true since it is encrypted
					filecheck=true ;
								//generate the Key and Vector from the password given by the user
								//we pass false here since we are using 'RC2' algorithm 
					GenerateKee(false) ;
				}
				else 
				{
						MessageBox.Show("File Error !! File does not seem to be encrypted by SymEncryptor !!") ;
						//set the des to null so no encryption occurs
									des=null ;
						statusBar1.Text="Error ";
				}
						//if the file is encrypted then decrypt it
				if(filecheck){
								//create a object of the inner class 'StoreCryptoStream' 
								//we pass it the FileStream
					StoreCryptoStream scs = new StoreCryptoStream(fout);
								//make a object of this stream passing the Key and Vector
								//we use this strem since it helps us decrypt data from a
								//encrypted file
					SymmetricStreamDecryptor ssd = des.CreateDecryptor(symKey, symIV);
                		//set up the streams
                		ssd.SetSink(scs);
                		scs.SetSource(ssd);
                		//read the full encrypted file and decrypt
                		while (rdlen < totlen) {
                			//set the length of the number of bytes read
                    		len = fin.Read(bin,0,4096);
                    		//write the decrypted data 
                    		ssd.Write(bin,0,len);
                    		//increase the total read bytes variable
                    		rdlen = rdlen + len;
                    	}
                    	//free up the resources
               			ssd.CloseStream();
				}
				fin.Close();
				fout.Close();
				statusBar1.Text="Decryption Compelete" ;
	
		}
		catch(Exception e)
		{
			MessageBox.Show("An exception occured while decrypting :"+e.ToString()) ;
			statusBar1.Text="Error" ;
		}	
	}
		///<summary>
		///		This is a inner class which Implements the 'ICryptoStream' interface
		///		we write this class so that it will provide us with a custom stream
		///		which will write and read the way we want it to
		///</summary>

	public class StoreCryptoStream : ICryptoStream
	{
    //to byte arrays containing the bytes to be written while encrypting
    static byte[] tag1 = {(byte)'[',(byte)'S',(byte)'a',(byte)'u' ,(byte)'d' ,(byte)'e',(byte)'s' ,(byte)']'};
    static byte[] tag2=  {(byte)'[',(byte)'S',(byte)'a',(byte)'u' ,(byte)'r' ,(byte)'c',(byte)'2' ,(byte)']'};

    FileStream fs;
    
    ///<summary>
    ///		This is the constructor of this class
    /// 	it takes 2 parameters
    ///		1)a bool varable to indicate which algorithm has called it
    ///		if it 'true' then 'DES' has called it , if its 'false' then 
    ///		'RC2' has called it.
    ///		2)the FileStream to the output file
    ///</summary> 
    public StoreCryptoStream(bool algo, FileStream fout) 
    {
        fs = fout;
        
        if (algo){
        //we are here since the variable 'algo' is 'true' indicating that 'DES' algorithm is being used
        //hence it writes the byte array 'tag1' to the output file 
         	fs.Write(tag1,0,8);
         }
         else
         {
         //we are here since the variable 'algo' is 'false' indicating that 'RC2' algorithm is being used
        //hence it writes the byte array 'tag2' to the output file 

         	fs.Write(tag2,0,8) ;
         }
    }
    ///<summary>
    ///		This is another constructor which takes one parameter "FileStream"
    ///		It is called from the decrypting method
    ///</summary>
    public StoreCryptoStream(FileStream fout)
    {
    	fs=fout ;
    }
    
    //other methods which have to be implemented
    public virtual void CloseStream() {fs.Close();}
    public virtual void CloseStream(Object obj) {fs.Close();}
    public virtual void SetSink(ICryptoStream pstm) {}
    public virtual void  SetSource(CryptographicObject co) {}
    public virtual ICryptoStream  GetSink () {return null;}
    
    
    // Write routines just copy output to the target file
    public virtual void Write(byte[] bin)
    {
        int len = bin.GetLength(0);
        Write(bin, 0, len);
    }
    
    public virtual void Write(byte[] bin, int start, int len )
    {
        fs.Write(bin,start,len);
    }

    
    
    }//StoreCryptoStream class


    }//SymEncryptor class
}
