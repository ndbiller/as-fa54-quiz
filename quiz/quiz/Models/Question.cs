using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace quiz.Models
{
	public class Question
    {
        // TODO: maybe create an answer object? (siehe QuestionViewModel)
        // TODO: create an user object to hold / save settings and answers (= questionaire history)

        // Properties
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public List<string> AnswerList { get; set; }
        public int CorrectAnswer { get; set; }
        // TODO: save question id and selected answers with user data somewhere (maybe in csv text file, with settings? user object?)
        public int AnswerSelected { get; set; }

        // Dummy Question Standard Constructor to test displaying of properties and view data binding
        public Question()
        {
            ID = -1;
            QuestionText = "Is this working?";
            AnswerList = new List<string>();
            AnswerList.Add("Yes.");
            AnswerList.Add("No.");
            AnswerList.Add("Maybe.");
            AnswerList.Add("Still working on it.");
            CorrectAnswer = 3;
            AnswerSelected = -1;

            // Debug
            Trace.WriteLine("Question(AnswerList): " + AnswerList.ElementAt(0));
            Trace.WriteLine("Question(AnswerList): " + AnswerList.ElementAt(1));
            Trace.WriteLine("Question(AnswerList): " + AnswerList.ElementAt(2));
            Trace.WriteLine("Question(AnswerList): " + AnswerList.ElementAt(3));
        }

        public Question(int id, string questionText, List<string> answers, int correctAnswer)
        {
            ID = id;
            QuestionText = questionText;
            AnswerList = answers;
            CorrectAnswer = correctAnswer;
            AnswerSelected = -1;
        }

        public void AnswerClicked(int index)
        {
            AnswerSelected = index;

            // Debug
            Trace.WriteLine("New Answer selected! Value is now " + AnswerSelected);
        }

        public bool Solve()
        {
            // Debug
            Trace.WriteLine("solving question...");

            if (AnswerSelected == CorrectAnswer)
            {
                // Debug
                Trace.WriteLine("answer correct");

                return true;
            }
            else
            {
                // Debug
                if (AnswerSelected > -1)
                    Trace.WriteLine("answer inorrect");
                else
                    Trace.WriteLine("question not answered");

                return false;
            }
        }
    }
}
