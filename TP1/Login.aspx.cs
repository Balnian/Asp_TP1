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
            Label blacklist = new Label();
            ErrorOverview.Visible = false;
            ErrorOverview.Controls.Remove(blacklist);
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
            if (Page.IsPostBack && Session["Blacklist"] == null)
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
                   else 
	               {
                       if(Session["Fail"]==null)
                           Session["Fail"]=0.ToString();
                       Session["Fail"]=(Int32.Parse( Session["Fail"].ToString())+1).ToString();
                       if (Int32.Parse(Session["Fail"].ToString()) >= 3 )
                       {
                           Session["Fail"] = null;
                           Session["Blacklist"] = DateTime.Now;
                       }
	               }
               }
               else
               {
                   if (Session["Fail"] == null)
                       Session["Fail"] = 0.ToString();
                   Session["Fail"] = (Int32.Parse(Session["Fail"].ToString()) + 1).ToString();
                   if (Int32.Parse(Session["Fail"].ToString()) >= 3)
                   {
                       Session["Fail"] = null;
                       Session["Blacklist"] = DateTime.Now;
                   }
               }                             
            }
             if (Session["Blacklist"] != null)
            {
                ErrorOverview.Visible = true;

                blacklist.Text = "You failled 3 times to login please wait 3 minutes and try again";
                ErrorOverview.Controls.Add(blacklist);
                if (DateTime.Now.Subtract(DateTime.Parse(Session["Blacklist"].ToString())) >=  TimeSpan.FromMinutes(3))
                {
                    ErrorOverview.Visible = false;
                    ErrorOverview.Controls.Remove(blacklist);
                    Session["Blacklist"] = null;
                }
            }
        }

        protected void CV_uname_IsNotNull(object source, ServerValidateEventArgs args)
        {
            Label ErrSpan_Captcha = new Label();
            args.IsValid = !(String.IsNullOrEmpty(args.Value) || String.IsNullOrWhiteSpace(args.Value));
            if (!args.IsValid)
            {
                ErrorOverview.Visible = true;
                ErrSpan_Captcha.CssClass = "glyphicon glyphicon-remove form-control-feedback";
                ErrSpan_Captcha.Attributes.Add("aria-hidden", "true");

                TB_UserName.Parent.Controls.AddAt(TB_UserName.Parent.Controls.IndexOf(TB_UserName) + 1, ErrSpan_Captcha);
                Unamegroup.CssClass = "form-group has-error has-feedback";
            }
            else
            {
                Unamegroup.CssClass = "form-group";
                Unamegroup.Controls.Remove(ErrSpan_Captcha);
            }
        }

        protected void CV_pwd_IsNotNull(object source, ServerValidateEventArgs args)
        {
            Label ErrSpan_Captcha = new Label();
            args.IsValid = !(String.IsNullOrEmpty(args.Value) || String.IsNullOrWhiteSpace(args.Value));
            if (!args.IsValid)
            {
                ErrorOverview.Visible = true;
                ErrSpan_Captcha.CssClass = "glyphicon glyphicon-remove form-control-feedback";
                ErrSpan_Captcha.Attributes.Add("aria-hidden", "true");

                TB_PassWord.Parent.Controls.AddAt(TB_PassWord.Parent.Controls.IndexOf(TB_PassWord) + 1, ErrSpan_Captcha);
                pwd1group.CssClass = "form-group has-error has-feedback";
            }
            else
            {
                pwd1group.CssClass = "form-group";
                pwd1group.Controls.Remove(ErrSpan_Captcha);
            }
        }
        
    }
}