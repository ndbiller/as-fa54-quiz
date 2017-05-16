using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace quiz.Models
{
    [DelimitedRecord(",")]
    [IgnoreEmptyLines()]
    [IgnoreFirst()]
    public class History
    {
        // Properties
        public string AppTitle { get; set; }
        public int DBID { get; set; }
        public int QuestionaireID { get; set; }
        public int QuestionaireLength { get; set; }
        public decimal QuestionairePercentage { get; set; }
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }
        public int CorrectAnswer { get; set; }

        // ctor, used for Histoy Evaluation in User
        public History()
        {
            AppTitle = "";
            DBID = -1;
            QuestionaireID = -1;
            QuestionaireLength = -1;
            QuestionairePercentage = -1;
            QuestionID = -1;
            AnswerID = -1;
            CorrectAnswer = -1;
        }
        // param ctor, used to load defaultUser from file
        public History(string appTitle, int dbID, int questionaireID, int questionaireLength, decimal questionairePercentage, int questionID, int answerID, int correctAnswer)
        {
            AppTitle = appTitle;
            DBID = dbID;
            QuestionaireID = questionaireID;
            QuestionaireLength = questionaireLength;
            QuestionairePercentage = questionairePercentage;
            QuestionID = questionID;
            AnswerID = answerID;
            CorrectAnswer = correctAnswer;
        }

        public string CSVHeaders()
        {
            return "AppTitle,DBID,QuestionaireID,QuestionaireLength,QuestionairePercentage,QuestionID,AnswerID,CorrectAnswer";
        }

        // TODO: remove, possibly not needed because of filehelper
        new public string ToString()
        {
            return AppTitle + "," + DBID + "," + QuestionaireID + "," + QuestionaireLength + "," + QuestionairePercentage + "," + QuestionID + "," + AnswerID + "," + CorrectAnswer;
        }
    }
}
