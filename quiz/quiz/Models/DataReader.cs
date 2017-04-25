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
        
        static public int CountQuestions(int id)
        {
            var result = binnenschifffahrt.T_Fragebogen_unter_Maschine.Where(a => a.FragebogenNr == id).ToList();
            Trace.WriteLine("Results: " + result.Count);

            return result.Count;
        }

        public static Question GetQuestion(string dbname)
        {
            switch(dbname)
            {
                case "binnen":
                    int i = 0;
                    break;
                case "ubi":
                    int a = 0;
                    break;
                default:
                    int u = 0;
                    break;
            }

        }
    }


}
