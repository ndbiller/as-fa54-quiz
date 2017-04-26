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
        public int correctAnswerID { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> AnswerList { get; set; }
        public int selectedAnswer = -1;

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

        public Question(int id, string questionText, string answers1, string answers2, string answers3, string answers4, byte? correntAnswer)
        {
            ID = id;
            QuestionText = questionText;

            //start giving indexes with 1 instead of 0 since correct answers are saved 1-4 in the db
            AnswerList = new List<Answer>();
            AnswerList.Add(new Answer(1, answers1));
            AnswerList.Add(new Answer(2, answers2));
            AnswerList.Add(new Answer(3, answers3));
            AnswerList.Add(new Answer(4, answers4));

            correctAnswerID = (int)correntAnswer;
        }

        public void AnswerClicked(int index)
        {

            //AnswerList.ElementAt<Answer>(index).CorrectAnswer = true;
            selectedAnswer = AnswerList[index].Index;

            // Debug
            //Trace.WriteLine("New Answer selected! Value is now " + AnswerList.ElementAt<Answer>(index).CorrectAnswer);
            Trace.WriteLine("New Answer selected! Value is now :" + AnswerList[index].Text);
        }

        public bool Solve()
        {
            // Debug
            Trace.WriteLine("solving question...");

            if (selectedAnswer == correctAnswerID)
            {
                // Debug
                Trace.WriteLine("answer correct");

                return true;
            }
            else
            {
                // -1 = no answer selected
                if (selectedAnswer > -1)
                    Trace.WriteLine("answer inorrect");
                else
                    Trace.WriteLine("question not answered");

                return false;
            }
        }
    }
}
