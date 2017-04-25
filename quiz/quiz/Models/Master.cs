using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace quiz.Models
{
    class Master
    {
        public string WindowTitle { get; set; }
        decimal PassThreshhold { get; set; }
        List<int> PreviousQuestionaires { get; set; }
        List<Question> QuestionsForQuestionaire { get; set; }

        public Master()
        {
            BinnenschifffahrtEntities binnenschifffahrt = new BinnenschifffahrtEntities();
            UBIEntities ubi = new UBIEntities();

            IQueryable<int> fragenQuery = binnenschifffahrt.T_SBF_Binnen.Select(d => d.P_Id);
            foreach(int i in fragenQuery)
            {
                Trace.WriteLine("Frage " + i + " " + fragenQuery.ToString());
            }
        }
        
        
            

    }
}
