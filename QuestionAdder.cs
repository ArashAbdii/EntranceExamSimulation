using EntranceExamSimulation.Models;
using EntranceExamSimulation.Data;

namespace Questioning;

public class QuestionAdder
{
    
    public string AddQues(string Questiontxt, string Answer1, string Answer2, string Answer3, string Answer4, int CorrectAnsr)
    {
        string messagetxt = "";
        try
        {
            using EntranceExamContext context = new EntranceExamContext();

            Queston Question = new Queston()
            {
                Question = Questiontxt,
                Answer1 = Answer1,
                Answer2 = Answer2,
                Answer3 = Answer3,
                Answer4 = Answer4,
                CorrectAnswer = CorrectAnsr
            };

            context.Questions.Add(Question);
            context.SaveChanges();

            messagetxt = "Question with Answers Added !";
        }
        catch (Exception ex) {
            messagetxt += ex.Message;
        }

        return messagetxt;
    }
}
