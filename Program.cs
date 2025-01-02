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

        private static async Task<string> ExaminerAsync(int timeout)
        {
            ConvertConsole.Enable();

            EntranceExamContext context = new EntranceExamContext();

            string ScoreMessage = null;
            int score = 0;
            var isTimeFninsih = false;


            Task Examin = Task.Run(() =>
            {

                var Questions = context.Questions;



                foreach (var Quest in Questions)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(ConvertConsole.ConvertString(ReverseLatinWord(Quest.Question.ToString())));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(1 + "-" + ReverseLatinWord(ConvertConsole.ConvertString(Quest.Answer1.ToString())));
                    Console.WriteLine(2 + "-" + ReverseLatinWord(ConvertConsole.ConvertString(Quest.Answer2.ToString())));
                    Console.WriteLine(3 + "-" + ReverseLatinWord(ConvertConsole.ConvertString(Quest.Answer3.ToString())));
                    Console.WriteLine(4 + "-" + ReverseLatinWord(ConvertConsole.ConvertString(Quest.Answer4.ToString())));
                    Console.WriteLine(5 + "-" + ConvertConsole.ConvertString("رد کردن"));

                    int userAnswer = int.Parse(Console.ReadLine());

                    if (userAnswer == Quest.CorrectAnswer)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Reverse_text("جواب شما درست است ."));
                        score++;
                    }
                    else if (userAnswer == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Kept");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Reverse_text($"پاسخ شما نادرست است . پاسخ درست گزینه {Quest.CorrectAnswer.ToString()} می باشد."));
                    }

                    if(isTimeFninsih)
                    {
                        break;
                    }
                }

                ScoreMessage = $"Your Score is {score}";
                
            });

            Task DelayTime = Task.Delay(timeout);

            await Task.WhenAny(Examin ,DelayTime);

            if (!Examin.IsCompleted) {
                ScoreMessage = ConvertConsole.ConvertString($"زمان آزمون شما به پایان رسید نمره شما : {score} است از {context.Questions.Count()}");
                isTimeFninsih = true;
            }

            return ScoreMessage;


        }


        static async Task Main(string[] args)
        {
            string examResult = await ExaminerAsync(10000);

            if (!string.IsNullOrEmpty(examResult))
                Console.WriteLine(examResult);

            Console.ReadKey();
        }
    }
}