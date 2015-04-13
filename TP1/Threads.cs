using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TP1
{
    public class Threads : SqlExpressUtilities.SqlExpressWrapper
    {
        public long ID { get; set; }
        public String creator { get; set; }
        public String title { get; set; }
        public String date { get; set; }


        public Threads(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page) 
        {
            SQLTableName = "THREADS";          
        }

        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            creator = FieldsValues[1];
            title = FieldsValues[2];
            date = FieldsValues[3];          
        }

         public override void Insert()
        {
            InsertRecord(creator, title, date);        
        }
         public long GetId(String threadName)
         { 
         
         String Query = "Select ID from " + SQLTableName + " Where TITLE = '" + threadName + "'";
         SqlConnection Connection;
         SqlDataReader Reader;
         long iD = -1;
            // instancier l'objet de collection
            Connection = new SqlConnection(connexionString);
            // bâtir l'objet de requête
            SqlCommand sqlcmd = new SqlCommand(Query,Connection);         
            Page.Application.Lock();          
            try
            {
                Connection.Open();
                Reader = sqlcmd.ExecuteReader();

                while (Reader.Read())                
               iD = Reader.GetInt64(0);                  
                    Reader.Close();                
            }
            catch (Exception)
            {               
            }
            finally
            {
                EndQuerySQL();               
            }
            return iD;
        }


         public void ShowThread(Panel PN_GridView, long id) 
        {
        
            Table Grid = null;
         
            if (reader.HasRows)
            {
                Grid = new Table();

                TableRow tr;
             
                while (Next())
                {
                    tr = new TableRow();
                    TableCell td = new TableCell();
                    td.Text = FieldsValues[2];
                    tr.Cells.Add(td);
                    Grid.Rows.Add(tr);
                }

                Grid.CssClass = "nav nav-pills nav-stacked";
            }
            PN_GridView.Controls.Clear();
            if (Grid != null)
                PN_GridView.Controls.Add(Grid);
            EndQuerySQL();                             
        }

         public void MakeThreadList(Panel Pn_Thread, long u_Id)
         {

             HtmlGenericControl OrderedList = new HtmlGenericControl("ul");

             while (Next())
             {

                 HtmlGenericControl li = new HtmlGenericControl("li");
                 li.InnerText = FieldsValues[2];
                 OrderedList.Controls.Add(li);               

             }
             OrderedList.Attributes.Add("class", "nav nav-pills nav-stacked");
             Pn_Thread.Controls.Clear();
             Pn_Thread.Controls.Add(OrderedList);
             EndQuerySQL();             
         
         }
         
        
    }
}