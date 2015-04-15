using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI;
using SqlExpressUtilities;
using System.Web.UI.HtmlControls;

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
            UserName = FieldsValues[3];
            Password = FieldsValues[2];
            Email = FieldsValues[4];
            Avatar = FieldsValues[5];
        }

        public override void InitColumnsVisibility()
        {
            base.InitColumnsVisibility();
        //    base.InitColumnsTitles();
          //  base.InitColumnsSortEnable();
           
            SetColumnVisibility("ID", false);
            // SetColumnVisibility("FullName", false);
            SetColumnVisibility("PassWord", false);            
            SetColumnVisibility("Avatar", false);
            //SetColumnVisibility("Email", false);
        }

     

        public override void Insert()
        {
            InsertRecord(FullName,Password, UserName, Email, Avatar);
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
                Connection.Close();
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

                while (Reader.Read())                
               iD = Reader.GetInt64(0);                  
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
            return iD;
        }
        public void SetUserInfo(String UserName)
        {

            String Query = "Select * from " + SQLTableName + " Where UserName = '" + UserName + "'";
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
                {
                    iD = Reader.GetInt64(0);                  
                    FullName = Reader.GetString(1);
                    Password = Reader.GetString(2);
                    UserName = Reader.GetString(3);
                    Email = Reader.GetString(4);
                    Avatar = Reader.GetString(5);
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
                   
        }

        public  void MakeGridView(Panel PN_GridView, List<long> Online)
        {
           
           Table Grid = null;
        
           if (reader.HasRows)
           {
              Grid = new Table();          
              TableRow tr = new TableRow();           
              while (Next())
              {
                 tr = new TableRow();

                 TableCell tdimage = new TableCell();
                 Image image = new Image();

                 if (!Online.Contains(long.Parse(FieldsValues[0])))
                 image.ImageUrl = @"~\Images\OffLine.png";
                 else
                 image.ImageUrl = @"~\Images\Online.png";

                 tdimage.Controls.Add(image);
                 tr.Cells.Add(tdimage);
                 for (int fieldIndex = 0; fieldIndex < FieldsValues.Count; fieldIndex++)
                 {
                    if (ColumnsVisibility[fieldIndex])
                    {
                       TableCell td = new TableCell();

                       if (CellsContentDelegate[fieldIndex] != null)
                       {                          
                          td.Controls.Add(CellsContentDelegate[fieldIndex]());
                       }
                       else
                       {
                          Type type = FieldsTypes[fieldIndex];
                          if (SQLHelper.IsNumericType(type))
                          {
                             td.Text = FieldsValues[fieldIndex].ToString();                           
                             td.CssClass = "numeric";
                          }
                          else
                             if (type == typeof(DateTime))
                                td.Text = DateTime.Parse(FieldsValues[fieldIndex]).ToShortDateString();
                             else
                                 if(FieldsNames[fieldIndex]=="Email")
                                 {
                                     HtmlGenericControl abal =new HtmlGenericControl("a");
                                     abal.Attributes.Add("href", "mailto:" + SQLHelper.FromSql(FieldsValues[fieldIndex]));
                                     abal.InnerText = SQLHelper.FromSql(FieldsValues[fieldIndex]);
                                     td.Controls.Add(abal);
                                 }
                                     
                                 else
                                td.Text = SQLHelper.FromSql(FieldsValues[fieldIndex]);
                       }
                       tr.Cells.Add(td);
                    }                  
                 }
                 TableCell tdavatar = new TableCell();
                 Image imageA = new Image();
                 imageA.ImageUrl = @"~\Avatars/" + FieldsValues[5] + ".png";
                 imageA.CssClass = "img-responsive";
                 imageA.Width = new Unit(100);
                
                 tdavatar.Controls.Add(imageA);
                 tr.Cells.Add(tdavatar);              
                 Grid.Rows.Add(tr);

              }
              Grid.CssClass = "table table-striped";
           }
           PN_GridView.Controls.Clear();
           if (Grid != null)
              PN_GridView.Controls.Add(Grid);
           EndQuerySQL();
           ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void ReadUsers()
        {
           String Query = "Select * from " + SQLTableName;
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
              {
                 iD = Reader.GetInt64(0);                 
                 FullName = Reader.GetString(1);
                 Password = Reader.GetString(2);
                  UserName = Reader.GetString(3);
                 Email = Reader.GetString(4);
                 Avatar = Reader.GetString(5);
              }

              Reader.Close();
           }
           catch (Exception)
           {
           }
           finally
           {
              EndQuerySQL();
           }
        }

        public List<CheckBox> MakeAGridForThread(Panel PN_GridView)
        {

            Table Grid = null;
            List<CheckBox> cblist = new List<CheckBox>();
            
            if (reader.HasRows)
            {
                Grid = new Table();

                TableRow tr ;
               
                while (Next())
                {
                 
                    tr = new TableRow();

                    TableCell tdcheck = new TableCell();
                    CheckBox check = new CheckBox();
                    check.ID = FieldsValues[0].ToString();
                    tdcheck.Controls.Add(check);
                    tr.Cells.Add(tdcheck);
                    cblist.Add(check);
                    TableCell tdavatar = new TableCell();                    
                    Image imageA = new Image();
                    imageA.ImageUrl = @"~\Avatars/" + FieldsValues[5] + ".png";
                    imageA.CssClass = "img-responsive";
                    imageA.Width = new Unit(70);
                    tdavatar.Controls.Add(imageA);
                    tr.Cells.Add(tdavatar);
                    TableCell td = new TableCell();
                    td.Text = FieldsValues[2].ToString();
                    td.CssClass = "numeric";
                    tr.Cells.Add(td);
                    


                    Grid.Rows.Add(tr);

                }
               
                Grid.CssClass = "table table-condensed";
            }
            PN_GridView.Controls.Clear();
            if (Grid != null)
                PN_GridView.Controls.Add(Grid);
            EndQuerySQL();

            return cblist;              
        }


        public void listAccessThread(Panel PN_GridView, long Thread_id, List<long> online_user,long ThreadId)
        {
            Table Grid = null;
            if (reader.HasRows)
            {
                Grid = new Table();

                TableRow tr;              
                while (Next())
                {
                    tr = new TableRow();

                    TableCell tdavatar = new TableCell();
                    Image imageA = new Image();
                    imageA.ImageUrl = @"~\Avatars/" + FieldsValues[5] + ".png";
                    imageA.CssClass = "img-responsive";
                    imageA.Width = new Unit(40);
                    tdavatar.Controls.Add(imageA);
                    tr.Cells.Add(tdavatar);
                    TableCell td = new TableCell();
                    td.Text = FieldsValues[2].ToString();
                    td.CssClass = "numeric";
                    tr.Cells.Add(td);
                    TableCell tdimage = new TableCell();
                    Image image = new Image();

                    if (!online_user.Contains(long.Parse(FieldsValues[0])))
                        image.ImageUrl = @"~\Images\OffLine.png";
                    else
                        image.ImageUrl = @"~\Images\Online.png";

                    image.Width = new Unit(30);
                    tdimage.Controls.Add(image);
                    tr.Cells.Add(tdimage);
                    Grid.Rows.Add(tr);

                }

                Grid.CssClass = "table-condensed";
            }
            PN_GridView.Controls.Clear();
            if (Grid != null)
                PN_GridView.Controls.Add(Grid);
            EndQuerySQL();

        
        
        
        }

        public bool PassWordVerif(String Un, String pw)
        {


            String Query = "Select PassWord from " + SQLTableName + " Where UserName = '" + Un + "'";
            SqlConnection Connection;
            SqlDataReader Reader;
            String Pw = "";
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
                    Pw = Reader.GetString(0);
                    
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
                   
         return Pw == pw ? true : false;
        
        
        
        
        }

    }
}