using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace quiz.Models
{
	public class Question
    {
        // Properties
        public int ID { get; set; }
        public int DBID { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> AnswerList { get; set; }
        public string PathToImage { get; set; }

        public Question(int id, string questionText, string answers1, string answers2, string answers3, string answers4, byte? correntAnswer)
        {
            ID = id;
            QuestionText = CleanUpQuestion(questionText);
            AnswerList = new List<Answer>();
            AnswerList.Add(new Answer(0, answers1, false, false));
            AnswerList.Add(new Answer(1, answers2, false, false));
            AnswerList.Add(new Answer(2, answers3, false, false));
            AnswerList.Add(new Answer(3, answers4, false, false));
            foreach(Answer a in AnswerList)
            {
                Trace.WriteLine("a.Index: " + a.Index + " (int)correntAnswer: " + (int)correntAnswer);
                if (a.Index == (int)correntAnswer - 1)
                {
                    Trace.WriteLine("a.Index: " + a.Index + " (int)correntAnswer: " + (int)correntAnswer);
                    a.CorrectAnswer = true;
                }
            }
        }

        string CleanUpQuestion(string questionText)
        {
            PathToImage = "";
            if (questionText.Contains("\\Binnen\\"))
            {
                string[] splitQuestion = questionText.Split('{');
                string lastPart = splitQuestion.Last().Replace("}", "");
                string[] temp = lastPart.Split('\\');
                lastPart = temp.Last();
                PathToImage = "Images/Binnen/" + lastPart;
                return splitQuestion.First();
            }
            else
                return questionText;
        }

        public void AnswerClicked(int index)
        {
            foreach (Answer answer in AnswerList)
                if (answer.Index != index)
                    answer.SelectedAnswer = false;
                else
                    answer.SelectedAnswer = true;

            // Debug
            foreach (Answer answer in AnswerList)
                Trace.WriteLine("New Answer " + index + " selected! Value of Answer.SelectedAnswer at " + answer.Index + " is now " + answer.SelectedAnswer);
        }
        public void ForwardClicked(int nextQuestionID)
        {
            // Debug
            Trace.WriteLine("nextQuestionID is " + nextQuestionID + "! ID is now " + ID);
        }

        public bool Solve()
        {
            bool correct = false;
            foreach (Answer answer in AnswerList)
                if (answer.CorrectAnswer && answer.SelectedAnswer)
                    correct = true;
            return correct;
        }
    }
}
