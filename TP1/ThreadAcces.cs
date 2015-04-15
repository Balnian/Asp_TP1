using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP1
{
   
    public class ThreadAcces:SqlExpressUtilities.SqlExpressWrapper
    {
    
    public long ID {get;set;}
    public long ID_U {get;set;}
    public long  THREAD_ID {get;set;}

        public ThreadAcces(String connexionString, System.Web.UI.Page Page)
                : base(connexionString, Page) 
        {
            SQLTableName = "THREADS_ACCESS";
        }

        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            THREAD_ID = long.Parse(FieldsValues[1]);
            ID_U = long.Parse(FieldsValues[2]);
           
        }
        public override void Insert()
        {

            InsertRecord(THREAD_ID, ID_U);
        }

        public List<long> UserAcces(long UserId)
           {

               String Query = "Select THREAD_ID from " + SQLTableName + " where USER_ID = " + UserId;
               SqlConnection Connection;
               SqlDataReader Reader;
               List<long> id = new List<long>();
               // instancier l'objet de collection
               Connection = new SqlConnection(connexionString);
               // bâtir l'objet de requête
               SqlCommand sqlcmd = new SqlCommand(Query, Connection);
                 Page.Application.Lock();
               try
               {
                   Connection.Open();
                   Reader = sqlcmd.ExecuteReader();

                   while (Reader.Read())
                   {
                       id.Add(Reader.GetInt64(0));

                   }
                   Reader.Close();
               }
               catch (Exception)
               {
               }
               finally
               {
                   Connection.Close();
                   EndQuerySQL();            
               }
               return id;                               
    
           }

    }
}