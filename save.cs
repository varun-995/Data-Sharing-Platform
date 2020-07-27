using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Generic;



public class save
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cloud"].ConnectionString);

    public void insert(string query)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void dept(string query,System.Windows.Forms. ComboBox wardcomboBox)
    {
        //con.Open();
        //SqlCommand cmd = new SqlCommand(query, con);

        //SqlDataReader dr = cmd.ExecuteReader();
        //while (dr.Read())
        //{
        //    wardcomboBox.Items.Add(dr[0].ToString());
        //}
        //con.Close();
    }
    public void displaymaxid(string id)
    {


        //string query = "select max(id) from [UserRegistration]";
        //SqlDataAdapter sda = new SqlDataAdapter(query, con);
        //DataTable dt = new DataTable();
        //sda.Fill(dt);
        //if (dt.Rows.Count > 0)
        //{
        //    string maxid = dt.Rows[0][0].ToString();
        //    if (maxid == "")
        //    {

        //        int tempcount = 2;


        //        id = tempcount.ToString();

        //    }
        //    else
        //    {

        //        int countid = int.Parse(maxid.ToString());
        //        countid = countid + 1;
        //        id = countid.ToString();
        //    }
        //}
    }


}
