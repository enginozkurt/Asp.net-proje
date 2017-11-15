using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication15.admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            doldur();
        }

        private void doldur()
        {
            SqlConnection con = new SqlConnection("Server=94.73.140.106;Database=vt;uid=vt;password=23daireler23;");
            SqlDataAdapter ad = new SqlDataAdapter("select anayazi from Ana where kod=5 ", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            TextBox1.Text = dt.Rows[0]["anayazi"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=94.73.140.106;Database=vt;uid=vt;password=23daireler23;");
            SqlCommand cmd = new SqlCommand("update ana set anayazi=@anayazi where kod=5", con);
            cmd.Parameters.AddWithValue("@anayazi",TextBox1.Text);
            con.Open();
            string sonuc=cmd.ExecuteNonQuery()>0 ? "islem basarili":"islem basarisiz";
            con.Close();
            Literal1.Text = sonuc;
            doldur();
        }
    }
}