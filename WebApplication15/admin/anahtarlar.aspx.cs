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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            doldur();
            if (!IsPostBack)
            {
                if (Request.QueryString["islem"] == "duzenle" && Request.QueryString["id"] != null)
                {
                    duzenle();
                }

                
            }
        }

        private void Sil()
        {
            throw new NotImplementedException();
        }

        private void duzenle()
        {
            rptMArkaDuzenleSil.Visible = false;
            Panel1.Visible = true;
            SqlConnection con = new SqlConnection("Server=94.73.140.106;Database=vt;uid=vt;password=23daireler23;");
            SqlDataAdapter ad = new SqlDataAdapter("select *from bolum where kod=5", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            TextBox1.Text = dt.Rows[0]["kod"].ToString();
            TextBox2.Text = dt.Rows[0]["bolum"].ToString();
        }

        private void doldur()
        {
            SqlConnection con = new SqlConnection("Server=94.73.140.106;Database=vt;uid=vt;password=23daireler23;");
            SqlDataAdapter ad = new SqlDataAdapter("select *from bolum where kod=5", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            rptMArkaDuzenleSil.DataSource = dt;
            rptMArkaDuzenleSil.DataBind();
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=94.73.140.106;Database=vt;uid=vt;password=23daireler23;");
            SqlCommand cmd = new SqlCommand("update bolum set kod=@kod,bolum=@bolum where kod=@kod", con);
            cmd.Parameters.AddWithValue("@kod",TextBox1.Text);
            cmd.Parameters.AddWithValue("@bolum",TextBox2.Text);
            
            con.Open();

            string sonuc = cmd.ExecuteNonQuery() > 0 ? "islem basarili" : "islem basarisiz";
            //Literal1.Text = sonuc;
            con.Close();
            rptMArkaDuzenleSil.Visible = true;
            Panel1.Visible = false;
            doldur();
        }
    }
}