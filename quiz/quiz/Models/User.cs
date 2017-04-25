using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using FileHelpers;
using System;
using System.Linq;

namespace quiz.Models
{
    // user object to hold / save settings and answers (= questionaire history)
    [DelimitedRecord(",")]
    public class User
    {
        // Properties
        public string Name { get; set; }

        // TODO: save question id and selected answers with user data somewhere (maybe in csv text file, with settings? user object?)
        public List<SelectedAnswer> AnswerHistory { get; set; }

        // Standard Constructor
        public User()
        {
            // TODO: if customUser.txt exists ReadCSVFile(customUser) else if defaultUser.txt exists ReadCSVFile() else
            Name = "defaultUser";
            AnswerHistory = new List<SelectedAnswer>();
        }
        // Constructor to load user
        public User(string name, List<SelectedAnswer> answerHistory)
        {
            Name = name;
            AnswerHistory = answerHistory;
            // Debug
            Trace.WriteLine("param ctor:");            
            Trace.WriteLine("QuestionID;AnswerID");
            foreach (SelectedAnswer answer in AnswerHistory)
                Trace.WriteLine(answer.QuestionID + ";" + answer.AnswerID);
            Trace.WriteLine("done creating with params.");
        }

        public string Filename()
        {
            // returns username as filename
            return Name + ".txt";
        }

        public void WriteCSVFile()
        {
            try
            {
                // filehelper object
                FileHelperEngine engine = new FileHelperEngine(typeof(SelectedAnswer));
                // csv object
                List<SelectedAnswer> csv = new List<SelectedAnswer>();
                // convert any datasource to csv based object
                foreach (var item in AnswerHistory)
                    csv.Add(new SelectedAnswer(item.QuestionID, item.AnswerID));                       
                // give header text
                engine.HeaderText = "QuestionID,AnswerID";
                // save file locally
                engine.WriteFile(Path.Combine(@"C: \Users\Public\Documents\" + Filename()),csv);
                Trace.WriteLine("SUCCESS");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ERROR: " + ex);
            }
        }

        public void ReadCSVFile()
        {
            try
            {
                // file location, better to get it from configuration
                // create a CSV engine using FileHelpers for your CSV file
                var engine = new FileHelperEngine(typeof(SelectedAnswer));
                // read the CSV file into your object Array
                var answers = (SelectedAnswer[])engine.ReadFile(Path.Combine(@"C: \Users\Public\Documents\" + Filename()));
                if (answers.Any())
                {
                    // process your records as per your requirements
                    AnswerHistory = new List<SelectedAnswer>();
                    foreach (var ids in answers)
                    {
                        // add it to your database, filter them etc
                        AnswerHistory.Add(new SelectedAnswer(ids.QuestionID, ids.AnswerID));
                    }
                    Trace.WriteLine("SUCCESS");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ERROR: " + ex);
            }
        }
    }

    [DelimitedRecord(",")]
    [IgnoreEmptyLines()]
    [IgnoreFirst()]
    public class SelectedAnswer
    {
        // TODO: Rename to History, add questionaire id, move to own file

        // Properties
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }

        //public SelectedAnswer()
        //{
        //    // Dummy SelectedAnswer for testing
        //    // TODO: Catch NullException when constructor is empty or remove when set if both ids of previous SelectedAnswer are -1
        //    QuestionID = -1;
        //    AnswerID = -1;
        //}

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
