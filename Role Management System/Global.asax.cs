using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace Role_Management_System
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AuthenticateWebMatrix();
        }

        private void AuthenticateWebMatrix()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("Auth", "Users", "UserID", "Username", true);
                //WebSecurity.CreateUserAndAccount("admin", "admin33");
                //Roles.CreateRole("Admin");
                //Roles.CreateRole("Manager");
                //Roles.CreateRole("User");
                //Roles.AddUserToRole("admin", "Admin");
            }
        }
    }
}
