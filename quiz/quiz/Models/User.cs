using System.Collections.Generic;
using System.Diagnostics;

namespace quiz.Models
{
    // user object to hold / save settings and answers (= questionaire history)
    public class User
    {
        // Properties
        public string Name { get; set; }

        // TODO: save question id and selected answers with user data somewhere (maybe in csv text file, with settings? user object?)
        public List<SelectedAnswer> AnswerHistory { get; set; }

        // Dummy User Standard Constructor to test displaying of properties and view data binding
        public User()
        {
            Name = "defaultUser";
            AnswerHistory = new List<SelectedAnswer>() { new SelectedAnswer() };
            AnswerHistory.Add(new SelectedAnswer(0,0));
        }

        public string Filename()
        {
            // returns username as filename
            string filename = Name + ".txt";
            return filename;
        }

        public void ToCSV()
        {
            // Debug 
            // testing filename for saving
            string filename = Filename();
            Trace.WriteLine(filename);
            // AnswerHistory as content for saving (Properties as headers)
            // TODO: add QuestionaireIDs
            Trace.WriteLine("QuestionID;AnswerID");
            foreach (SelectedAnswer answer in AnswerHistory)
                Trace.WriteLine(answer.QuestionID + ";" + answer.AnswerID);
        }
    }

    public class SelectedAnswer
    {
        public int QuestionID { get; private set; }
        public int AnswerID { get; private set; }

        public SelectedAnswer()
        {
            // Dummy SelectedAnswer for testing
            // TODO: Catch NullException when constructor is empty or remove when set if both ids of previous SelectedAnswer are -1
            QuestionID = -1;
            AnswerID = -1;
        }

        public SelectedAnswer(int questionID, int answerID)
        {
            QuestionID = questionID;
            AnswerID = answerID;
        }

        new public string ToString()
        {
            string myString = QuestionID + ";" + AnswerID;
            return myString;
        }
    }
}
