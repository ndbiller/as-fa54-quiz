using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quiz
{
    class Questionaire
    {
        int Id { get; set; }
        decimal results { get; set; }
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
            results = ((i / Questions.Count) * 100);
            Console.WriteLine("You answered " + i + "/" + Questions.Count + " correctly. Thats " + results + "%.");
            

            if (results >= passThreshhold)
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
