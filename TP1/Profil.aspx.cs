using System;
using System.Collections.Generic;
using System.IO;
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
           if (Session["User"] != null && !Page.IsPostBack)
           {
              Usager = (Users)Session["User"];
              SetTbText();
           }
          // SetTbText();
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
    }
}