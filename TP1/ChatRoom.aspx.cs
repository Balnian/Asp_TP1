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

            if (Request["Type"] != null && Request["Id"] != null)
            {
                EditRemove(Request["Type"], Request["Id"]);
                       
            }

            if (Request["name"] != null)
            {
                Threads thread = new Threads((string)Application["MainDB"], this);
                Session["threadId"] = thread.GetId(Request["name"]);
            
            }
            else
            {
                if (Session["threadId"] == null)
                    Session["threadId"] = -1;


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
            if (Session["User"] != null && Session["threadId"]!=null)
            {
                user = (Users)Session["User"];
                ThreadMessage message = new ThreadMessage((string)Application["MainDB"], this);
                message.SelectAll();
                message.MessageGridView(Message_Panel,user.ID,long.Parse( Session["threadId"].ToString()));
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

                thread.MakeThreadList(Thread_Panel, ((Users)Session["User"]).ID, long.Parse(Session["threadId"].ToString()));
                thread.EndQuerySQL();
                user.EndQuerySQL();
            }
        }
        protected void Btn_Send_Click(object sender, EventArgs e)
        {
            Users user;
            ThreadMessage Tmessage = new ThreadMessage((string)Application["MainDB"], this);
            if (Session["User"] != null  && Session["threadId"] != null && Session["update"] == null)
            {
                user = (Users)Session["User"];
                Tmessage.Thread_ID = (long)Session["threadId"];
                Tmessage.User_ID = user.ID;
                Tmessage.Date_Of_Creation = DateTime.Now.ToShortTimeString();
                Tmessage.Message = Tb_Message.Text;
                Tmessage.Insert();
                Tb_Message.Text = "";
                Tmessage.EndQuerySQL();
            }
            else if (Session["MessageId"] != null)
            {
                Tmessage.UpdateById(Session["MessageId"].ToString(), Tb_Message.Text);
                Tb_Message.Text = "";
                Session["MessageId"] = null;
                Session["update"] = null;
                Btn_Send.Text = "Send";
            }
            Response.Redirect("ChatRoom.aspx");
            SetMessage();
        }
        protected void Timer_Chat_Tick(object sender, EventArgs e)
        {
            SetMessage(); 
        }
        public void ShowThreadUser()
        {
            if (Session["User"] != null)
            {
            Threads thread = new Threads((string)Application["MainDB"], this);
            thread.SelectAll();

                thread.MakeThreadList(Thread_Panel, ((Users)Session["User"]).ID, long.Parse(Session["threadId"].ToString()));
            thread.EndQuerySQL();
        }
        }

        public void ShowUser()
        {
            Users user;
            Users carry = new Users((string)Application["MainDB"], this);
            Users usager = new Users((string)Application["MainDB"], this);
            if (Session["User"] != null && Session["threadId"] != null)
            {
                ThreadAcces tdacces = new ThreadAcces((string)Application["MainDB"], this);                
                user = usager.SelectUser(((Users)Session["User"]).ID,carry);
                user.SelectAll();
                /*BUG ICI*/
                user.listAccessThread(User_Panel, long.Parse(Session["threadId"].ToString()), (List<long>)Application["Online"], tdacces);


                user.EndQuerySQL();
            }
           // Session["User"] = carry;
        }

        private void EditRemove(String type, String messageId)
        { 
        ThreadMessage message = new ThreadMessage((string)Application["MainDB"], this);

        if (type.Equals("e") && Session["update"] == null)
        {
            Btn_Send.Text = "Update";
            Tb_Message.Text = message.GetMessageById(long.Parse(messageId));
            Session["MessageId"] = messageId;
            Session["update"] = true;
        }
        else if (type.Equals("r"))
        {
            message.DeleteRecordByID(messageId);
            Response.Redirect("ChatRoom.aspx");
        }
               
        }
    }
}