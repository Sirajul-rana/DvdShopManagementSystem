using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DvdShop.UserControlPages
{
    public partial class RestPasswordPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            var username = Username.Text;
            
            var password = passw.Text;
            var user = new StringBuilder();
            string loginQuery = "select * from Users where Username = '" + @username + "'";
            string connStr = ConfigurationManager.ConnectionStrings["DvdShop"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(loginQuery, conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string updatePass = "UPDATE Users SET Password = '" + password + "'WHERE Username = '" + username + "' ";
                SqlConnection conn2 = new SqlConnection(connStr);
                SqlCommand cmd2 = new SqlCommand(updatePass, conn2);
                conn2.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                Cache["NamePass"] = reader.GetString(1);
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('"+ reader.GetString(1) + ", your password has been changed.')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username')</script>");
            }
        }
    }
}