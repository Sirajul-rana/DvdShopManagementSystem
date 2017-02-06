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
    public partial class UserPage : System.Web.UI.Page
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
            Session["Name"] = Request.QueryString["name"];
            var htmlString = new StringBuilder();
            using (var dataFromDatabase = GetDataFromDatabase())
            {
                htmlString.Append(@"<div><h3 id=""addedd"">Recently Added</h3></div>");
                foreach (DataRow row in dataFromDatabase.Rows)
                {
                    htmlString.Append(@"
<div class=""col-md-4 portfolio-item"">
    <a href=""#"">
        <img class=""img-responsive"" width=""150""");
                    htmlString.AppendFormat(@"src=""{0}"" alt="" "" />
    </a>
    <h3>", row.Field<string>(5));
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

        private static DataTable GetDataFromDatabase()
        {
            const string loginQuery = "SELECT Top 9 * FROM DVD ORDER BY Time DESC";
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