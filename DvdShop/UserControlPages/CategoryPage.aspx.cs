using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DvdShop
{
    public partial class CategoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulateWithDvds();
            }
            
        }

        private void PopulateWithDvds()
        {
            var htmlString = new StringBuilder();
            using (var dataFromDatabase = GetDataFromDatabase())
            {
                var showData = Request.QueryString["Category"];
                if (showData == "Bangla")
                {
                    htmlString.Append(@"<div><h3 id=""addedd"">Bangla Movies</h3></div>");
                }
                else if (showData == "English")
                {
                    htmlString.Append(@"<div><h3 id=""addedd"">English Movies</h3></div>");
                }
                else if (showData == "Hindi")
                {
                    htmlString.Append(@"<div><h3 id=""addedd"">Hindi Movies</h3></div>");
                }
                else if (showData == "Animated")
                {
                    htmlString.Append(@"<div><h3 id=""addedd"">Animated Movies</h3></div>");
                }
                else if (showData == "Comedy")
                {
                    htmlString.Append(@"<div><h3 id=""addedd"">Comedy Movies</h3></div>");
                }
                else if (showData == "Horror")
                {
                    htmlString.Append(@"<div><h3 id=""addedd"">Horror Movies</h3></div>");
                }
                else if (showData == "All")
                {
                    htmlString.Append(@"<div><h3 id=""addedd"">All Movies</h3></div>");
                }

                foreach (DataRow row in dataFromDatabase.Rows)
                {
                    htmlString.Append(@"
<div class=""col-md-4 portfolio-item"">
    <a href=""#"">
        <img class=""img-responsive"" width=""150""");
                    htmlString.AppendFormat(@"src=""{0}"" alt="" "" />
    </a>
    <h3>", row.Field<string>(2));
                    htmlString.AppendFormat(@"
        <a href=""DvdDetails.aspx?id={0}"">{1}
", row.Field<int>(0), row.Field<string>(1));
                    htmlString.Append(@"
        </a>
    </h3>
</div>
");
                }
                Row.InnerHtml = htmlString.ToString();
            }
        }

        private DataTable GetDataFromDatabase()
        {
            var showData = Request.QueryString["Category"]; 
            var loginQuery="";
            if (showData == "Bangla")
            {
                loginQuery = "SELECT [ID], [Title], [Cover] FROM DVD WHERE [Class]='Bangla'";
            }
            else if (showData == "English")
            {
                loginQuery = "SELECT [ID], [Title], [Cover] FROM DVD WHERE [Class]='English'";
            }
            else if (showData == "Hindi")
            {
                loginQuery = "SELECT [ID], [Title], [Cover] FROM DVD WHERE [Class]='Hindi'";
            }
            else if (showData == "Animated")
            {
                loginQuery = "SELECT [ID], [Title], [Cover] FROM DVD WHERE [Class]='Animated'";
            }
            else if (showData == "Comedy")
            {
                loginQuery = "SELECT [ID], [Title], [Cover] FROM DVD WHERE [Class]='Comedy'";
            }
            else if (showData == "Horror")
            {
                loginQuery = "SELECT [ID], [Title], [Cover] FROM DVD WHERE [Class]='Horror'";
            }
            else if (showData == "All")
            {
                loginQuery = "SELECT [ID], [Title], [Cover] FROM DVD";
            }
            
            var connectionString = 
                ConfigurationManager.ConnectionStrings["DvdShop"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var sqlCommand = new SqlCommand(loginQuery, connection);
            try
            {
                var resultFromDatabase = sqlCommand.ExecuteReader();
                var categoryProducts = new DataTable();
                categoryProducts.Load(resultFromDatabase);
                return categoryProducts;
            }
            catch (Exception)
            {
                return null;
            }                        
        }
    }
}