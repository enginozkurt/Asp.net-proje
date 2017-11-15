using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication15.admin
{
    public partial class giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "admin" && TextBox2.Text == "arsal")
            {
                Session["giris"] = "ok";
                Response.Redirect("default.aspx");
            }
            else
                Literal1.Text = "Kullanici adi ya da sifre hatali.";
        }
    }
}