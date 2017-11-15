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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            etiketDoldur();
            if(!IsPostBack)
            if (Request.QueryString["id"]!=null&&Request.QueryString["islem"]=="duzenle")
            {
                TextBox1.Text = HttpUtility.UrlEncode(Request.QueryString["etiket"]);
                btnEkle.Visible = false;
                btnGuncelle.Visible = true;
            }
            else if (Request.QueryString["id"]!=null&&Request.QueryString["islem"]=="sil")
            {
                sil();

            }
        }

        private void sil()
        {
            SqlConnection con = new SqlConnection(dbBaglanti.con);
            SqlCommand cmd = new SqlCommand("delete driEtiketler where id=@id",con);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("etiketler.aspx");
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(dbBaglanti.con);
            SqlCommand cmd = new SqlCommand("insert into driEtiketler (etiket) values(@etiket)", con);
            cmd.Parameters.AddWithValue("@etiket",TextBox1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("etiketler.aspx");
        }

        private void etiketDoldur()
        {
            SqlConnection con = new SqlConnection(dbBaglanti.con);
            SqlDataAdapter ad = new SqlDataAdapter("select *from driEtiketler", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(dbBaglanti.con);
            SqlCommand cmd = new SqlCommand("update driEtiketler set etiket=@etiket where id=@id", con);
            cmd.Parameters.AddWithValue("@etiket",TextBox1.Text);
            cmd.Parameters.AddWithValue("@id",Request.QueryString["id"]);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("etiketler.aspx");
        }
    }
}