using System;
using System.Collections.Generic;
using System.Linq;
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
           
           if(Session["User"] != null)
           { 
           Usager = (Users)Session["User"];
           SetTbText();
           }
        }

       private void SetTbText()
        {
           TB_FullName.Text = Usager.FullName;
           TB_UserName.Text = Usager.UserName;
           TB_PassWord.Text = Usager.Password;
           TB_Email.Text = Usager.Email;
           IMG_Avatar.ImageUrl = @"~\Avatars/" + Usager.Avatar + ".png";
        }
    }
}