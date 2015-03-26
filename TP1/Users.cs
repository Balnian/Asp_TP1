using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1
{
    public class Users : SqlExpressUtilities.SqlExpressWrapper
    {
     
        //Variable for Users table
        public long ID{ get; set; }
        public String UserName { get; set; }
        public String FullName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Avatar { get; set; }


        public Users(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page) 
        {
            SQLTableName = "USERS";
        }
        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            FullName = FieldsValues[1];
            UserName = FieldsValues[2];
            Password = FieldsValues[3];
            Email = FieldsValues[4];
            Avatar = FieldsValues[5];

        }

        public override void InitColumnsVisibility()
        {
            base.InitColumnsVisibility();
            //SetColumnVisibility("Avatar", false);
            SetColumnVisibility("ID", false);
        }

        public override void InitColumnsSortEnable()
        {
            //reste a voir les columns quon veut pas dans la gridview
        }

        public override void InitColumnsTitles()
        {
            //reste a voir les columns quon veut pas dans la gridview
        }

        public override void Insert()
        {
            InsertRecord(FullName,UserName, Password, Email, Avatar);
        }

        
        public override void Update()
        {
            UpdateRecord();
        }


    }
}