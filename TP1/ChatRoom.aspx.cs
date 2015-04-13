using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
    public partial class ChatRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetMessage();
        }

        public void SetMessage()
        {
            ThreadMessage message = new ThreadMessage((string)Application["MainDB"], this);
            message.SelectAll();
            message.MessageGridView(Message_Panel);                   
        }
        public void SetThread()
        {
            Users user;
            if (Session["User"] != null)
            {
                user = (Users)Session["User"];
                user.SelectAll();
                
                Threads thread = new Threads((string)Application["MainDB"], this);
                thread.SelectAll();
                thread.ShowThread(Thread_Panel, user.ID);
            }                
        }
        protected void Btn_Send_Click(object sender, EventArgs e)
        {

            Users user;

            if (Session["User"] != null)
            {
                user = (Users)Session["User"];

                ThreadMessage Tmessage = new ThreadMessage((string)Application["MainDB"], this);

                Tmessage.Thread_ID = 3;
                Tmessage.User_ID = user.ID;
                Tmessage.Date_Of_Creation = DateTime.Now.ToShortTimeString();
                Tmessage.Message = Tb_Message.Text;
                Tmessage.Insert();                              
            }                



        }
        protected void Timer_Chat_Tick(object sender, EventArgs e)
        {
           Users user;
           if (Session["User"] != null)
           {
              user = (Users)Session["User"];
              user.SelectAll();

              Threads thread = new Threads((string)Application["MainDB"], this);
              thread.SelectAll();
              thread.ShowThread(Thread_Panel, user.ID);
           }                
          
        }
    }
}