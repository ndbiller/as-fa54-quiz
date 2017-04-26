using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace quiz.Models
{
    static class DataReader
    {
        static BinnenschifffahrtEntities binnenschifffahrt = new BinnenschifffahrtEntities();
        static UBIEntities ubi = new UBIEntities();

        static public int[] GetQuestionIds(int id)
        {
            List<int> query = binnenschifffahrt.T_Fragebogen_unter_Maschine.Where(no => no.FragebogenNr == id).Select(p => p.F_Id_SBF_Binnen).ToList<int>();
            List<int> result = new List<int>();
            foreach (int q in query)
            {
                if (!result.Contains(q))
                {
                    result.Add(q);
                }
            }
            return result.ToArray();
        }

        public static Question GetQuestion(string dbname, int id)
        {
            switch (dbname)
            {
                case "binnen":
                    quiz.T_SBF_Binnen question = binnenschifffahrt.T_SBF_Binnen.Where(a => a.P_Id == id).SingleOrDefault();
                    return new Question(question.P_Id, question.Frage, question.Antwort1, question.Antwort2, question.Antwort3, question.Antwort4, question.RichtigeAntwort);
                case "ubi":
                    //dummy copy
                    quiz.T_SBF_Binnen question2 = binnenschifffahrt.T_SBF_Binnen.Where(a => a.P_Id == id).SingleOrDefault();
                    return new Question(question2.P_Id, question2.Frage, question2.Antwort1, question2.Antwort2, question2.Antwort3, question2.Antwort4, question2.RichtigeAntwort);
                    break;
                default:
                    return null;
            }

        }
    }
}
