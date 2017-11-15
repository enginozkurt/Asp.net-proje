using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

namespace WebApplication15
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public string rawUrl = "";
        public static string ilce = "";
        public string menu = "";
        public string icerikText;
        public string refs = "";
        public string anahtar;
        public static string kAnahtar = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string dene = "";


            anahtar = "";

            anahtarGetir();

            if (!IsPostBack)
                if (Request.QueryString["ustmenuid"] != null && Request.QueryString["id"] != null)
                    altmenudoldur();
                else
                    menudoldur();

            if (Request.QueryString["id"] != null)
            {
                SqlDataAdapter ad = new SqlDataAdapter("select *from driSol where kod=@kod", dbBaglanti.sqlBaglanti("94.73.140.106", "vt"));
                ad.SelectCommand.Parameters.AddWithValue("@kod", Request.QueryString["id"]);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                string ust = "";
                if (dt.Rows[0]["tip"].ToString() != "0")
                {
                    SqlDataAdapter ad2 = new SqlDataAdapter("select *from driSol where kod=@id", dbBaglanti.sqlBaglanti("94.73.140.106", "vt"));
                    ad2.SelectCommand.Parameters.AddWithValue("@id", Request.QueryString["ustmenuid"].Replace(".htmx", ""));
                    DataTable dt2 = new DataTable();
                    ad2.Fill(dt2);
                    ust = dt2.Rows[0]["ad"].ToString();

                }
                refs = ust + " " + dt.Rows[0]["ad"].ToString().Replace("ººº", "");
                ilce = refs;
            }

            else
            {
                Random rnd = new Random();
                SqlDataAdapter ad = new SqlDataAdapter("select *from driSol ", dbBaglanti.sqlBaglanti("94.73.140.106", "vt"));

                DataTable dt = new DataTable();
                ad.Fill(dt);
                if (Request.QueryString["eID"] == null)
                {
                    refs = dt.Rows[rnd.Next(dt.Rows.Count)]["ad"].ToString().Replace("ººº", "");

                }
                else
                {
                    refs = ilce;
                }

            }

            if (Request.QueryString["eID"] != null && Request.QueryString["etiket"] != null)
            {
                SqlDataAdapter ad = new SqlDataAdapter("select *from driEtiketler where id=@id", dbBaglanti.con);
                ad.SelectCommand.Parameters.AddWithValue("@id", Request.QueryString["eID"].Replace(".htmlx", ""));
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dene = dt.Rows[0]["etiket"].ToString();
                kAnahtar = dene;
            }
            else
            {
                SqlDataAdapter ad = new SqlDataAdapter("select *from driEtiketler", dbBaglanti.con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                if (Request.QueryString["id"] == null)
                {
                    Random rnd = new Random();
                    dene = dt.Rows[rnd.Next(dt.Rows.Count)]["etiket"].ToString();
                }
                else
                {
                    dene = kAnahtar;
                }


            }
            icerikDoldur();
            Literal2.Text = icerikText.Replace("ªªª", refs + " " + dene.Replace(".html", "") + " " + anahtar);
            Page.Title = refs.Replace("ººº", "") + " " + anahtar + " " + dene.Replace(".html", "");
            Literal1.Text = refs + " " + anahtar;

            isimDegistir();

            resimGetir();
            etiketDoldur();
            rawUrl = Request.RawUrl;

            #region metalar
            HtmlHead head = (HtmlHead)Page.Header;
            string siteN = "dailyrentalistanbul.com";
            HtmlMeta m1 = new HtmlMeta();
            HtmlMeta m2 = new HtmlMeta();
            HtmlMeta m3 = new HtmlMeta();
            HtmlMeta m4 = new HtmlMeta();
            HtmlMeta m5 = new HtmlMeta();
            string[] keyEtiketler = etiketK();
            m1.Name = "description";
            m1.Content = refs + " " + anahtar + " " + keyEtiketler[0] + " " + keyEtiketler[1] + " " + keyEtiketler[2] + " " + keyEtiketler[3] + " in " + refs.ToLower() + ", " + dene + " " + siteN;



            m2.Name = "keywords";
            m2.Content = refs + " " + anahtar + ", "

                       + anahtar + " " + keyEtiketler[0] + ", "

                       + refs + " " + keyEtiketler[1] + ", "

                       + refs + " " + anahtar + " " + keyEtiketler[2] + ", "

                       + anahtar + " " + keyEtiketler[3] + " " + refs + ", "

                       + keyEtiketler[4] + " " + refs + " " + anahtar + ", "

                       + keyEtiketler[5] + " " + anahtar + " " + refs + ", "

                       + refs + " " + keyEtiketler[6] + " " + anahtar + ", "
                       + anahtar + " " + refs + " " + dene;


            m3.HttpEquiv = "Content-Type";
            m3.Content = "text/html; charset=iso-8859-9";

            m4.HttpEquiv = "Content-Language";
            m4.Content = "tr";

            m5.HttpEquiv = "Copyright";
            m5.Content = "Copyright © 2013 Daily Rental Istanbul";

            head.Controls.AddAt(3, m5);
            head.Controls.AddAt(2, m4);
            head.Controls.AddAt(4, m3);
            head.Controls.AddAt(5, m2);
            head.Controls.AddAt(6, m1);


            #endregion


        }

        private string[] etiketK()
        {
            SqlDataAdapter ad = new SqlDataAdapter("select *from driEtiketler", dbBaglanti.con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            string[] dizi = new string[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dizi[i] = dt.Rows[i]["etiket"].ToString();

            }

            return dizi;


        }



        private void etiketDoldur()
        {
            SqlConnection con = new SqlConnection(dbBaglanti.con);
            SqlDataAdapter ad = new SqlDataAdapter("select *from driEtiketler", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            rptEtiket.DataSource = dt;
            rptEtiket.DataBind();
        }

        private void isimDegistir()
        {
            SqlConnection con = new SqlConnection(dbBaglanti.con);
            string eskiIsim = "";
            string yeniIsim = "";

            SqlDataAdapter ad = new SqlDataAdapter("select * from driResimler", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);




            for (int i = 0; i < dt.Rows.Count; i++)
            {

                eskiIsim = dt.Rows[i]["ad"].ToString();

                if (refs != "")
                    yeniIsim = refs + "-" + anahtar + "-" + dt.Rows[i]["id"] + ".jpg";
                else
                    yeniIsim = anahtar + "-" + dt.Rows[i]["id"] + ".jpg";

                File.Move(Server.MapPath("images/") + eskiIsim, Server.MapPath("images/") + yeniIsim);

                SqlCommand cmd = new SqlCommand("update driResimler set ad=@ad where id=@id", con);
                cmd.Parameters.AddWithValue("@ad", yeniIsim);
                cmd.Parameters.AddWithValue("@id", dt.Rows[i]["id"].ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }






            // Literal3.Text = Server.MapPath("images/")+eskiIsim;

        }

        private void resimGetir()
        {
            SqlConnection con = new SqlConnection(dbBaglanti.con);

            SqlDataAdapter ad = new SqlDataAdapter("select *from driResimler", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);


            Repeater2.DataSource = dt;
            Repeater2.DataBind();

        }

        public string anahtarGetir()
        {
            anahtar = string.Empty;
            SqlDataAdapter adapter = new SqlDataAdapter("select * from bolum where kod=5", dbBaglanti.sqlBaglanti("94.73.140.106", "vt"));
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            anahtar = dt.Rows[0]["bolum"].ToString();
            return anahtar;
        }

        private void icerikDoldur()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from ana where kod=5", dbBaglanti.sqlBaglanti("94.73.140.106", "vt"));
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            icerikText = dt.Rows[0]["anayazi"].ToString();

        }

        private void altmenudoldur()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from driSol where tip=@tip", dbBaglanti.sqlBaglanti("94.73.140.106", "vt"));
            adapter.SelectCommand.Parameters.AddWithValue("@tip", Request.QueryString["id"]);
            adapter.Fill(dt);

            Repeater1.DataSource = dt;
            Repeater1.DataBind();

        }

        private void menudoldur()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from driSol where tip=0 order by sira asc", dbBaglanti.sqlBaglanti("94.73.140.106", "vt"));
            adapter.Fill(dt);


            Repeater1.DataSource = dt;
            Repeater1.DataBind();

        }

        //protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        Repeater rp = (Repeater)e.Item.FindControl("Repeater2");
        //        string ID = DataBinder.Eval(e.Item.DataItem, "kod").ToString();

        //        SqlDataAdapter adapter = new SqlDataAdapter("select *from driSol where tip=@tip",dbBaglanti.sqlBaglanti(".","vt"));
        //        adapter.SelectCommand.Parameters.AddWithValue("@tip",ID);
        //        DataTable dt = new DataTable();
        //        adapter.Fill(dt);
        //        rp.DataSource = dt;
        //        rp.DataBind();

        //    }
        //}


        public static string urlSeo(string id, string baslik)
        {

            string temp = "";
            temp = baslik.ToLower();
            temp = temp.Replace("-", "");
            //temp = temp.Replace(" ", "-");
            temp = temp.Replace("ç", "c");
            temp = temp.Replace("ş", "s");
            temp = temp.Replace("ö", "o");
            temp = temp.Replace("ü", "u");
            temp = temp.Replace("ğ", "g");
            temp = temp.Replace("ı", "i");
            temp = temp.Replace("/", "-");
            temp = temp.Replace("{", "");
            temp = temp.Replace("?", "");
            //temp = temp.Replace("+", "");
            temp = temp.Replace("&", "");
            temp = temp.Replace(".", "-");
            temp = temp.Replace(",", "");
            temp = temp.Replace("%", "");
            temp = temp.Replace("}", "");
            temp = temp.Replace("(", "");
            temp = temp.Replace(")", "");


            return id + "-" + temp + ".htmlx";

        }

        public static string menuSeo(string id, string tip, string ad)
        {


            string temp = "";
            temp = ad.ToLower();
            temp = temp.Replace("-", "");
            //temp = temp.Replace(" ", "-");
            temp = temp.Replace("ç", "c");
            temp = temp.Replace("ş", "s");
            temp = temp.Replace("ö", "o");
            temp = temp.Replace("ü", "u");
            temp = temp.Replace("ğ", "g");
            temp = temp.Replace("ı", "i");
            temp = temp.Replace("/", "-");
            temp = temp.Replace("{", "");
            temp = temp.Replace("?", "");
            //temp = temp.Replace("+", "");
            temp = temp.Replace("&", "");
            temp = temp.Replace(".", "-");
            temp = temp.Replace(",", "");
            temp = temp.Replace("%", "");
            temp = temp.Replace("}", "");
            temp = temp.Replace("(", "");
            temp = temp.Replace(")", "");
            temp = temp.Replace("ººº", "");

            return id + "-" + tip + "-" + temp + ".htm";

        }

    }
}