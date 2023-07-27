using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManager
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private readonly SqlConnection conn;
        public WebForm3()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insertEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", TextBox_Name.Text);
                cmd.Parameters.AddWithValue("@Gender", DropDownList_Gender.SelectedValue);
                cmd.Parameters.AddWithValue("@Age", TextBox_Age.Text);
                cmd.Parameters.AddWithValue("@Address", TextBox_Address.Text);
                cmd.Parameters.AddWithValue("@Salary", TextBox_Salary.Text);

                conn.Open();
                int x = cmd.ExecuteNonQuery();
                if (x == 1)
                {
                    // if success redirect with success message
                    Session["success"] = "Successfully Created";
                    Response.Redirect("index.aspx",false);
                }
                else
                {
                    // if failed redirect with failed message
                    Session["error"] = "Something went wrong!";
                    Response.Redirect("index.aspx", false);
                }
            }
            catch (Exception ex)
            {
                string methodName  = MethodBase.GetCurrentMethod().Name;
                string pageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                Log.Error(ex + "\n\n", $"Error - {methodName} method at {pageName} Page.");
            }
            finally { conn.Close(); }
        }
    }
}