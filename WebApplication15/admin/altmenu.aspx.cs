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
    public partial class altmenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            doldur();

            if (!IsPostBack)
            {
                if (Request.QueryString["islem"] == "duzenle" && Request.QueryString["id"] != null)
                {
                    Duzenle();
                }
                if (Request.QueryString["islem"] == "sil" && Request.QueryString["id"] != null)
                {
                    Sil();
                }
                
                

            }
            

           
            

        }

        private void Sil()
        {
            SqlConnection con = new SqlConnection("Server=94.73.140.106;Database=vt;uid=vt;password=23daireler23;");
            con.Open();
            
            //if (con.State == ConnectionState.Open)
            //    Literal1.Text = "basarili";
            //else
            //    Literal1.Text = "basarisiz";


            SqlCommand cmd = new SqlCommand("delete driSol where kod = @kod", con);
            cmd.Parameters.AddWithValue("@kod", Request.QueryString["id"]);

           string sonuc = cmd.ExecuteNonQuery() >0 ? "islem basarili":"islem basarisiz";

            con.Close();
            doldur();
        }

        private void Duzenle()
        {
            Button1.Visible = false;
            btnGuncelle.Visible = true;
            SqlConnection con = new SqlConnection("Server=94.73.140.106;Database=vt;uid=vt;password=23daireler23;");
            SqlDataAdapter adapter = new SqlDataAdapter("select kod,ad,alan1,tip from driSol where kod=@kod", con);
            adapter.SelectCommand.Parameters.AddWithValue("@kod", Request.QueryString["id"]);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            TextBox1.Text = dt.Rows[0]["ad"].ToString();
            TextBox2.Text = dt.Rows[0]["alan1"].ToString();
        }

        private void doldur()
        {
            string tip = Request.QueryString["ustmenuid"];
            SqlConnection con = new SqlConnection("Server=94.73.140.106;Database=vt;uid=vt;password=23daireler23;");
            SqlDataAdapter adapter = new SqlDataAdapter("select kod,ad,alan1,tip,sira from driSol where tip=@tip", con);
            adapter.SelectCommand.Parameters.AddWithValue("@tip",tip);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            rptMArkaDuzenleSil.DataSource = dt;
            rptMArkaDuzenleSil.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=94.73.140.106;Database=vt;uid=vt;password=23daireler23;");
            SqlCommand cmd = new SqlCommand("insert into driSol (ad,alan1,tip) values(@ad,@alan1,@tip)", con);
            cmd.Parameters.AddWithValue("@ad", TextBox1.Text);
            cmd.Parameters.AddWithValue("@alan1", TextBox2.Text);
            cmd.Parameters.AddWithValue("@tip",Request.QueryString["ustmenuid"]);
            con.Open();
            string sonuc = cmd.ExecuteNonQuery() > 0 ? "islem basarili " : "islem basarisiz";
            Literal1.Text = sonuc;
            con.Close();
            doldur();

        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            btnGuncelle.Visible = false;
            Button1.Visible = true;


            SqlConnection con = new SqlConnection("Server=94.73.140.106;Database=vt;uid=vt;password=23daireler23;");
            SqlCommand cmd = new SqlCommand("update driSol set ad=@ad,alan1=@alan1 where kod=@kod", con);
            cmd.Parameters.AddWithValue("@ad", TextBox1.Text);
            cmd.Parameters.AddWithValue("@alan1", TextBox2.Text);
            cmd.Parameters.AddWithValue("@kod", Request.QueryString["id"]);
            con.Open();
            string sonuc = cmd.ExecuteNonQuery() > 0 ? "islem basarili" : "islem basarisiz";
            Literal1.Text = sonuc;


            doldur();
            TextBox1.Text = "menü adı ººº";
            TextBox2.Text = "aciklama";
        }
    }
}