﻿using System.Collections.Generic;
using System.Diagnostics;

namespace quiz.Models
{
    class Questionaire
    {
        int Id { get; set; }
        decimal Results { get; set; }
        public List<Question> Questions { get; set; }
        string dbName;
        public Questionaire(int id, string dbName)
        {
            this.dbName = dbName;
            int questionCount = DataReader.CountQuestions(id);
            DataReader.GetQuestion(dbName);
            Questions = questions;
        }

        public bool Evaluate(decimal passThreshhold)
        {
            decimal i = 0;
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
                return true;
            }
            else
            {
                Trace.WriteLine("You failed since you got less than " + passThreshhold + "% correctly");            // Debug
                return false;
            }
        }

    }
}
