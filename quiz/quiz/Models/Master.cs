using System.Collections.Generic;

namespace quiz.Models
{
    class Master
    {
        public string WindowTitle { get; set; }
        decimal PassThreshhold { get; set; }
        List<int> PreviousQuestionaires { get; set; }
        List<Question> QuestionsForQuestionaire { get; set; }
    }
}
