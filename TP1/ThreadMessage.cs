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
        public void MessageGridView(Panel  PN_GridView, long UserId, long threadId)
        {
            
            Table Grid = null;        
            if (reader.HasRows)
            {
                Grid = new Table();
                Grid.CssClass = "table table-responsive";
                TableRow tr;
             
                while (Next())
                {
                    if (threadId == long.Parse(FieldsValues[1]))
                    {
                        tr = new TableRow();
                        tr.ID = FieldsValues[0];

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
                        Panel contain = new Panel();
                        contain.CssClass = "container-fluid";
                        td.CssClass = "col-xs-2";
                        HtmlGenericControl row1 = new HtmlGenericControl("div");
                        row1.Attributes.Add("class", "row");

                        HtmlGenericControl time = new HtmlGenericControl("span");
                        time.InnerText = FieldsValues[3];
                        row1.Controls.Add(time);



                        HtmlGenericControl row2 = new HtmlGenericControl("div");
                        row2.Attributes.Add("class", "row");
                        HtmlGenericControl str = new HtmlGenericControl("strong");
                        str.InnerText = info[0];

                        row2.Controls.Add(str);

                        if (UserId == long.Parse(FieldsValues[2]))
                        {
                            //cacher les bouton et les montrer au mouse hover
                            tr.Attributes.Add("onmouseenter", "showbt(this)");
                            tr.Attributes.Add("onmouseleave", "hidebt(this)");
                            //tr.Attributes.Add("onload", "hidebt(this)");

                            HtmlGenericControl editbutton = new HtmlGenericControl("button");
                            editbutton.Attributes.Add("onclick", "ChatMode(this)");
                            editbutton.Attributes.Add("class", "btn btn-warning btn-xs pull-right ");
                            editbutton.Attributes.Add("style", "visibility:hidden");
                            editbutton.ID = "e_" + FieldsValues[0];
                            HtmlGenericControl edit = new HtmlGenericControl("span");
                            edit.Attributes.Add("class", "glyphicon glyphicon-pencil");
                            editbutton.Controls.Add(edit);
                            row1.Controls.Add(editbutton);
                            HtmlGenericControl removebutton = new HtmlGenericControl("button");
                            removebutton.Attributes.Add("class", "btn btn-danger btn-xs pull-right ");
                            removebutton.Attributes.Add("style", "visibility:hidden");
                            removebutton.Attributes.Add("onclick", "ChatMode(this)");
                            removebutton.ID = "r_" + FieldsValues[0];
                            HtmlGenericControl remove = new HtmlGenericControl("span");
                            remove.Attributes.Add("class", "glyphicon glyphicon-remove-sign");
                            removebutton.Controls.Add(remove);
                            row2.Controls.Add(removebutton);
                        }



                        contain.Controls.Add(row1);
                        contain.Controls.Add(row2);
                        td.Controls.Add(contain);
                        tr.Cells.Add(td);


                        //Message
                        TableCell ttext = new TableCell();
                        ttext.CssClass = "col-xs-9 well";
                        ttext.Text = FieldsValues[4];
                        ttext.ID = "m_" + FieldsValues[0];
                        ttext.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                        tr.Cells.Add(ttext);
                        Grid.Rows.Add(tr);
                    }
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
               Connection.Close();
              // EndQuerySQL()            
            }
            return info;                               
        }

        public String GetMessageById(long id)
        {
            String Query = "Select Message  from THREAD_MESSAGES  Where ID = " + id;
            SqlConnection Connection;
            SqlDataReader Reader;
            String message = "Default";
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
                    message = Reader.GetString(0);
                }
                Reader.Close();
            }
            catch (Exception)
            {
            }

            finally
            {
                 //EndQuerySQL();
                Connection.Close();
            }
            return message;                     
        }



        public void UpdateById(String id , String Message)
        { 
               
           String Query = "Update " + SQLTableName + " Set Message ='" + Message +"' Where ID =" + id;

              SqlConnection Connection =   new SqlConnection(connexionString);
              SqlCommand sqlcmd = new SqlCommand(Query,Connection);   
             //  Page.Application.Lock();          
            try
            {
                Connection.Open();
                sqlcmd.ExecuteNonQuery();
            }
              catch (Exception)
            {               
            }
            finally
            {
                Connection.Close();
             //   EndQuerySQL();               
            }
        }
        
        
        
                

    }
}