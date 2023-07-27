using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Serilog;

namespace EmployeeManager
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Logger Configuration
            var path = Server.MapPath("~");
            Log.Logger = new LoggerConfiguration()
               .WriteTo.File(path + @"\log.txt")
               .CreateLogger();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Log unhandled exceptions
            Exception ex = Server.GetLastError();
            Log.Error(ex + "\n\n", "Unhandled Exception");
        }
    }
}