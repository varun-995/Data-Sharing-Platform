using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;

namespace cafemanagement
{
    public partial class Login : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cloud"].ConnectionString);
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Required");
            }
            else if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Required");
            }
          
            else 
            {
                
                cn.Open();
                SqlCommand cmd = new SqlCommand("select [username],password,Emailid from [registration] where [username]='" + textBox1.Text + "' and password='" + textBox2.Text + "'", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (textBox1.Text == dr[0].ToString() || textBox2.Text == dr[1].ToString())
                    {
                        
                        Random rnd = new Random();
                        int otp = rnd.Next();                        
                        SendEmail(dr[2].ToString(), "Your Otp", Convert.ToString(otp));
                        s.insert("insert into otp(otp,name) values('" + otp + "','" + textBox1.Text + "')");
                        MessageBox.Show("Kindly Check your Mail for OTP");
                        button2.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
                cn.Close();
                
            }
        }

        save s = new save();
        
        private void Login_Load(object sender, EventArgs e)
        {

        }
        protected string SendEmail(string toAddress, string subject, string body)
        {
            string result = "Message Sent Successfully..!!";
            // string senderID = "srishti.sharma269@gmail.com";// use sender’s email id here..
            // const string senderPassword = "!l0venaman"; // sender password here…

            string senderID = "varunnn.1995@gmail.com";
            const string senderPassword = "9968150069";

            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here…
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                    Timeout = 30000,
                };
                MailMessage message = new MailMessage(senderID, toAddress, subject, body);
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = "Error sending email.!!!";
            }
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select name,otp from otp where [name]='" + textBox1.Text + "' and otp='" + textBox3.Text + "'", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (textBox1.Text == dr[0].ToString() || textBox3.Text == dr[1].ToString())
                {
                    FileSplitter.Master e1 = new FileSplitter.Master(textBox1.Text);
                    e1.Show();
                    this.Hide();                
                   
                    s.insert("delete from otp where name='"+textBox1.Text+"'");
                    
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
            cn.Close();
        }
    }
}
