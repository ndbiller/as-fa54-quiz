using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quiz
{
    class Questrionaire
    {
        int Id { get; set; }
        IList<Questrion> Questions { get; set; }

        Questrionaire(IList<Questrion> questions)
        {
            Questions = questions;
        }

        public bool Evaluate(decimal passThreshhold)
        {
            foreach (Questrion q in Questions)
            {
                q.Solve();
            }
            return true;
        }

    }
}
