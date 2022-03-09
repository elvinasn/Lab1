using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace Lab1
{
    /// <summary>
    /// static class for in and out tasks
    /// </summary>
    public static class InOutUtils
    {
        /// <summary>
        /// reads the text from given path
        /// </summary>
        /// <param name="path">given file path</param>
        /// <returns>File text in list of strings</returns>
        public static List<string> ReadTextToLines(string path)
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }
        /// <summary>
        /// reads the text from given path, stores it in char array
        /// </summary>
        /// <param name="path">given file path</param>
        /// <returns>File text in array of char</returns>
        public static List<char> ReadText(string path)
        {
            List<char> allChars = new List<char>();
            using (var reader = new StreamReader(path, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    foreach (char ch in line)
                    {
                        if ((int)ch != 0x0A)
                            allChars.Add(ch);
                    }
                }
            }
            return allChars;
        }

        /// <summary>
        /// Reads words from given path
        /// </summary>
        /// <param name="path">given file path</param>
        /// <returns>returns list of words</returns>
        public static List<Word> ReadWords(string path)
        {
            List<Word> Words = new List<Word>();
            string[] values = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string value in values)
            {
                Word word = new Word(value.ToLower());
                Words.Add(word);
            }
            return Words;
        }

        /// <summary>
        /// prints given two-dimensional char array to txt file formatted like a matrix
        /// </summary>
        /// <param name="matrix">given two-dimensional array</param>
        /// <param name="path">given path of txt file where to print</param>

        public static void PrintMatrixToTXT(char[,] matrix, string path)
        {
            string dashes = new string('-', matrix.GetLength(0) * 4 + 1);
            string[] lines = new string[matrix.GetLength(0) * 2 + 1];
            int k = 0;
            lines[k] = dashes;
            k++;
            string line;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                line = "|";
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    line += (" " + matrix[i, j] + " |");
                }
                lines[k] = line;
                lines[k + 1] = dashes;
                k += 2;
            }
            File.WriteAllLines(path, lines);
        }
        
        /// <summary>
        /// prints given results to txt file
        /// </summary>
        /// <param name="n"> size of one charr array dimension</param>
        /// <param name="words">list of words</param>
        /// <param name="path">given path of results file</param>
        public static void PrintResultsToTXT(int n, List<Word> words, string path)
        {
            string[] lines = new string[words.Count + 1];
            lines[0] = string.Format("n = {0}", n);
            for(int i = 0; i < words.Count; i++)
            {
                lines[i + 1] = words[i].ToString();
            }
            File.WriteAllLines(path, lines);
        }
    }
}