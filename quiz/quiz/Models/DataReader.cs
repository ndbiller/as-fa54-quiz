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
            List<int> result  = new List<int>();
            foreach (int q in query)
            {
                if (!result.Contains(q))
                {
                    result.Add(q);
                }
            }
            return result.ToArray();
        }

        //public static Question GetQuestion(string dbname, int id)
        //{
        //    switch (dbname)
        //    {
        //        case "binnen":
        //            quiz.T_SBF_Binnen question = binnenschifffahrt.T_SBF_Binnen.Where(a => a.P_Id == r.F_Id_SBF_Binnen).SingleOrDefault();
        //            return new Question(question.P_Id,,,,)

        //            break;
        //        case "ubi":
        //            int a = 0;
        //            break;
        //        default:
        //            int u = 0;
        //            break;
        //    }

        //}
    }
}
