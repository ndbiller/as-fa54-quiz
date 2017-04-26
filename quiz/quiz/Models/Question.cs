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
        public string pathToImage = "";

        public Question(int id, string questionText, string answers1, string answers2, string answers3, string answers4, byte? correntAnswer)
        {
            ID = id;
            QuestionText = CleanUpQuestion(questionText);
            AnswerList = new List<Answer>();
            AnswerList.Add(new Answer(1, answers1, false, false));
            AnswerList.Add(new Answer(2, answers2, false, false));
            AnswerList.Add(new Answer(3, answers3, false, false));
            AnswerList.Add(new Answer(4, answers4, false, false));
            foreach(Answer a in AnswerList)
            {
                if(a.Index == (int)correntAnswer)
                {
                    a.CorrectAnswer = true;
                }
            }
        }

        string CleanUpQuestion(string questionText)
        {
            if (questionText.Contains("\\Binnen\\"))
            {
                string[] splitQuestion = questionText.Split('{');
                pathToImage = splitQuestion.Last().Replace("}", "");
                Trace.WriteLine("Q: " + splitQuestion.First() + " Path: " + pathToImage);
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
            //fehlt hier ein else? wird nicht jede antwort dann selected answer?
            AnswerList.ElementAt<Answer>(index).SelectedAnswer = true;
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
