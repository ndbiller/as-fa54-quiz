﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace quiz.Models
{
    public class Questionaire
    {
        // set for display
        private int answeredCorrectly;

        public int ID { get; set; }
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
                answeredCorrectly = CountCorrect();
                return answeredCorrectly;
            }
            set
            {
                answeredCorrectly = CountCorrect();
            }
        }

        //public Questionaire(int id, List<Question> questions)
        //{
        //    ID = id;
        //    Questions = questions;
        //    Results = -1;
        //    AnsweredCorrectly = AnsweredCorrectly; // does this make sense? method counts twice...
        //    EvalMessage = "";
        //}
        public Questionaire(int dbID, int id)
        {
            ID = id;
            this.dbID = dbID;
            Results = 0;
            Questions = new List<Question>();
            questionIDs = ShuffleIDs(DataReader.GetQuestionIds(dbID, id));
            foreach (int shuffledID in questionIDs)
                AddQuestion();
        }
        // mit limit zum leichteren debuggen
        public Questionaire(int dbID, int id, int limit)
        {
            //if (limit <= 0 || limit > 30)
            //    limit = 30;

            ID = id;
            this.dbID = dbID;
            Results = 0;
            Questions = new List<Question>();
            questionIDs = ShuffleIDs(DataReader.GetQuestionIds(dbID, id));
            // add limited number of questions for debugging
            List <int> limitedIDs = new List<int>();
            for (int i = 0; i < limit; i++)
            {
                //Trace.WriteLine("testing: i = " + i.ToString());
                limitedIDs.Add(questionIDs[i]);
            }
            questionIDs = limitedIDs.ToArray();
            foreach (int shuffledID in questionIDs)
                AddQuestion();
        }

        public int CountCorrect()
        {
            int i = 0;
            foreach (Question question in Questions)
                if (question.Solve())
                    i++;

            return i;
        }

        public string EvaluateMessage(bool result)
        {
            if (result)
                return "Herzlichen Glückwunsch, Sie haben bestanden.";
            else
                return "Sie haben leider nicht bestanden.";
        }

        int[] ShuffleIDs(int[] unshuffledQuestionIDs)
        {
            //List<int> randomized = new List<int>();
            //List<int> original = new List<int>(unshuffledQuestionIDs);
            //Random r = new Random();
            //while (original.Count > 0)
            //{
            //    int index = r.Next(original.Count);
            //    randomized.Add(original[index]);
            //    original.RemoveAt(index);
            //}
            //return randomized.ToArray();
            return unshuffledQuestionIDs;
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
            int i = CountCorrect();
            Results = (((decimal)i / (decimal)Questions.Count) * 100);
            Trace.WriteLine("You answered " + i + "/" + (decimal)Questions.Count + " correctly. Thats " + Results + "%.");   // Debug
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
