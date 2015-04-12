using System;
using System.Collections.Generic;
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

        public override void Insert()
        {
            InsertRecord(creator, title, date);
        }
    }
}