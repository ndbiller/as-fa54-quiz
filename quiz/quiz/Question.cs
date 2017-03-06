using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quiz
{
    public class Question
    {
        int Id { get; set; }
        string QuestionText { get; set; }
        IList<string> Answers { get; set; }
        int CorrectAnswer { get; set; }
        int Selected { get; set; }

        public Question(int id, string questionText, IList<string> answers, int correctAnswer)
        {
            Id = id;
            QuestionText = questionText;
            Answers = answers;
            CorrectAnswer = correctAnswer;
            Selected = 999;
        }

        public bool Solve()
        {

            if (Selected == CorrectAnswer)
                return true;
            else
                return false;
        }

    }
}
