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
    public partial class DvdDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadDvdDetail();
            }
        }

        private void LoadDvdDetail()
        {
            var htmlString = new StringBuilder();
            using (var dataFromDatabase = GetDataFromDatabase())
            {
                foreach (DataRow row in dataFromDatabase.Rows)
                {
                    htmlString.Append(@"
<table>
    <tr>
        <td>");
             htmlString.AppendFormat(@"<img src = ""{0}"" width = ""300px"" height = ""400px"" />
        </td>
        <td style = ""padding-left: 5px"">
            <table>
                <tr>
                    <td><h2> {1} </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p> {2} </p>
                    </td>
                </tr>
                <tr>
                   <td>
                      <p class=""text-primary"" style=""font-size: 14px;""> {3}</p>
                   </td>
                </tr>
                <tr>
                    <table>
                        <tr>
                            <td>
                                <p>Director:</p>
                            </td>
                            <td>
                                <p>{4}</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>Cast:</p>
                            </td>
                            <td>
                                <p>{5}</p>
                            </td>
                         </tr>
                         <tr>
                            <td>
                                <p>Realize Date:</p>
                            </td>
                            <td>
                                <p>{6}</p>
                            </td>
                         </tr>
                    </table>
            </table>
        </td>
    </tr>
</table>", row.Field<string>(5), row.Field<string>(1), row.Field<string>(10), row.Field<string>(9),
row.Field<string>(2), row.Field<string>(3), row.Field<DateTime>(4).ToString("yy-MM-dd"));

                }
                Row.InnerHtml = htmlString.ToString();
            }
        }

        private DataTable GetDataFromDatabase()
        {
            string id = Request.QueryString["id"];
            var loginQuery = "SELECT DVD.*, Category.Name FROM DVD INNER JOIN Category ON DVD.Category=Category.ID AND DVD.ID =" + id + "";
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