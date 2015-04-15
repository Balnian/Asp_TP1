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
                Linfo.ID_U = ((Users)Session["User"]).ID;
                Linfo.LoginDate = (DateTime)Session["LoginDate"];
                Linfo.LogOutDate = DateTime.Now;
                Linfo.IpAdresse = Request.UserHostAddress.ToString();
                Linfo.Insert();
                ((List<long>)Application["Online"]).Remove(((Users)Session["User"]).ID);
                Session["User"] = null;
                Linfo.EndQuerySQL();
                Response.Redirect("Login.aspx");               
            }
            if (Page.IsPostBack)
            { 
                Usager = new Users((string)Application["MainDB"], this);
               if(Usager.SelectByFieldName("UserName",TB_UserName.Text))
               {
                   if (Usager.PassWordVerif(TB_UserName.Text,TB_PassWord.Text))
                   {
                       Usager.SetUserInfo(TB_UserName.Text);
                       Session["User"] = Usager;
                       ((List<long>)Application["Online"]).Add(Usager.ID);
                       Session["LoginDate"] = DateTime.Now;
                       Usager.EndQuerySQL();
                       Response.Redirect("Profil.aspx");
                   }
               }
              
            }
        }
        
    }
}