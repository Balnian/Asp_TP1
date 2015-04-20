using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
    public partial class ThreadsManager : System.Web.UI.Page
    {
        Users user;
        List<CheckBox> cblist;
        List<long> idlist = new List<long>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                if (Request["Id"] != null)
                {
                    Session["Thread"] = Request["Id"];

                }
                else
                {
                    if (Session["Thread"] == null)
                        Session["Thread"] = -1;
                    

                }
                user = (Users)Session["User"];
                user.SelectAll();
                cblist = user.MakeAGridForThread(Pn_Users, long.Parse(Session["Thread"].ToString()));
                user.EndQuerySQL();
                Threads thread = new Threads((string)Application["MainDB"], this);
                thread.SelectAll();
                
                
                thread.ShowThread(Pn_Thread, user.ID, long.Parse(Session["Thread"].ToString()));
                thread.EndQuerySQL();
            }
            else
                Response.Redirect("Login.aspx");
        }
        protected void BTN_Create_Click(object sender, EventArgs e)
        {
              if (Session["User"] != null)
            {
                user = (Users)Session["User"];
                Threads thread = new Threads((string)Application["MainDB"], this);               
                foreach (CheckBox cb in cblist)
                {
                    if (cb.Checked)
                    {
                        idlist.Add(long.Parse(cb.ID));
                    }               
                }

                thread.creator = user.UserName;
                thread.title = TB_ThreadName.Text;
                thread.date = DateTime.Now.ToString();
                thread.Insert();
                ThreadAcces threadA = new ThreadAcces((string)Application["MainDB"], this);
                threadA.THREAD_ID = thread.GetId(thread.title);
                    foreach (long id in idlist)
                    {
                        threadA.ID_U = id;
                        threadA.Insert();
                    }
                    thread.EndQuerySQL();
                    threadA.EndQuerySQL();
                    Response.Redirect("ThreadsManager.aspx");
            }

        }


        protected void Update_Click(object sender, EventArgs e)
        {
            if (Session["User"] != null && long.Parse(Session["Thread"].ToString()) != -1)
            {
                user = (Users)Session["User"];
                Threads thread = new Threads((string)Application["MainDB"], this);
                
                foreach (CheckBox cb in cblist)
                {
                    if (cb.Checked)
                    {
                        idlist.Add(long.Parse(cb.ID));
                    }
                }
                List<long> UserIn = thread.UserInThread(long.Parse(Session["Thread"].ToString()));
                List<long> toAdd = new List<long>();

                //User to add filter
                foreach (long id in idlist)
                {
                    if(!UserIn.Contains(id))
                        toAdd.Add(id);
                    //foreach (long id2 in UserIn)
                    //{
                    //    if (id==id2)
                    //    {
                    //        toAdd.Add(id);
                    //    }
                    //}
                    
                        
                    
                }
                //Delete user filter
                List<long> toDel = new List<long>();
                foreach (long id in UserIn)
                {
                    if(!idlist.Contains(id))
                        toDel.Add(id);
                    //foreach (long id2 in idlist)
                    //{
                    //    if (id == id2)
                    //    {
                    //        toDel.Add(id);
                    //    }
                    //}
                    
                   
                    
                }

                //Adding new User
                ThreadAcces threadA = new ThreadAcces((string)Application["MainDB"], this);
                threadA.THREAD_ID = long.Parse(Session["Thread"].ToString());
                //delete Users
                foreach (long id in toDel)
                {
                    threadA.ID_U = id;
                    threadA.DeleteAccessByID();
                }
                foreach (long id in toAdd)
                {
                    threadA.ID_U = id;
                    threadA.Insert();
                }
                
                //thread.EndQuerySQL();
                threadA.EndQuerySQL();
                Response.Redirect("ThreadsManager.aspx");
            }
            

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            if (Session["User"] != null && long.Parse(Session["Thread"].ToString()) != -1)
            {
                user = (Users)Session["User"];
                Threads thread = new Threads((string)Application["MainDB"], this);
                
                thread.DeleteRecordByID(Session["Thread"].ToString());

                ThreadAcces threadA = new ThreadAcces((string)Application["MainDB"], this);
                threadA.THREAD_ID = long.Parse(Session["Thread"].ToString());
                threadA.DeleteAccessByTID();
                Response.Redirect("ThreadsManager.aspx");
            }
            

        }

    }
}