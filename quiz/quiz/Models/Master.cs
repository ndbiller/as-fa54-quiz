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
        int[] ids;

        public Master()
        {
            //BinnenschifffahrtEntities binnenschifffahrt = new BinnenschifffahrtEntities();
            //UBIEntities ubi = new UBIEntities();
            //int i = 0;
            //
            //var result = binnenschifffahrt.T_Fragebogen_unter_Maschine.Where(a=> a.FragebogenNr == 2).ToList();
            ////List<T> fragen = new List<T>;
            //
            //Trace.WriteLine("Results: " + result.Count);
            //List<quiz.T_SBF_Binnen> questionList = new List<T_SBF_Binnen>();
            //foreach (var r in result)
            //{
            //    i++;
            //    quiz.T_SBF_Binnen question = binnenschifffahrt.T_SBF_Binnen.Where(a => a.P_Id == r.F_Id_SBF_Binnen).SingleOrDefault();
            //    //Trace.WriteLine(i + frage);
            //    
            //    //Trace.WriteLine(i + " " + question.P_Id + " " + question.Frage);
            //    //if(!questionList.Contains(question))
            //    //{
            //    //    questionList.Add(question);
            //    //}
            //}
            //
            //Trace.WriteLine("items: " + questionList.Count);
            //foreach(var q in questionList)
            //{
            //    Trace.WriteLine("Q: " + q.P_Id);
            //
            //}
            //foreach(var q in result)
            //{
            //    Trace.WriteLine("master" + q.F_Id_SBF_Binnen);
            //}
            //
            //ids = DataReader.GetQuestionIds(2);
            ////IQueryable<int> fragenQuery = binnenschifffahrt.T_SBF_Binnen.Where(d=> d.P_Id);
            ////foreach(int i in fragenQuery)
            ////{
            ////    Trace.WriteLine("Frage " + i + " " + fragenQuery.);
            ////}
        }
        
        
            

    }
}
