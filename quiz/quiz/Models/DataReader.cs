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

        static public int[] GetQuestionIds(int dbID, int id)
        {
            switch (dbID)
            {
                case 0:
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

                case 1:
                    break;
                //dummy copy bitte durch ubi db ersetzen
                    List<int> query2 = binnenschifffahrt.T_Fragebogen_unter_Maschine.Where(no => no.FragebogenNr == id).Select(p => p.F_Id_SBF_Binnen).ToList<int>();
                    List<int> result2 = new List<int>();
                    foreach (int q in query)
                    {
                        if (!result.Contains(q))
                        {
                            result.Add(q);
                        }
                    }
                    return result2.ToArray();
                default:
                    return new int[] {0,0};
            }
            //this return will never happen, because of the switches default, but the compiler needs a return there..
            return new int[] { 0, 0 };
        }

        public static Question GetQuestion(int dbID, int id)
        {
            switch (dbID)
            {
                case 0:
                    quiz.T_SBF_Binnen question = binnenschifffahrt.T_SBF_Binnen.Where(a => a.P_Id == id).SingleOrDefault();
                    return new Question(question.P_Id, question.Frage, question.Antwort1, question.Antwort2, question.Antwort3, question.Antwort4, question.RichtigeAntwort);
                case 1:
                    //dummy copy bitte durch ubi db ersetzen
                    quiz.T_SBF_Binnen question2 = binnenschifffahrt.T_SBF_Binnen.Where(a => a.P_Id == id).SingleOrDefault();
                    return new Question(question2.P_Id, question2.Frage, question2.Antwort1, question2.Antwort2, question2.Antwort3, question2.Antwort4, question2.RichtigeAntwort);
                default:
                    return null;
            }

        }
    }
}