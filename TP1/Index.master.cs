using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
    public partial class Index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users usager;
            if (Session["User"] == null)
                Response.Redirect("Login.aspx");
            else
            {
                usager = (Users)Session["User"];
                Lbl_Name.Text = usager.UserName;
                Lbl_FullName.Text = usager.FullName;
            }
        }
    
        
    }
}