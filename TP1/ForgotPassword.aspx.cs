using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmailSender;

namespace TP1
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        
    }
}