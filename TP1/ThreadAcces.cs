using System;
using System.Collections.Generic;
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

    }
}