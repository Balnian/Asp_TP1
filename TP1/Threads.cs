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


         public void ShowThread(Panel PN_GridView, long id, long Tid) 
        {
        
            HtmlGenericControl Grid = null;
         
            if (reader.HasRows)
            {
                Grid = new HtmlGenericControl("ul");

                HtmlGenericControl tr;
             
                while (Next())
                {
                    tr = new HtmlGenericControl("li");
                    
                   
                    HyperLink abal = new HyperLink();
                    abal.Text = FieldsValues[2];
                    abal.NavigateUrl = "#";
                    
                    abal.ID=FieldsValues[0];
                    abal.Attributes.Add("onclick", "ThreadMode(this)");
                    if (Tid == long.Parse(FieldsValues[0]))
                        abal.Attributes.Add("class", "active");
                    tr.Controls.Add(abal);
                    
                    Grid.Controls.Add(tr);
                }

                Grid.Attributes.Add("Class", "nav nav-pills nav-stacked");
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
                 li.Attributes.Add("role", "presentation");
                 HtmlGenericControl abal = new HtmlGenericControl("a");
                 abal.Attributes.Add("href", "#");
                 abal.InnerText = FieldsValues[2];
                 li.Controls.Add(abal);
                 OrderedList.Controls.Add(li);               

             }
             OrderedList.Attributes.Add("class", "nav nav-pills nav-stacked");
             Pn_Thread.Controls.Clear();
             Pn_Thread.Controls.Add(OrderedList);
             EndQuerySQL();             
         
         }
         
        
    }
}