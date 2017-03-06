using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quiz
{
    class Questionaire
    {
        int Id { get; set; }
        IList<Question> Questions { get; set; }

        Questionaire(IList<Question> questions)
        {
            Questions = questions;
        }

        public bool Evaluate(decimal passThreshhold)
        {
            foreach (Question q in Questions)
            {
                q.Solve();
            }
            return true;
        }

    }
}
