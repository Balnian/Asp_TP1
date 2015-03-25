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
            ID = long.Parse(this["ID"]);
            UserName = this["Username"];
            Password = this["PassWord"];
            Email = this["Email"];
            Avatar = this["Avatar"];
        }

        public override void InitColumnsVisibility()
        {
            base.InitColumnsVisibility();
            SetColumnVisibility("Avatar", false);
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
            InsertRecord(UserName, Password, Email, Avatar);
        }

        
        public override void Update()
        {
            UpdateRecord(ID, UserName, Password, Email, Avatar);
        }


    }
}