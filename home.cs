using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileSplitter
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cafemanagement.Login l = new cafemanagement.Login();
            l.Show();
        }

        private void home_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cafemanagement.Registration r = new cafemanagement.Registration();
            r.Show();
        }
    }
}
