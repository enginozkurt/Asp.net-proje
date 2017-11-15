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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                if (Request.QueryString["id"]!=null)
                {
                    resimSil();

                }
            }
            resimDoldur();
        }

        private void resimSil()
        {
            System.IO.File.Delete(Server.MapPath("images/") + resimSec());
            SqlConnection con = new SqlConnection(dbBaglanti.con);
            SqlCommand cmd = new SqlCommand("delete driResimler where id=@id",con);
            cmd.Parameters.AddWithValue("@id",Request.QueryString["id"]);
            con.Open();
            string sonuc = cmd.ExecuteNonQuery() > 0 ? "islem basarili." : "islem basarisiz.";
            con.Close();

            resimDoldur();

        }

        private string resimSec()
        {
            string isim = "";
            SqlDataAdapter ad = new SqlDataAdapter("select ad from driResimler where id=@id", dbBaglanti.con);
            ad.SelectCommand.Parameters.AddWithValue("@id",Request.QueryString["id"]);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return isim;
        }

        private void resimDoldur()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select *from driResimler", dbBaglanti.sqlBaglanti("94.73.140.106", "vt", "vt", "23daireler23"));
            adapter.Fill(dt);
            rptResimler.DataSource = dt;
            rptResimler.DataBind();
        }

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string isim = FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath("~/images/")+FileUpload1.FileName);
                SqlConnection con = new SqlConnection("Server=94.73.140.106;Database=vt;uid=vt;password=23daireler23;");
                SqlCommand cmd = new SqlCommand("insert into driResimler (ad) values (@ad)", con);
                cmd.Parameters.AddWithValue("@ad",isim);
                con.Open();
                string sonuc = cmd.ExecuteNonQuery() > 0 ? "islem basarili" : "islem basarisiz";
                con.Close();
                resimDoldur();
                            }
        }
    }
}