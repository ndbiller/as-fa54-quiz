using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quiz.Models
{
    class Questionaire
    {
        int Id { get; set; }
        decimal Results { get; set; }
        public IList<Question> Questions { get; set; }

        public Questionaire(IList<Question> questions)
        {
            Questions = questions;
        }

        public bool Evaluate(decimal passThreshhold)
        {
            decimal i = 0;
            foreach (Question q in Questions)
            {
                if(q.Solve())
                {
                    i++;
                }
            }
            Results = ((i / Questions.Count) * 100);
            Console.WriteLine("You answered " + i + "/" + Questions.Count + " correctly. Thats " + Results + "%.");
            

            if (Results >= passThreshhold)
            {
                Console.WriteLine("You passed since you got more than " + passThreshhold + "% correctly");
                return true;
            }
            else
            {
                Console.WriteLine("You failed since you got less than " + passThreshhold + "% correctly");
                return false;
            }
        }

    }
}
