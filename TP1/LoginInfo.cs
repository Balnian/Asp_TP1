using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using SqlExpressUtilities;
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
                                     td.Text = SQLHelper.FromSql(FieldsValues[fieldIndex]);
                         }
                         tr.Cells.Add(td);
                     }
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

    }
}