using System;
using System.Collections.Generic;
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

        
    }
}