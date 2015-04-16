using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
   public partial class LoginsJournal : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          long id= 0;
          LoginInfo log = new LoginInfo((string)Application["MainDB"], this);
          log.SelectAll();
          if(Session["User"]!=null)
           id = ((Users)Session["User"]).ID;
          log.MakeThatGridView(Log_Panel, id, ((Users)Session["User"]).UserName);
      }
   }
}