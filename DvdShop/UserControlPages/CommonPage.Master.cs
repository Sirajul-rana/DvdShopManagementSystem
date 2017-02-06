using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DvdShop
{
    public partial class CommonPage1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                profile.HRef = "~/UserControlPages/UserProfilePage.aspx?name=" + Cache["Username"];
            }
            
        }

        protected void SearchItem_TextChanged(object sender, EventArgs e)
        {
            var value = SearchItem.Text;

            var query = "SELECT [ID], [Title], [Cover] FROM DVD WHERE [Title]='" + value+"' OR [Cast]='"+value+ "' or [Category]=(Select id from Category where Name='"+value+"')";
            string connStr = ConfigurationManager.ConnectionStrings["DvdShop"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            
            Cache["READER"] = reader;
            Response.Redirect("SearchResultPage.aspx"); 
            conn.Close();
            
        }
    }
}