using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DvdShop
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
            }
        }

        protected void signin_Click(object sender, EventArgs e)
        {
            var username = Request.Form["username"];
            var password = Request.Form["password"];
            var user = new StringBuilder();
            string loginQuery = "select * from Users where Username = '" + @username + "' and Password= '"+ @password + "'";
            string connStr = ConfigurationManager.ConnectionStrings["DvdShop"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(loginQuery, conn);
            

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetString(8) == "Member")
                {
                    Cache["Username"] = reader.GetString(9).ToString();
                    Response.Redirect((user.Append(@"UserControlPages/UserPage.aspx?un="+reader.GetString(9)).ToString()));
                    conn.Close();
                }
                else if (reader.GetString(8) == "Admin")
                {
                    Response.Redirect("UserControlPages/UserPage.aspx");
                    conn.Close();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
            }
        }
    }
}