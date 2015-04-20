using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmailSender;
using System.Net.Mail;

namespace TP1
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorOverview.Visible = false;
            if(Page.IsPostBack)
            {
                if (!String.IsNullOrWhiteSpace(EmailTxt.Text) && !String.IsNullOrWhiteSpace(AccName.Text))
                {
                    Users user = new Users((string)Application["MainDB"], this);
                    
                    String pword = user.IsUserEmail(EmailTxt.Text,AccName.Text);
                    if(!String.IsNullOrEmpty(pword))
                    {
                        sendrecovery(pword);
                    }

                }
            }
        }
        public bool sendrecovery(String pword)
        {
            EMail eMail = new EMail();

            // Vous devez avoir un compte gmail
            eMail.From = "noreplychatroom@gmail.com";
            eMail.Password = "noreplychatroom1";
            eMail.SenderName = "noreplychatroom";

            eMail.Host = "smtp.gmail.com";
            eMail.HostPort = 587;
            eMail.SSLSecurity = true;

            eMail.To = EmailTxt.Text;
            eMail.Subject = "Password";
            eMail.Body = "Password: "+pword;

            if (eMail.Send())
            {
                return true;
            }
            else
                return false;
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

                AccName.Parent.Controls.AddAt(AccName.Parent.Controls.IndexOf(AccName) + 1, ErrSpan_Captcha);
                Unamegroup.CssClass = "form-group has-error has-feedback";
            }
            else
            {
                Unamegroup.CssClass = "form-group";
                Unamegroup.Controls.Remove(ErrSpan_Captcha);
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

                EmailTxt.Parent.Controls.AddAt(EmailTxt.Parent.Controls.IndexOf(EmailTxt) + 1, ErrSpan_Captcha);
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
    }
}