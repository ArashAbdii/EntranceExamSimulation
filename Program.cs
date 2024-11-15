using Questioning;

using EntranceExamSimulation.Models;
using EntranceExamSimulation.Data;
using System.Runtime.InteropServices;
using PersianConsole;

namespace EntranceExamSimulation
{
    internal class Program
    {
        public static string Reverse_text(string txt)
        {
            string newText = string.Empty;

            char[] txtSplit = txt.ToCharArray();

            for (int i = txt.Length - 1; i >= 0; i--)
            {
                newText += txtSplit[i];
            }

            return newText;
        }

        public static string ReverseLatinWord(string textString)
        {
            string[] splitedText = textString.Split(" ");

            for(int i = 0; i < splitedText.Length; i++)
            {
                string newReverseLatinWord = string.Empty;

                if ((int)splitedText[i][0] <= 127)
                {
                    for(int j = splitedText[i].Length - 1; j >= 0; j--)
                    {
                        newReverseLatinWord += splitedText[i][j];
                    }

                    splitedText[i] = newReverseLatinWord;
                }
            }

            return string.Join(" ", splitedText);
        }

        static void Main(string[] args)
        {


            Console.ReadKey();
        }
    }
}