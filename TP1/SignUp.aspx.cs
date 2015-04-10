using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;


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
    }
}