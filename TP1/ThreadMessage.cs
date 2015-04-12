using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP1
{
    public class ThreadMessage: SqlExpressUtilities.SqlExpressWrapper
    {
        long ID { get; set; }
        long Thread_ID { get; set; }
        long User_ID { get; set; }
        DateTime Date_Of_Creation { get; set; }
        String Message { get; set; }
        public ThreadMessage(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "THREADS_MESSAGES";
        }

        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            Thread_ID = long.Parse(FieldsValues[1]);
            User_ID = long.Parse(FieldsValues[2]);
            Date_Of_Creation = DateTime.Parse(FieldsValues[3]);
            Message = FieldsValues[4];
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
            SqlCommand sqlcmd = new SqlCommand(Query, Connection);
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

        public override void Insert()
        {
            InsertRecord(Thread_ID, User_ID, Date_Of_Creation, Message);
        }
    }
}