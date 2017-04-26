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

        static private Byte ConvertAnserToByte(string data)
        {
            switch (data)
            {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                default:
                    return 0;
            }
        }

    static public int[] GetQuestionIds(int dbID, int id)
        {
            switch (dbID)
            {
                case 0:
                    List<int> query = binnenschifffahrt.T_Fragebogen_unter_Maschine.Where(x => x.FragebogenNr == id).Select(y => y.F_Id_SBF_Binnen).ToList<int>();
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
                    List<int> query2 = ubi.T_Fragebogen_Funk_UBI.Where(x => x.FragebogenNr == id).Select(y => y.F_id_Funk_UBI).ToList<int>();
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
                    quiz.T_SBF_Binnen question = binnenschifffahrt.T_SBF_Binnen.Where(x => x.P_Id == id).SingleOrDefault();
                    return new Question(question.P_Id, question.Frage, question.Antwort1, question.Antwort2, question.Antwort3, question.Antwort4, question.RichtigeAntwort);
                case 1:
                    //dummy copy bitte durch ubi db ersetzen
                    quiz.T_Funk_UBI question2 = ubi.T_Funk_UBI.Where(x => x.Id == id).SingleOrDefault();
                     return new Question(question2.Id, question2.Frage, question2.AntwortA, question2.AntwortB, question2.AntwortC, question2.AntwortD, ConvertAnserToByte(question2.RichtigeAntwort));
                default:
                    return null;
            }

        }


    }
}