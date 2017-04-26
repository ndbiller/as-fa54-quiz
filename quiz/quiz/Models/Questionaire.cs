using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace quiz.Models
{
    public class Questionaire
    {
        int Id { get; set; }
        decimal Results { get; set; }
        public List<Question> Questions { get; set; }
        int[] questionIDs;
        int dbID;
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
