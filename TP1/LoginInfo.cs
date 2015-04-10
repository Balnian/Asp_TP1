using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1
{
    public class LoginInfo : SqlExpressUtilities.SqlExpressWrapper
    {
        public long ID{ get; set; }
        public long ID_U{ get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime LogOutDate { get; set; }
        public String IpAdresse { get; set; }

        public LoginInfo(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page) 
        {
            SQLTableName = "LOGINS";
        }

        public override void InitColumnsVisibility()
        {
            //ici reste a voir si on veut enelever la visibility de certaine columns
        }


        public override void InitColumnsSortEnable()
        {
            //sont la mais reste juste a voir si on veut enlever les sort de sertaine colonne
        }

        public override void InitColumnsTitles()
        {

        }



        public override void Insert()
        {
            InsertRecord(ID_U, LoginDate, LogOutDate, IpAdresse);
        }



    }
}