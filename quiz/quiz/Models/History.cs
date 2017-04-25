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
        public int QuestionaireID { get; set; }
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }

        // ctor, used to create new defaultUser if file doesn't exist
        public History()
        {

        }
        // param ctor, used to load defaultUser from file
        public History(int questionaireID, int questionID, int answerID)
        {
            QuestionaireID = questionaireID;
            QuestionID = questionID;
            AnswerID = answerID;
        }

        // TODO: remove, possibly not needed because of filehelper
        new public string ToString()
        {
            return QuestionaireID + "," + QuestionID + "," + AnswerID;
        }
    }
}
