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
        public int Selected { get; set; }

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
            Console.WriteLine("trying to solve..");
            if (Selected == CorrectAnswer)
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
