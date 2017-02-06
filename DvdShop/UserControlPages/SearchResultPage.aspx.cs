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

namespace DvdShop.UserControlPages
{
    public partial class SearchResultPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                this.LoadSearchResult();
        }

        private void LoadSearchResult()
        {
            var dvdId = new DataTable();
            dvdId.Load((SqlDataReader)Cache["READER"]);
            var htmlString = new StringBuilder();
            htmlString.Append(@"<div><h3 id=""addedd"">Search results:</h3></div>");
            if(dvdId.Rows.Count == 0)
            {
                htmlString.Append(@"<div><center><h3 id=""result"">Search result is empty.</h3></center></div>");
                Row.InnerHtml = htmlString.ToString();
            }
            else
            {
                using (dvdId)
                {
                    foreach (DataRow row in dvdId.Rows)
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
        }
    }
}

