using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Lab1
{
    public partial class Lab1 : System.Web.UI.Page
    {
        private const string TextPath = @"App_Data/Trecias.txt";
        private const string WordsPath = @"App_Data/Zodziai.txt";
        private const string MatrixPath = @"Rezultatai\Matrix.txt";
        private const string ResultsPath = @"Rezultatai\Results.txt";

        private char[,] Matrix = TaskUtils.ListToTwoDimensionalArray(InOutUtils.ReadText(HttpContext.Current.Server.MapPath(TextPath)));
        private List<Word> Words = InOutUtils.ReadWords(HttpContext.Current.Server.MapPath(WordsPath));
        private List<string> allText = InOutUtils.ReadTextToLines(HttpContext.Current.Server.MapPath(TextPath));
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Label1.Text = "Pradiniai duomenys faile <b>Trecias.txt</b>:";
            Label2.Text = TaskUtils.MultiLineToLabel(allText);
            InOutUtils.PrintMatrixToTXT(Matrix, Server.MapPath("~") + MatrixPath);

           
            Label3.Text = "Pradiniai duomenys faile <b>Zodziai.txt</b>:";
            Label4.Text = TaskUtils.MultiLineToLabel(Words);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(1 < Matrix.GetLength(0) &&
                Matrix.GetLength(0) < 45)
            {
                Label5.Text = "Matrica:";
                FillTable(Matrix, ref Table1);
                Label6.Text = "Rezultatai:";
                TaskUtils.CountWords(Matrix, Words);
                InOutUtils.PrintResultsToTXT(Matrix.GetLength(0), Words, Server.MapPath("~") + ResultsPath);
                Label7.Text = string.Format("n = {0}", Matrix.GetLength(0));
                Label8.Text = "Duotų žodžių kiekis:";
                Label9.Text = TaskUtils.ConvertCountOfWordToLabel(Words);
            }
            else
            {
                Label7.Text = "Netinkami pradiniai duomenys";
            }
            
            
        }
    }
}