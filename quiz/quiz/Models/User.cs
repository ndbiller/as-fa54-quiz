using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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
            // TODO: if defaultUser.txt exists LoadUser() else
            Name = "defaultUser";
            AnswerHistory = new List<SelectedAnswer>() { new SelectedAnswer() };
            // TODO: remove this dummy
            AnswerHistory.Add(new SelectedAnswer(0,0));
        }
        // TODO: param ctor to load user

        public string Filename()
        {
            // returns username as filename
            return Name + ".txt";
        }

        public void ToCSV()
        {
            // Debug 
            Trace.WriteLine("ToCSV():");
            // testing filename for saving
            string filename = Filename();
            Trace.WriteLine("Filename(): " + filename);
            // ToString Test
            Trace.WriteLine("Name:" + Name);
            Trace.WriteLine("AnswerHistory:" + AnswerHistory.ToString());
            // AnswerHistory as content for saving (Properties as headers)
            // TODO: add QuestionaireIDs
            Trace.WriteLine("CSV:");
            Trace.WriteLine("QuestionID;AnswerID");
            foreach (SelectedAnswer answer in AnswerHistory)
                Trace.WriteLine(answer.QuestionID + ";" + answer.AnswerID);
            // testing
            SaveUser();
            Trace.WriteLine("...done saving.");
            LoadUser();
            Trace.WriteLine("...done loading.");
        }

        public void SaveUser()
        {
            // Create a dummy string array that consists of lines. 
            string[] lines = { "Headers,moreHeaders", "Data,moreData", "someMoreData,andEvenMoreData" };
            
            // TODO: get data from class

            // Save defaultUser to file
            File.WriteAllLines(@"C: \Users\Public\Documents\" + Filename(), lines);
            
            // Debug
            Trace.WriteLine("done saving.");

            // TODO: use given username, given location, what if file exists?
        }

        public void LoadUser()
        {
            // Load defaultUser from file
            string[] lines = File.ReadAllLines(@"C: \Users\Public\Documents\" + Filename());

            // TODO: give data to class

            // Debug
            Trace.WriteLine("lines: " + lines.ToString());
            Trace.WriteLine("loaded CSV:");
            foreach (string line in lines)
                Trace.WriteLine(line);
            Trace.WriteLine("done saving.");

            // TODO: use given username, given location
        }
    }

    public class SelectedAnswer
    {
        // TODO: Move (and use) this to Answer Class

        // Properties
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
