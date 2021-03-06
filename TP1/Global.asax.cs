﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace TP1
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
           List<long> Online = new List<long>();
           string DB_Path = Server.MapPath(@"~\App_Data\MainDB.mdf");
           Application["MainDB"] = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DB_Path + "';Integrated Security=True";
           Application["Online"] = Online;
        }
    }
}