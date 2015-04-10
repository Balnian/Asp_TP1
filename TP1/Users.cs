using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI;
using SqlExpressUtilities;

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
        //    base.InitColumnsTitles();
          //  base.InitColumnsSortEnable();
           
            SetColumnVisibility("ID", false);
            // SetColumnVisibility("FullName", false);
            SetColumnVisibility("PassWord", false);            
            SetColumnVisibility("Avatar", false);
            //SetColumnVisibility("Email", false);
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
                    UserName = Reader.GetString(1);
                    FullName = Reader.GetString(2);
                    Password = Reader.GetString(3);
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

        public override void MakeGridView(Panel PN_GridView, string EditPage)
        {
           // base.MakeGridView(PN_GridView, EditPage);
            // converver le panneau parent (utilisé dans certaines méthodes de cette classe)

           Table Grid = null;
           if (reader.HasRows)
           {
              Grid = new Table();
              // Construction de l'entête de la GridView
              TableRow tr = new TableRow();
              for (int columnIndex = 0; columnIndex < ColumnTitles.Count; columnIndex++)
              {
                 if (ColumnsVisibility[columnIndex])
                 {
                    TableCell td = new TableCell();
                    tr.Cells.Add(td);
                    Label LBL_Header = new Label();
                    LBL_Header.Text = "<b>" + ColumnTitles[columnIndex] + "</b>";

                    if (ColumnsSortEnable[columnIndex])
                    {
                       ImageButton BTN_Sort = new ImageButton();
                       // assignation du delegate du clic (voir sa définition plus bas dans le code)
                       BTN_Sort.Click += new ImageClickEventHandler(SortField_Click);
                       // IMPORTANT!!!
                       // il faut placer dans le répertoire Images du projet l'icône qui représente un tri
                       BTN_Sort.ImageUrl = @"~/Images/Sort.png";
                       // afin de bien reconnaitre quel champ il faudra trier on construit ici un ID
                       // pour le bouton
                       BTN_Sort.ID = "Sort_" + FieldsNames[columnIndex];
                       td.Controls.Add(BTN_Sort);
                    }
                    td.Controls.Add(LBL_Header);
                 }
              }
              Grid.Rows.Add(tr);

              // Construction des rangées de la GridView
              while (Next())
              {
                 tr = new TableRow();

                 TableCell tdimage = new TableCell();
                 Image image = new Image();
                 image.ImageUrl = @"~\Images\OffLine.png";
                 tdimage.Controls.Add(image);
                 tr.Cells.Add(tdimage);
                 for (int fieldIndex = 0; fieldIndex < FieldsValues.Count; fieldIndex++)
                 {
                    if (ColumnsVisibility[fieldIndex])
                    {
                       TableCell td = new TableCell();

                       if (CellsContentDelegate[fieldIndex] != null)
                       {
                          // construction spécialisée du contenu d'une cellule
                          // définie dans les sous classes
                          td.Controls.Add(CellsContentDelegate[fieldIndex]());
                       }
                       else
                       {
                          Type type = FieldsTypes[fieldIndex];
                          if (SQLHelper.IsNumericType(type))
                          {
                             td.Text = FieldsValues[fieldIndex].ToString();
                             // IMPORTANT! Il faut inclure dans la section style
                             // une classe numeric qui impose l'alignement à droite
                             td.CssClass = "numeric";
                          }
                          else
                             if (type == typeof(DateTime))
                                td.Text = DateTime.Parse(FieldsValues[fieldIndex]).ToShortDateString();
                             else
                                td.Text = SQLHelper.FromSql(FieldsValues[fieldIndex]);
                       }
                       tr.Cells.Add(td);
                    }

                    //Grid.Rows.Add(tr);
                 }
                 TableCell tdavatar = new TableCell();
                 Image imageA = new Image();
                 imageA.ImageUrl = @"~\Avatars/" + FieldsValues[5] + ".png";
                 tdavatar.Controls.Add(imageA);
                 tr.Cells.Add(tdavatar);

               

                 Grid.Rows.Add(tr);
              }
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
                 UserName = Reader.GetString(1);
                 FullName = Reader.GetString(2);
                 Password = Reader.GetString(3);
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
                    
    }
}