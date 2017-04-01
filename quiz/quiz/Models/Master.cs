using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quiz
{
    class Master : ObservableObject
    {
        public string WindowTitle { get; set; }
        decimal PassThreshhold { get; set; }
        IList<int> PreviousQuestionaires { get; set; }
        IList<Question> QuestionsForQuestionaire { get; set; }
    }
}
