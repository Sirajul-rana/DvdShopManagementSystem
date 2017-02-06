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
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadProfile();
            }
        }

        private void LoadProfile()
        {
            var name = Cache["Username"];
            var htmlString = new StringBuilder();
            string query = @"SELECT * FROM Users WHERE [Username]='" + name + "'";
            var connectionString =
                ConfigurationManager.ConnectionStrings["DvdShop"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                htmlString.AppendFormat(@"
               <legend style = ""text-align: left""> {0}</legend>
                 <table class=""table"">
                    <tr>
                        <td class=""auto-style1"">Address :</td>
                        <td class=""auto-style2"">
                            {1}
                        </td>
                    </tr>
                    <tr>
                        <td class=""auto-style1"">Phone :</td>
                        <td class=""auto-style2"">
                            {2}
                        </td>
                    </tr>
                    <tr>
                        <td class=""auto-style1"">Email :</td>
                        <td class=""auto-style2"">
                            {3}
                        </td>
                    </tr>
                    <tr>
                        <td class=""auto-style1""></td>
                        <td class=""auto-style2""></td>
                    </tr>
                    <tr>
                        <td class=""auto-style1"">DOB :</td>
                        <td class=""auto-style2"">
                            {4}
                        </td>
                    </tr>
                    <tr>
                        <td class=""auto-style1"">Sex :</td>
                        <td class=""auto-style2"">
                            {5}
                        </td>
                    </tr>
                    <tr>
                        <td class=""auto-style1"">City :</td>
                        <td class=""auto-style2"">
                            {6}
                        </td>
                    </tr>
                    <tr>
                        <td class=""auto-style1"">Country :</td>
                        <td class=""auto-style2"">
                            {7}
                        </td>
                    </tr>
                </table>", reader.GetString(1), reader.GetString(3), reader.GetString(4), reader.GetString(2), Convert.ToDateTime(reader["Dateofbirth"]).ToString("dd/MM/yyyy"),
                reader.GetString(5), reader.GetString(6), reader.GetString(7));

            }
            Row.InnerHtml = htmlString.ToString();
        }

    }
}