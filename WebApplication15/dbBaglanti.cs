using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication15
{
    public class dbBaglanti
    {
        public static string con = "Server=94.73.140.106;Database=vt;uid=vt;password=23daireler23;";

        public static SqlConnection sqlBaglanti(string serverName,string databaseName,string userName,string Password)
        {
            SqlConnection con = new SqlConnection("server="+serverName+"; database ="+databaseName+"; uid="+userName+"; password="+Password+";");

            return con;
        }

        public static SqlConnection sqlBaglanti(string serverName, string databaseName)
        {
            SqlConnection con = new SqlConnection("server=" + serverName + "; database =" + databaseName + "; uid=vt;password=23daireler23; ");

            return con;
        }

    }
}