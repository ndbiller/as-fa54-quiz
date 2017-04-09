using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace quiz.Models
{
	public class Question
    {
        // TODO: maybe create an answer object?

        // Properties
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public IList<string> AnswerList { get; set; }
        public int CorrectAnswer { get; set; }
        // TODO: save question id and selected answers with user data somewhere (maybe in csv text file, with settings?)
        public int AnswerSelected { get; set; }

        // Dummy Question Standard Constructor to test displaying of properties and view data binding
        public Question()
        {
            ID = 0;
            QuestionText = "Is this working?";
            Answer1 = "Yes.";
            Answer2 = "No.";
            Answer3 = "Maybe.";
            Answer4 = "In every way.";
            AnswerList = new List<string>();
            AnswerList.Add(Answer1);
            AnswerList.Add(Answer2);
            AnswerList.Add(Answer3);
            AnswerList.Add(Answer4);
            CorrectAnswer = 3;
        }

        public Question(int id, string questionText, IList<string> answers, int correctAnswer)
        {
            ID = id;
            QuestionText = questionText;
            AnswerList = answers;
            CorrectAnswer = correctAnswer;
            AnswerSelected = 999;
        }

        public bool Solve()
        {
            Console.WriteLine("trying to solve..");
            if (AnswerSelected == CorrectAnswer)
            {
                Console.WriteLine("Answer Correct");
                return true;
            }
            else
            {
                Console.WriteLine("Answer Inorrect");
                return false;
            }
        }
    }
}
