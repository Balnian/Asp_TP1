using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace TP1
{
    public partial class Profil : System.Web.UI.Page
    {
       Users Usager;
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorOverview.Visible = false;
           if (Session["User"] != null && !Page.IsPostBack)
           {
              Usager = (Users)Session["User"];
              SetTbText();
           }      
        }
       private void SetTbText()
        {
            Usager.ID = Usager.SelectId(Usager.UserName);
            TB_FullName.Text = Usager.FullName;
           TB_UserName.Text = Usager.UserName;
          TB_PassWord.Attributes["Value"] = Usager.Password;
           TB_Email.Text = Usager.Email;
           IMG_Avatar.ImageUrl = @"~\Avatars/" + Usager.Avatar + ".png";
        }
       private void Update()
       {
           if (Session["User"] != null)
           {
               Usager = (Users)Session["User"];
               Usager.ID = Usager.SelectId(Usager.UserName);
               Usager.FullName = TB_FullName.Text;
               Usager.UserName = TB_UserName.Text;
               Usager.Password = TB_PassWord.Text;
               Usager.Email = TB_Email.Text;
                         
               if (FU_Avatar.FileName != "")
               {
                  DeleteImage(Usager.Avatar);
                  String Avatar_Path = "";
                  String avatar_ID = "";
                   avatar_ID = Guid.NewGuid().ToString();
                   Avatar_Path = Server.MapPath(@"~\Avatars\") + avatar_ID + ".png";
                   FU_Avatar.SaveAs(Avatar_Path);
                   Usager.Avatar = avatar_ID; ;
               }
              
               Usager.Update();
               Session["User"] = Usager;
               IMG_Avatar.ImageUrl = @"~\Avatars/" + Usager.Avatar + ".png";
               Usager.EndQuerySQL();           
           }      
       }
       private void DeleteImage(String ID)
       {
           File.Delete(Server.MapPath(@"~\Avatars\") + ID + ".png");
       }
       protected void BTN_Submit_Click(object sender, EventArgs e)
       {
           Update();
       }

       #region CustomValidator

       protected void CV_Name_IsNotNull(object source, ServerValidateEventArgs args)
       {
           Label ErrSpan_Captcha = new Label();
           args.IsValid = !(String.IsNullOrEmpty(args.Value) || String.IsNullOrWhiteSpace(args.Value));
           if (!args.IsValid)
           {
               ErrorOverview.Visible = true;
               ErrSpan_Captcha.CssClass = "glyphicon glyphicon-remove form-control-feedback";
               ErrSpan_Captcha.Attributes.Add("aria-hidden", "true");

               TB_FullName.Parent.Controls.AddAt(TB_FullName.Parent.Controls.IndexOf(TB_FullName) + 1, ErrSpan_Captcha);
               namegroup.CssClass = "form-group has-error has-feedback";
           }
           else
           {
               namegroup.CssClass = "form-group";
               namegroup.Controls.Remove(ErrSpan_Captcha);
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

       protected void CV_pwd_match(object source, ServerValidateEventArgs args)
       {
           Label ErrSpan_Captcha = new Label();
           args.IsValid = args.Value == TB_PassWord.Text;
           if (!args.IsValid)
           {
               ErrorOverview.Visible = true;
               ErrSpan_Captcha.CssClass = "glyphicon glyphicon-remove form-control-feedback";
               ErrSpan_Captcha.Attributes.Add("aria-hidden", "true");

               TB_ValidPW.Parent.Controls.AddAt(TB_ValidPW.Parent.Controls.IndexOf(TB_ValidPW) + 1, ErrSpan_Captcha);
               pwdcgroup.CssClass = "form-group has-error has-feedback";
           }
           else
           {
               pwdcgroup.CssClass = "form-group";
               pwdcgroup.Controls.Remove(ErrSpan_Captcha);
           }
       }

       

       protected void CV_email_valid(object source, ServerValidateEventArgs args)
       {
           Label ErrSpan_Captcha = new Label();
           if (!String.IsNullOrEmpty(args.Value))
               args.IsValid = IsValidEmailAddr(args.Value);
           else
               args.IsValid = false;
           if (!args.IsValid)
           {
               ErrorOverview.Visible = true;
               ErrSpan_Captcha.CssClass = "glyphicon glyphicon-remove form-control-feedback";
               ErrSpan_Captcha.Attributes.Add("aria-hidden", "true");

               TB_Email.Parent.Controls.AddAt(TB_Email.Parent.Controls.IndexOf(TB_Email) + 1, ErrSpan_Captcha);
               eml1group.CssClass = "form-group has-error has-feedback";
           }
           else
           {
               eml1group.CssClass = "form-group";
               eml1group.Controls.Remove(ErrSpan_Captcha);
           }
       }

       public bool IsValidEmailAddr(string emailaddress)
       {
           try
           {
               MailAddress m = new MailAddress(emailaddress);

               return true;
           }
           catch (FormatException)
           {
               return false;
           }
       }

       #endregion

    }
}