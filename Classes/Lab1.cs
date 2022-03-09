using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class Lab1 : System.Web.UI.Page
    {
        /// <summary>
        /// fills asp table with two dimensional char array
        /// </summary>
        /// <param name="matrix">given two dimensional char array</param>
        /// <param name="Table1">table which to fill</param>
        protected static void FillTable(char[,] matrix, ref Table Table1)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                TableRow row = new TableRow();
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    TableCell cell = new TableCell();
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.VerticalAlign = VerticalAlign.Middle;
                    cell.Text = matrix[i, j].ToString();
                    cell.Width = 20;
                    cell.Height = 20;
                    row.Cells.Add(cell);
                }
                Table1.Rows.Add(row);
            }
        }
    }
}