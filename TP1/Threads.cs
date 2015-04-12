using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
         
         
         
         
        
    }
}