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
        bool update = false;
     
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["Type"] != null && Request["Id"] != null)
            {
                EditRemove(Request["Type"], Request["Id"]);
                Response.Redirect("ChatRoom.aspx");               
            }

            if (Session["User"] != null )
            {
                SetMessage();
                ShowThreadUser();
                ShowUser();
            }
            else
                Response.Redirect("Login.aspx");
        }

        public void SetMessage()
        {
            Users user;
            if (Session["User"] != null)
            {
                user = (Users)Session["User"];
                ThreadMessage message = new ThreadMessage((string)Application["MainDB"], this);
                message.SelectAll();
                message.MessageGridView(Message_Panel,user.ID);
                message.EndQuerySQL();
            }
        }
        public void SetThread()
        {
            Users user;
            if (Session["User"] != null)
            {
                user = (Users)Session["User"];
                user.SelectAll();
                Threads thread = new Threads((string)Application["MainDB"], this);
               // user.EndQuerySQL();
                thread.SelectAll();
                thread.ShowThread(Thread_Panel, user.ID,(long)Session["Thread"]);
                thread.EndQuerySQL();
                user.EndQuerySQL();
            }
        }
        protected void Btn_Send_Click(object sender, EventArgs e)
        {
            Users user;
            ThreadMessage Tmessage = new ThreadMessage((string)Application["MainDB"], this);
            if (Session["User"] != null && !update)
            {
                user = (Users)Session["User"];                
                Tmessage.Thread_ID = 3;
                Tmessage.User_ID = user.ID;
                Tmessage.Date_Of_Creation = DateTime.Now.ToShortTimeString();
                Tmessage.Message = Tb_Message.Text;
                Tmessage.Insert();
                Tmessage.EndQuerySQL();
            }
            else if (Session["MessageId"] != null)
            {
                Tmessage.UpdateById(Session["MessageId"].ToString(), Request["text"]);
                update = false;
                Session["MessageId"] = null;
                Btn_Send.Text = "Send";
            }
           
            SetMessage();
        }

        protected void Timer_Chat_Tick(object sender, EventArgs e)
        {
            SetMessage(); 
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
                user.listAccessThread(User_Panel, 2, (List<long>)Application["Online"]);
                user.EndQuerySQL();
            }
        }

        private void EditRemove(String type, String messageId)
        { 
        ThreadMessage message = new ThreadMessage((string)Application["MainDB"], this);

        if (type.Equals("e"))
        {
            Btn_Send.Text = "Update";
          //  Tb_Message.Text = message.GetMessageById(long.Parse(messageId));
            Session["MessageId"] = messageId;
            update = true;
        }
        else if (type.Equals("r"))
        {
            message.DeleteRecordByID(messageId);
        
        }
        


        
        }
    }
}