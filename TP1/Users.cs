using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            //UpdateRecord(ID,FullName,UserName,Password,Email,Avatar);
            String Query = "Update " + SQLTableName + " Set FullName ='" + FullName +"', " +
                "UserName ='" + UserName+"', "+"Password ='"+Password+"', Email = '" +
                Email+"', Avatar ='"+ Avatar+"' where ID = " + ID;

              SqlConnection Connection =   new SqlConnection(connexionString);
              SqlCommand sqlcmd = new SqlCommand(Query,Connection);   
               Page.Application.Lock();          
            try
            {
                Connection.Open();
                sqlcmd.ExecuteNonQuery();
            }
              catch (Exception)
            {               
            }
            finally
            {
                EndQuerySQL();               
            }
        }
        public long SelectId(String UN)
        { 

         String Query = "Select ID from " + SQLTableName + " Where UserName = '" + UN + "'";
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
              
                    while(Reader.Read())
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