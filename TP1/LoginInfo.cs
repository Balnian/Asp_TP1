using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using SqlExpressUtilities;
using System.Data.SqlClient;
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
            base.InitColumnsVisibility();
            SetColumnVisibility("ID", false);
              SetColumnVisibility("LogOutDate", false);       
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

        public void MakeThatGridView(Panel PN_GridView,long ID)
        {               
           Table Grid = null;        
           if (reader.HasRows)
           {
              Grid = new Table();          
              TableRow tr = new TableRow();           
              while (Next())
              {
                if(long.Parse(FieldsValues[1]) == ID)
                { 
                 tr = new TableRow();
                 String[] info = SelectInfo(long.Parse(FieldsValues[1]));

                 for (int fieldIndex = 0; fieldIndex < FieldsValues.Count; fieldIndex++)
                 {
                     if (ColumnsVisibility[fieldIndex])
                     {
                              TableCell td = new TableCell();
                               td.Text = FieldsValues[fieldIndex].ToString();
                                 td.CssClass = "numeric";                                                
                                  tr.Cells.Add(td);
                     }
                 }
                     for (int i = 0; i < info.Length; i++)
                     {
                          TableCell cell = new TableCell();
                          cell.Text = info[i];
                          cell.CssClass = "numeric";         
                          tr.Cells.Add(cell);
                     }
                 }                            
                 Grid.Rows.Add(tr);
              }
              Grid.CssClass = "table table-striped";
           }
           PN_GridView.Controls.Clear();
           if (Grid != null)
              PN_GridView.Controls.Add(Grid);
           EndQuerySQL();
           //////////////////////////////////////////////////////////////////
        }

        private String[] SelectInfo(long id)
        {
            String Query = "Select * from Users Where ID = " + id ;
            SqlConnection Connection;
            SqlDataReader Reader;
            String [] UserInfo = new String[3]; 
            
            // instancier l'objet de collection
            Connection = new SqlConnection(connexionString);
            // bâtir l'objet de requête
            SqlCommand sqlcmd = new SqlCommand(Query, Connection);
           
            try
            {
                Connection.Open();
                Reader = sqlcmd.ExecuteReader();
                while (Reader.Read())
                {
                   UserInfo[0] = Reader.GetString(1);
                   UserInfo[1] = Reader.GetString(3);
                   UserInfo[2] = Reader.GetString(4);
                }
                Reader.Close();
            }
            catch (Exception)
            {
            }
         
            return UserInfo;       
        }
    }
}