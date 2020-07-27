using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace cafemanagement
{
    public partial class Registration : Form, IDisposable
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cloud"].ConnectionString);
      
        save s = new save();
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int c = 1;
         
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Required");
                c = 0;
            }
             if (textBox2.Text == string.Empty)
             {
                 c = 0;
                errorProvider1.SetError(textBox2, "Required");
            }
            else if (textBox3.Text == string.Empty)
            {
                errorProvider1.SetError(textBox3, "Required");
            }
             if (textBox4.Text == string.Empty)
             {
                 c = 0;
                errorProvider1.SetError(textBox4, "Required");
            }
             if (textBox3.Text.Length < 10)
             {
                 c = 0;
                errorProvider1.SetError(textBox3, "Required");
            }
            if(c==1)
            {

                string query = "select * from [Registration] where [Username]='" + textBox1.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("already exixst");

                }
                if(dt.Rows.Count==0)
                {




                    s.insert("insert into Registration([Username],[Password],[Emailid],[Contactno]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "')");
                    MessageBox.Show("information saved successfully");
                    s = null;

                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;

                }

            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
         && !char.IsDigit(e.KeyChar)
         && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (rEMail.IsMatch(textBox4.Text) == true)
            {


            }
            else
            {
                MessageBox.Show("invalid email");
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            
        }
    }
}
