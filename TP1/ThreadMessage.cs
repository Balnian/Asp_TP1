using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TP1
{
    public class ThreadMessage: SqlExpressUtilities.SqlExpressWrapper
    {
     public   long ID { get; set; }
     public   long Thread_ID { get; set; }
    public    long User_ID { get; set; }
    public     String Date_Of_Creation { get; set; }
     public   String Message { get; set; }
        public ThreadMessage(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "THREAD_MESSAGES";
        }

        public override void Insert()
        {
            InsertRecord(Thread_ID, User_ID, Date_Of_Creation,Message);
        }
        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            Thread_ID = long.Parse(FieldsValues[1]);
            User_ID = long.Parse(FieldsValues[2]);
            Date_Of_Creation = FieldsValues[3];
            Message = FieldsValues[4];
        }
        public void MessageGridView(Panel  PN_GridView)
        {
            Table Grid = null;        
            if (reader.HasRows)
            {
                Grid = new Table();
                Grid.CssClass = "table table-responsive";
                TableRow tr;
             
                while (Next())
                {
                    tr = new TableRow();
                    String[] info = GetUserNameAndAvatar(long.Parse(FieldsValues[2]));
                    Image imagea = new Image();
                    imagea.CssClass = "img-responsive";
                    //Image
                    TableCell tdavatar = new TableCell();
                    tdavatar.CssClass = "col-xs-1";
                    Image imageA = new Image();
                    imageA.ImageUrl = @"~\Avatars/" + info[1] + ".png";
                    imageA.CssClass = "img-responsive";
                    imageA.Width = new Unit(60);
                    tdavatar.Controls.Add(imageA);
                    tr.Cells.Add(tdavatar);
                   
                    //Heure et nom
                    TableCell td = new TableCell();
                    td.CssClass = "col-xs-2";
                    HtmlGenericControl row1 = new HtmlGenericControl("div");
                    row1.Attributes.Add("class", "row");
                    row1.InnerText = FieldsValues[3];

                    HtmlGenericControl editbutton = new HtmlGenericControl("button");
                    editbutton.Attributes.Add("onclick", "ChatMode()");
                    editbutton.Attributes.Add("class", "btn btn-default pull-right");
                    editbutton.ID = "e_" + FieldsValues[0];
                    HtmlGenericControl edit = new HtmlGenericControl("span");
                    edit.Attributes.Add("class", "glyphicon glyphicon-pencil");
                    editbutton.Controls.Add(edit);
                    row1.Controls.Add(editbutton);
                    
                    HtmlGenericControl row2 = new HtmlGenericControl("div");
                    HtmlGenericControl str = new HtmlGenericControl("strong");                    
                    str.InnerText = info[0];
                    row2.Controls.Add(str);

                    HtmlGenericControl removebutton = new HtmlGenericControl("button");
                    removebutton.Attributes.Add("class", "btn btn-default pull-right");
                    removebutton.ID = "r_" + FieldsValues[0];
                    HtmlGenericControl remove = new HtmlGenericControl("span");
                    remove.Attributes.Add("class", "glyphicon glyphicon-remove-sign");                 
                
                    
                    removebutton.Controls.Add(remove);
                    row2.Controls.Add(removebutton);
                    td.Controls.Add(row1);
                    td.Controls.Add(row2);
                    tr.Cells.Add(td);

                    
                    //Message
                    TableCell ttext = new TableCell();
                    ttext.CssClass = "col-xs-9";
                    ttext.Text = FieldsValues[4];
                    tr.Cells.Add(ttext);
                    Grid.Rows.Add(tr);
                }

              //  Grid.CssClass = "table-condensed";
            }
            PN_GridView.Controls.Clear();
            if (Grid != null)
                PN_GridView.Controls.Add(Grid);
            EndQuerySQL();       
        
        }

        public String[] GetUserNameAndAvatar(long id)
        {

            String Query = "Select UserName,Avatar from USERS Where ID = " + id;
            SqlConnection Connection;
            SqlDataReader Reader;
            String[] info = new String[2];
            // instancier l'objet de collection
            Connection = new SqlConnection(connexionString);
            // bâtir l'objet de requête
            SqlCommand sqlcmd = new SqlCommand(Query, Connection);
          //  Page.Application.Lock();
            try
            {
               Connection.Open();
               Reader = sqlcmd.ExecuteReader();

               while (Reader.Read())
               {
                  info[0] = Reader.GetString(0);
                  info[1] = Reader.GetString(1);
               }
               Reader.Close();
            }
            catch (Exception)
            {
            }

            finally
            {
              // EndQuerySQL();
            
            }
            return info;                               
        }

       
    }
}