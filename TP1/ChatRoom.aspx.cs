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
            ShowThreadUser();
            ShowUser();
        }

        public void SetMessage()
        {
            ThreadMessage message = new ThreadMessage((string)Application["MainDB"], this);
            message.SelectAll();           
            message.MessageGridView(Message_Panel);
            message.EndQuerySQL();     
        }
        public void SetThread()
        {
            Users user;
            if (Session["User"] != null)
            {
                user = (Users)Session["User"];
                user.SelectAll();             
                Threads thread = new Threads((string)Application["MainDB"], this);
                user.EndQuerySQL();   
                thread.SelectAll();              
                thread.ShowThread(Thread_Panel, user.ID);
                thread.EndQuerySQL();
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
                Tmessage.EndQuerySQL();            
            }

            SetMessage();
        }

        protected void Timer_Chat_Tick(object sender, EventArgs e)
        {
       
          
        }
        public void ShowThreadUser()
        {


            Threads thread = new Threads((string)Application["MainDB"], this);          
            thread.SelectAll();
            thread.MakeThreadList(Thread_Panel, 2);
            thread.EndQuerySQL();                  
        }

        public void ShowUser()
        {
            Users user;
             if (Session["User"] != null)
            {
                user = (Users)Session["User"];
                user.SelectAll();
                user.listAccessThread(User_Panel,2,(List<long>)Application["Online"]);
                user.EndQuerySQL();
            }
        
        
        
        }
    }
}