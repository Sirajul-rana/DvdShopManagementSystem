using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DvdShop
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListCountry.DataSource = getCountryName();
                DropDownListCountry.DataBind();
                DropDownListCountry.Items.Insert(0,"Select Country");
            }
            
        }

        private List<String> getCountryName()
        {
            List<String> list = new List<string>();

            foreach (CultureInfo info in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo infoRegion = new RegionInfo(info.LCID);
                if (!list.Contains(infoRegion.EnglishName))
                {
                    list.Add(infoRegion.EnglishName);
                    list.Sort();
                }
                   
            }   

            return list; 
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            var name = Request.Form["name"];
            var email = Request.Form["email"];
            var address = Request.Form["address"];
            var phone = Request.Form["phone"];
            var gender = DropDownListGender.SelectedValue;
            var city = Request.Form["city"];
            var country = DropDownListCountry.SelectedValue;
            var dob = Request.Form["dob"];
            var type = "user";
            var username = Request.Form["username"];
            var password = Request.Form["password"];

            var query1 = "insert into Users(Name, Email, Address, Phone, Gender, City, Country, Type, Username, Password, Dateofbirth) values ('"+ @name +"', '"+ @email + "', '"+ @address + "', '"+ @phone + "', '"+ @gender + "', '"+ @city + "', '"+ @country + "', '"+ @type + "', '"+ @username + "', '"+ @password + "','"+@dob+"')";

            var connStr = ConfigurationManager.ConnectionStrings["DvdShop"].ConnectionString;
            var conn = new SqlConnection(connStr);
            var cmd = new SqlCommand(query1, conn);

            conn.Open();
            Cache["NameReg"] = name;
            if (cmd.ExecuteNonQuery() == 1)
            {
                Response.RedirectPermanent("RegistrationConfirmPage.aspx");
                conn.Close();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('Please recheck your information')", true);
            }
            
            
        }
    }
}