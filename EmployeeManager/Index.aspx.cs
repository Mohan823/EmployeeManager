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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private readonly SqlConnection conn;
        public WebForm1()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["success"] != null)
                    {
                        Label_Success.Text = Session["success"] as string;
                        Session.Remove("success");
                    }
                    else if (Session["error"] != null)
                    {
                        Label_Error.Text = Session["error"] as string;
                        Session.Remove("error");
                    }

                    SqlCommand cmd = new SqlCommand("sp_fetchEmployees", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    GridView.DataSource = dataTable;
                    GridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                string methodName = MethodBase.GetCurrentMethod().Name;
                string pageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                Log.Error(ex + "\n\n", $"Error - {methodName} method at {pageName} Page.");
            }
        }

        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Based on selection index retrive its id
            string id  = GridView.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("Edit.aspx?id=" + Server.UrlEncode(id), false);
        }

        protected void GridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            // Based on selection index retrive its id
            string id = GridView.Rows[e.NewSelectedIndex].Cells[0].Text;
            Response.Redirect("Detail.aspx?id=" + Server.UrlEncode(id), false);
        }

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Based on selection index retrive its id
            string id = GridView.Rows[e.RowIndex].Cells[0].Text;
            Response.Redirect("Delete.aspx?id=" + Server.UrlEncode(id), false);
        }
    }
}