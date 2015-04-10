using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
   public partial class Room : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         SelectAllUser();
      }
      private void SelectAllUser()
      {
        Users Usager  = new Users ((string)Application["MainDB"], this);
        Usager.SelectAll();
        Usager.MakeGridView(PN_GridView,(List<long>)Application["Online"]);   
      }
   }
}