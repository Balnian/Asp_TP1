﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
    public partial class ThreadsManager : System.Web.UI.Page
    {
        Users user;
        List<CheckBox> cblist;
        List<long> idlist = new List<long>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                user = (Users)Session["User"];
                user.SelectAll();
              cblist = user.MakeAGridForThread(Pn_Users);
            }
        }
        protected void BTN_Create_Click(object sender, EventArgs e)
        {
              if (Session["User"] != null)
            {
                user = (Users)Session["User"];
                Threads thread = new Threads((string)Application["MainDB"], this);
                
                foreach (CheckBox cb in cblist)
                {
                    if (cb.Checked)
                    {
                        idlist.Add(long.Parse(cb.ID));
                    }               
                }

                thread.creator = user.UserName;
                thread.title = TB_ThreadName.Text;
                thread.date = DateTime.Now.ToString();
                thread.Insert();
                //reste a implanter la classe threadaccess  
            }

        }

    }
}