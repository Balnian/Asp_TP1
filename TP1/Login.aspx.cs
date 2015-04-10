using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
    public partial class Login : System.Web.UI.Page
    {
        Users Usager;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"]!=null)
            {
                
                LoginInfo Linfo = new LoginInfo((string)Application["MainDB"], this);
                Linfo.ID_U = Usager.ID;
                Linfo.LoginDate = DateTime.Parse(Session["LoginDate"].ToString());
                Linfo.LogOutDate = DateTime.Now;
                Linfo.IpAdresse = Request.UserHostAddress.ToString();
                Linfo.Insert();
                Session["Users"] = null;
                Response.Redirect("Login.aspx");
            }
            if (Page.IsPostBack)
            { 
                Usager = new Users((string)Application["MainDB"], this);
               if(Usager.SelectByFieldName("UserName",TB_UserName.Text))
               {
                   if (Usager.SelectByFieldName("PassWord", TB_PassWord.Text))
                   {
                       Usager.SetUserInfo(TB_UserName.Text);
                       Session["User"] = Usager;
                       ((List<long>)Application["Online"]).Add(Usager.ID);
                       Response.Redirect("Profil.aspx");
                   }
               }
              
            }
        }
        
    }
}