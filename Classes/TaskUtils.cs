using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab1
{
    /// <summary>
    /// static class to store tasks
    /// </summary>
    public static class TaskUtils
    {
        /// <summary>
        /// converts multiline to one label
        /// </summary>
        /// <param name="lines">multiline list</param>
        /// <returns>multiline label</returns>
        public static string MultiLineToLabel(List<string> lines)
        {
            string label = "";
            for(int i = 0; i < lines.Count; i++)
            {
                label += lines[i];
                if(i != lines.Count - 1)
                {
                    label += "<br/>";
                }
            }
            return label;
        }

        /// <summary>
        /// converts multiline to one label
        /// </summary>
        /// <param name="words">words</param>
        /// <returns>multiline label</returns>
        public static string MultiLineToLabel(List<Word> words)
        {
            string label = "";
            for (int i = 0; i < words.Count; i++)
            {
                label += words[i].Value;
                if (i != words.Count - 1)
                {
                    label += "<br/>";
                }
            }
            return label;
        }

        /// <summary>
        /// converts words to multiline label
        /// </summary>
        /// <param name="words">list of words</param>
        /// <returns>multiline label</returns>
        public static string ConvertCountOfWordToLabel(List<Word> words)
        {
            string label = "";
            for (int i = 0; i < words.Count; i++)
            {
                label += words[i].ToString();
                if (i != words.Count - 1)
                {
                    label += "<br/>";
                }
            }
            return label;
        }

        /// <summary>
        /// converts list of chars to matrix
        /// </summary>
        /// <param name="allChars">list of chars</param>
        /// <returns>a matrix of chars</returns>
        public static char[,] ListToTwoDimensionalArray(List<char> allChars)
        {
            int size = Convert.ToInt32(Math.Ceiling(Math.Sqrt(allChars.Count)));
            int k = 0;
            char[,] matrix = new char[size, size];
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    matrix[i, j] = k < allChars.Count ? matrix[i, j] = allChars[k] : ' ';
                    k++;
                }
            }
            return matrix;
        }

        /// <summary>
        /// counts given words in given matrix
        /// </summary>
        /// <param name="matrix">matrix where to find</param>
        /// <param name="Words">words which to find</param>
        public static void CountWords(char[,] matrix, List<Word> Words)
        {
            int shortest = -1;
            foreach (Word word in Words)
                if (shortest == -1 || word.Value.Length < shortest)
                    shortest = word.Value.Length;
            MoveToSide(matrix, Words, 0, shortest);
            MoveDown(matrix, Words, 0, shortest);
        }

        /// <summary>
        /// moves coordinate to right side and searches for given words in that column and diagonal, which starts in that coordinate
        /// </summary>
        /// <param name="matrix">given matrix of chars</param>
        /// <param name="Words">given words to find</param>
        /// <param name="coordinate">which coordinate</param>
        /// <param name="shortest">shortest word lenght to look for</param>
        public static void MoveToSide(char[,] matrix, List<Word> Words, int coordinate, int shortest)
        {
            int coordinateX = coordinate;
            int coordinateY = 0;
            string line = GetColumn(matrix, coordinateX);
            AddCount(line, Words);
            int diagonalLength = matrix.GetLength(1) - coordinateX;
            if(diagonalLength < shortest || coordinateX == 0)
            {
                if (coordinateX + 1 >= matrix.GetLength(0))
                    return;
                MoveToSide(matrix, Words, coordinateX + 1, shortest);
                return;
            }

            line = GetDiagonal(matrix, diagonalLength, coordinateX, coordinateY);
            AddCount(line, Words);

            
            if (coordinateX + 1 >= matrix.GetLength(0))
                return;
            MoveToSide(matrix, Words, coordinateX + 1, shortest);

        }

        /// <summary>
        /// moves coordinate down and searches for given words in that row and diagonal, which starts in that coordinate
        /// </summary>
        /// <param name="matrix">given matrix of chars</param>
        /// <param name="Words">given words to find</param>
        /// <param name="coordinate">which coordinate</param>
        /// <param name="shortest">shortest word lenght to look for</param>
        public static void MoveDown(char[,] matrix, List<Word> Words, int coordinate, int shortest)
        {
            int coordinateX = 0;
            int coordinateY = coordinate;
            string line = GetRow(matrix, coordinateY);
            AddCount(line, Words);

            int diagonalLength = matrix.GetLength(0) - coordinateY;
            if(diagonalLength < shortest)
            {
                if (coordinateY + 1 >= matrix.GetLength(0))
                    return;

                MoveDown(matrix, Words, coordinateY + 1, shortest);

            }

            line = GetDiagonal(matrix, diagonalLength, coordinateX, coordinateY);
            AddCount(line, Words);
            if (coordinateY + 1 >= matrix.GetLength(0))
                return;
            MoveDown(matrix, Words, coordinateY + 1, shortest);

        }

        /// <summary>
        /// gets column of matrix
        /// </summary>
        /// <param name="matrix">given matrix</param>
        /// <param name="columnNum">given column num(starts with 0)</param>
        /// <returns>given column converted to string</returns>
        public static string GetColumn(char[,] matrix, int columnNum)
        {
            string temp = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
                temp += matrix[i, columnNum];
            return temp;
        }

        /// <summary>
        /// gets column of row
        /// </summary>
        /// <param name="matrix">given matrix</param>
        /// <param name="rowNum">given row num(starts with 0)</param>
        /// <returns>given row converted to string</returns>
        public static string GetRow(char[,] matrix, int rowNum)
        {
            string temp = "";
            for (int i = 0; i < matrix.GetLength(1); i++)
                temp += matrix[rowNum, i];
            return temp;
        }

        /// <summary>
        /// gets diagonal by starting coordinate
        /// </summary>
        /// <param name="matrix">given matrix</param>
        /// <param name="diagonalLength">given diagonal length</param>
        /// <param name="coordinateX">X coordinate where to start</param>
        /// <param name="coordinateY"> Y coordinate where to start</param>
        /// <returns></returns>
        public static string GetDiagonal(char[,] matrix, int diagonalLength, int coordinateX, int coordinateY)
        {
            string temp = "";
            for( int i = 0; i < diagonalLength; i++)
            {
                temp += matrix[coordinateY + i, coordinateX + i];
            }
            return temp;
        }

        /// <summary>
        /// adds count to words if there is that word in given line
        /// </summary>
        /// <param name="line">given line</param>
        /// <param name="Words">given words</param>
        public static void AddCount(string line, List<Word> Words)
        {
            foreach (Word word in Words)
            {
                MatchCollection matches = Regex.Matches(line.ToLower(), word.Value);
                word.Count += matches.Count;
            }
        }

    }
}