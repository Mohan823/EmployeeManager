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
    public partial class WebForm5 : System.Web.UI.Page
    {
        private readonly SqlConnection conn;
        public WebForm5()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = "Delete Employee ?"; 
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] == null)
                    {
                        Response.Redirect("index.aspx", false);
                    }

                    string employeeId = Server.UrlDecode(Request.QueryString["id"]);
                    SqlCommand cmd = new SqlCommand("sp_fetchEmployee", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", employeeId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    Label_Id.Text = dataTable.Rows[0]["Id"].ToString();
                    Label_Name.Text = dataTable.Rows[0]["Name"].ToString();
                    Label_Gender.Text = dataTable.Rows[0]["Gender"].ToString();
                    Label_Age.Text = dataTable.Rows[0]["Age"].ToString();
                    Label_Salary.Text = dataTable.Rows[0]["Salary"].ToString();
                    Label_Address.Text = dataTable.Rows[0]["Address"].ToString();
                }
            }
            catch (Exception ex)
            {
                string methodName = MethodBase.GetCurrentMethod().Name;
                string pageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                Log.Error(ex + "\n\n", $"Error - {methodName} method at {pageName} Page.");
            }
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("index.aspx", false);
                }

                string employeeId = Server.UrlDecode(Request.QueryString["id"]);

                SqlCommand cmd = new SqlCommand("sp_deleteEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", employeeId);

                conn.Open();
                int x = cmd.ExecuteNonQuery();
                if (x == 1)
                {
                    // if success redirect with success message
                    Session["success"] = "Successfully Deleted";
                    Response.Redirect("index.aspx", false);
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
                string methodName = MethodBase.GetCurrentMethod().Name;
                string pageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                Log.Error(ex + "\n\n", $"Error - {methodName} method at {pageName} Page.");
            }
            finally { conn.Close(); }
        }
    }
}