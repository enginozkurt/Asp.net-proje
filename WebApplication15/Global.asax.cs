using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication15
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string dosyayolu = Request.RawUrl;
            if (System.IO.Path.GetExtension(dosyayolu) == ".htmlx")
            {
                string[] path = System.IO.Path.GetFileName(dosyayolu).Split('-');
                Context.RewritePath("~/default.aspx", "", "eId=" +path[1] + "&etiket=" + path[0].Trim(), true); 
                
            }
            else if (System.IO.Path.GetExtension(dosyayolu) == ".htm")
            {
                string[] path = System.IO.Path.GetFileName(dosyayolu).Split('-');
                Context.RewritePath("~/default.aspx", "", "id=" +path[0] + "&ustmenuid=" + path[1]+"&ad="+path[2], true);
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}