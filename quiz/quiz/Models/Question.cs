using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace quiz.Models
{
	public class Question
    {
        // TODO: create an user object to hold / save settings and answers (= questionaire history)

        // Properties
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> AnswerList { get; set; }

        // Dummy Question Standard Constructor to test displaying of properties and view data binding
        //public Question()
        //{
        //    //ID = -1;
        //    //QuestionText = "Is this working?";
        //    //AnswerList = new List<string>();
        //    //AnswerList.Add("Yes.");
        //    //AnswerList.Add("No.");
        //    //AnswerList.Add("Maybe.");
        //    //AnswerList.Add("Still working on it.");
        //    //CorrectAnswer = 3;
        //    //AnswerSelected = -1;

        //    //// Debug
        //    //Trace.WriteLine("Question(AnswerList): " + AnswerList.ElementAt(0));
        //    //Trace.WriteLine("Question(AnswerList): " + AnswerList.ElementAt(1));
        //    //Trace.WriteLine("Question(AnswerList): " + AnswerList.ElementAt(2));
        //    //Trace.WriteLine("Question(AnswerList): " + AnswerList.ElementAt(3));
        //}

        public Question(int id, string questionText, List<Answer> answers)
        {
            ID = id;
            QuestionText = questionText;
            AnswerList = answers;
        }

        public void AnswerClicked(int index)
        {
            AnswerList.ElementAt<Answer>(index).CorrectAnswer = true;

            // Debug
            Trace.WriteLine("New Answer selected! Value is now " + AnswerList.ElementAt<Answer>(index).CorrectAnswer);
        }

        public bool Solve()
        {
            //// Debug
            //Trace.WriteLine("solving question...");

            //if (AnswerSelected == CorrectAnswer)
            //{
            //    // Debug
            //    Trace.WriteLine("answer correct");

            //    return true;
            //}
            //else
            //{
            //    // Debug
            //    if (AnswerSelected > -1)
            //        Trace.WriteLine("answer inorrect");
            //    else
            //        Trace.WriteLine("question not answered");

            //    return false;
            //}
            return true;
        }
    }
}
