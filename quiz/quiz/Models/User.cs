using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using FileHelpers;
using System;
using System.Linq;

namespace quiz.Models
{
    // user class to hold and trigger save/load of user settings and history
    [DelimitedRecord(",")]
    public class User
    {
        // Properties to hold the settings
        public string Name { get; set; }
        public string Title { get; set; }
        public decimal PassingPercentage { get; set; }
        public string SelectedDB { get; set; }
        public List<History> UserHistory { get; set; }

        // Standard Constructor
        public User()
        {
            // TODO: if customUser.txt exists ReadCSVFile(customUser) else if defaultUser.txt exists ReadCSVFile() else
            Name = "defaultUser";
            Title = "Sportbootführerschein Binnen (unter Antriebsmaschine)";
            PassingPercentage = 95;
            // könnt ihr ja abändern wie benötigt, wird hier nur für neue default user als dummy zur anzeige gesetzt
            SelectedDB = "Binnenschifffahrt";
            UserHistory = new List<History>();
        }
        // Constructor to load user
        public User(string name, string title, decimal passingPercentage, string selectedDB, List<History> answerHistory)
        {
            Name = name;
            UserHistory = answerHistory;
            // Debug
            Trace.WriteLine("param ctor:");            
            Trace.WriteLine("QuestionaireID,QuestionID,AnswerID");
            foreach (History answer in UserHistory)
                Trace.WriteLine(answer.QuestionaireID + "," + answer.QuestionID + "," + answer.AnswerID);
            Trace.WriteLine("done creating with params.");
        }

        // returns username as filename
        public string Filename()
        {
            return Name + ".txt";
        }

        // TODO: write and load other user settings
        public void WriteCSVFile()
        {
            try
            {
                // filehelper object
                FileHelperEngine engine = new FileHelperEngine(typeof(History));
                // csv object
                List<History> csv = new List<History>();
                // convert any datasource to csv based object
                foreach (var item in UserHistory)
                    csv.Add(new History(item.QuestionaireID, item.QuestionID, item.AnswerID));                       
                // give header text
                engine.HeaderText = "QuestionaireID,QuestionID,AnswerID";
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
                var engine = new FileHelperEngine(typeof(History));
                // read the CSV file into your object Array
                var answers = (History[])engine.ReadFile(Path.Combine(@"C: \Users\Public\Documents\" + Filename()));
                if (answers.Any())
                {
                    // process your records as per your requirements
                    UserHistory = new List<History>();
                    foreach (var ids in answers)
                    {
                        // add it to your database, filter them etc
                        UserHistory.Add(new History(ids.QuestionaireID, ids.QuestionID, ids.AnswerID));
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
}
