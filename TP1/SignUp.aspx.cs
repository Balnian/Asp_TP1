using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mail;


namespace TP1
{
    public partial class SignUp : System.Web.UI.Page
    {
      Users Usager;
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorOverview.Visible = false;
            if (!Page.IsPostBack)
            {
                Session["captcha"] = BuildCaptcha();                    
            }
            LoadAnonymous();
        }

        Random random = new Random();
        char RandomChar()
        {
            // les lettres comportant des ambiguïtées ne sont pas dans la liste
            // exmple: 0 et O ont été retirés
            string chars = "abcdefghkmnpqrstuvwvxyzABCDEFGHKMNPQRSTUVWXYZ23456789";
            return chars[random.Next(0, chars.Length)];
        }

        Color RandomColor(int min, int max)
        {
            return Color.FromArgb(255, random.Next(min, max), random.Next(min, max), random.Next(min, max));
        }

        string Captcha()
        {
            string captcha = "";

            for (int i = 0; i < 5; i++)
                captcha += RandomChar();
            return captcha.ToLower();
        }

        string BuildCaptcha()
        {
            int width = 200;
            int height = 70;
            Bitmap bitmap = new Bitmap(width, height);
            Graphics DC = Graphics.FromImage(bitmap);
            SolidBrush brush = new SolidBrush(RandomColor(0, 127));
            SolidBrush pen = new SolidBrush(RandomColor(172, 255));
            DC.FillRectangle(brush, 0, 0, 200, 100);
            Font font = new Font("Snap ITC", 28, FontStyle.Regular);
            PointF location = new PointF(5f, 5f);
            DC.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            string captcha = Captcha();
            DC.DrawString(captcha, font, pen, location);

            // noise generation
            for (int i = 0; i < 5000; i++)
            {
                bitmap.SetPixel(random.Next(0, width), random.Next(0, height), RandomColor(127, 255));
            }
            bitmap.Save(Server.MapPath("Captcha.png"), ImageFormat.Png);
            return captcha;
        }
        protected void RegenarateCaptcha_Click(object sender, ImageClickEventArgs e)
        {
            Session["captcha"] = BuildCaptcha();
            // + DateTime.Now.ToString() pour forcer le fureteur recharger le fichier
            IMGCaptcha.ImageUrl = "~/Captcha.png?ID=" + DateTime.Now.ToString();
            PN_Captcha.Update();
        }
        protected void BTN_Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                InsertRecord();
                Session["message"] = "(Inscription réussie - complétez maintenant votre profil...)";
                Session["LoginDate"] = DateTime.Now;
                Response.Redirect("Profil.aspx");               
            }
        
        }
        protected void CV_Captcha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Label ErrSpan_Captcha = new Label();
            args.IsValid = (TB_Captcha.Text == (string)Session["captcha"]);
            if (!args.IsValid)
            {
                ErrorOverview.Visible = true;
                ErrSpan_Captcha.CssClass = "glyphicon glyphicon-remove form-control-feedback";
                ErrSpan_Captcha.Attributes.Add("aria-hidden", "true");
                
                 TB_Captcha.Parent.Controls.AddAt(TB_Captcha.Parent.Controls.IndexOf(TB_Captcha)+1,ErrSpan_Captcha);
                 Captcha_Input_Group.CssClass = "form-group has-error has-feedback";
            }
            else
            {
                Captcha_Input_Group.CssClass = "form-group";
                Captcha_Input_Group.Controls.Remove(ErrSpan_Captcha);
            }
        } 
       private void LoadAnonymous()
       {
         String Avatar_Path = "";
         String avatar_ID = "";

         if (FU_Avatar.FileName != "")
         {
            avatar_ID = Guid.NewGuid().ToString();
            Avatar_Path = Server.MapPath(@"~\Avatars\") + avatar_ID + ".png";
            FU_Avatar.SaveAs(Avatar_Path);
         }
       }
       private void InsertRecord()
       { 
         Usager = new Users((string)Application["MainDB"], this);
       
         Usager.FullName = Request["FullName"];
         Usager.UserName = Request["UserName"];
         Usager.Password = Request["PassWord"];
         Usager.Email = Request["Email"];
       
         String Avatar_Path = "";
         String avatar_ID = "";
       
         if (FU_Avatar.FileName != "")
         {
            avatar_ID = Guid.NewGuid().ToString();
            Avatar_Path = Server.MapPath(@"~\Avatars\") + avatar_ID + ".png";
            FU_Avatar.SaveAs(Avatar_Path);
         }
         Usager.Avatar = avatar_ID; 
         Usager.Insert();
         Session["User"] = Usager;
         ((List<long>)Application["Online"]).Add(Usager.ID);
       
       }
       #region CustomValidator

       protected void CV_Name_IsNotNull(object source, ServerValidateEventArgs args)
       {
           Label ErrSpan_Captcha = new Label();
           args.IsValid = !(String.IsNullOrEmpty(args.Value) || String.IsNullOrWhiteSpace(args.Value));
           if(!args.IsValid)
           {
               ErrorOverview.Visible = true;
               ErrSpan_Captcha.CssClass = "glyphicon glyphicon-remove form-control-feedback";
               ErrSpan_Captcha.Attributes.Add("aria-hidden", "true");

               name.Parent.Controls.AddAt(name.Parent.Controls.IndexOf(name) + 1, ErrSpan_Captcha);
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

               user.Parent.Controls.AddAt(user.Parent.Controls.IndexOf(user) + 1, ErrSpan_Captcha);
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

               pwd.Parent.Controls.AddAt(user.Parent.Controls.IndexOf(pwd) + 1, ErrSpan_Captcha);
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
           args.IsValid = args.Value == pwd.Text;
           if (!args.IsValid)
           {
               ErrorOverview.Visible = true;
               ErrSpan_Captcha.CssClass = "glyphicon glyphicon-remove form-control-feedback";
               ErrSpan_Captcha.Attributes.Add("aria-hidden", "true");

               conpwd.Parent.Controls.AddAt(user.Parent.Controls.IndexOf(conpwd) + 1, ErrSpan_Captcha);
               pwdcgroup.CssClass = "form-group has-error has-feedback";
           }
           else
           {
               pwdcgroup.CssClass = "form-group";
               pwdcgroup.Controls.Remove(ErrSpan_Captcha);
           }
       }

       protected void CV_email_match(object source, ServerValidateEventArgs args)
       {
           Label ErrSpan_Captcha = new Label();
           args.IsValid = args.Value == pwd.Text;
           if (!args.IsValid)
           {
               ErrorOverview.Visible = true;
               ErrSpan_Captcha.CssClass = "glyphicon glyphicon-remove form-control-feedback";
               ErrSpan_Captcha.Attributes.Add("aria-hidden", "true");

               conmail.Parent.Controls.AddAt(user.Parent.Controls.IndexOf(conmail) + 1, ErrSpan_Captcha);
               emlcgroup.CssClass = "form-group has-error has-feedback";
           }
           else
           {
               emlcgroup.CssClass = "form-group";
               emlcgroup.Controls.Remove(ErrSpan_Captcha);
           }
       }

       protected void CV_email_valid(object source, ServerValidateEventArgs args)
       {
           Label ErrSpan_Captcha = new Label();
           args.IsValid = IsValidEmailAddr(args.Value);
           if (!args.IsValid)
           {
               ErrorOverview.Visible = true;
               ErrSpan_Captcha.CssClass = "glyphicon glyphicon-remove form-control-feedback";
               ErrSpan_Captcha.Attributes.Add("aria-hidden", "true");

               mail.Parent.Controls.AddAt(user.Parent.Controls.IndexOf(mail) + 1, ErrSpan_Captcha);
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