using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace quiz.Models
{
    public class Questionaire
    {
        // set for display
        private int answeredCorrectly;

        int Id { get; set; }
        decimal Results { get; set; }
        public List<Question> Questions { get; set; }
        public string EvalMessage { get; set; }
        int[] questionIDs;
        int dbID;

        // get and set based on answered questions
        public int AnsweredCorrectly
        {
            get
            {
                return CountCorrect();
            }
            set
            {
                answeredCorrectly = CountCorrect();
            }
        }


        public Questionaire(int id, List<Question> questions)
        {
            Id = id;
            Questions = questions;
            Results = -1;
            AnsweredCorrectly = AnsweredCorrectly; // does this make sense? counts twice...
            EvalMessage = "";
        }

        public int CountCorrect()
        {
            int i = 0;
            foreach (Question question in Questions)
            {
                if (question.Solve())
                {
                    i++;
                }
            }
            Trace.WriteLine("counting...");
            return i;
        }

        public string EvaluateMessage(bool result)
        {
            if (result)
                return "Herzlichen Glückwunsch,&#10;Sie haben bestanden.";
            else
                return "Sie haben leider nicht bestanden.";

        public Questionaire(int dbID, int id)
        {
            Id = id;
            this.dbID = dbID;
            Results = 0;
            Questions = new List<Question>();
            questionIDs = ShuffleIDs(DataReader.GetQuestionIds(dbID, id));
            AddQuestion();
        }

        int[] ShuffleIDs(int[] unshuffledQuestionIDs)
        {
            List<int> randomized = new List<int>();
            List<int> original = new List<int>(unshuffledQuestionIDs);
            Random r = new Random();
            while (original.Count > 0)
            {
                int index = r.Next(original.Count);
                randomized.Add(original[index]);
                original.RemoveAt(index);
            }
            return randomized.ToArray();
        }

        int SelectNextQuestion()
        {
            return questionIDs[Questions.Count];
        }

        void AddQuestion()
        {
            if (Questions.Count < questionIDs.Length)
            {
                Questions.Add(DataReader.GetQuestion(dbID, SelectNextQuestion()));
            }
        }

        public bool Evaluate(decimal passThreshhold)
        {
            decimal i = AnsweredCorrectly;
            foreach (Question question in Questions)
            {
                if(question.Solve())
                {
                    i++;
                }
            }
            Results = ((i / Questions.Count) * 100);
            Trace.WriteLine("You answered " + i + "/" + Questions.Count + " correctly. Thats " + Results + "%.");   // Debug
            if (Results >= passThreshhold)
            {
                Trace.WriteLine("You passed since you got more than " + passThreshhold + "% correctly");            // Debug
                EvalMessage = EvaluateMessage(true);
                return true;
            }
            else
            {
                Trace.WriteLine("You failed since you got less than " + passThreshhold + "% correctly");            // Debug
                EvalMessage = EvaluateMessage(false);
                return false;
            }
        }

    }
}
