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
        public int SelectedDB { get; set; }
        public List<History> UserHistory { get; set; }
        public int SelectedQuestionaire { get; set; }
        public List<int> QuestionaireIDs { get; set; }

        // Debug-Properties
        public int QuestionLimit { get; set; }

        // Standard Constructor
        public User()
        {
            // TODO: if customUser.txt exists ReadCSVFile(customUser) else if defaultUser.txt exists ReadCSVFile() else
            Name = "defaultUser";
            Title = "Sportbootführerschein Binnen (unter Antriebsmaschine)";
            PassingPercentage = 95;
            // könnt ihr ja abändern wie benötigt, wird hier nur für neue default user als dummy zur anzeige gesetzt
            UserHistory = new List<History>();
            // used for questionaire creation from dropdown list
            SelectedQuestionaire = 1;
            // TODO: load questionaire ids from db and make second db selectable
            SelectedDB = 0;
            QuestionaireIDs = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            // Debug
            QuestionLimit = 4;
        }
        // Constructor with params, used to load user
        public User(string name, string title, decimal passingPercentage, int selectedDB, List<History> answerHistory, int selectedQuestionaire, List<int> questionaireIDs, int questionLimit)
        {
            Name = name;
            UserHistory = answerHistory;
            // Debug
            //Trace.WriteLine("param ctor:");            
            //Trace.WriteLine("QuestionaireID,QuestionID,AnswerID");
            Trace.WriteLine("tostring-test: " + UserHistory[0].CSVHeaders());
            foreach (History answer in UserHistory)
                //Trace.WriteLine(answer.QuestionaireID + "," + answer.QuestionID + "," + answer.AnswerID);
                Trace.WriteLine("tostring-test: " + answer.ToString());
            //Trace.WriteLine("done creating with params.");
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
                    csv.Add(new History(item.AppTitle, item.DBID, item.QuestionaireID, item.QuestionaireLength, item.QuestionairePercentage, item.QuestionID, item.AnswerID, item.CorrectAnswer));                       
                // give header text
                engine.HeaderText = UserHistory[0].CSVHeaders();
                // save file locally
                engine.WriteFile(Path.Combine(@"C: \Users\Public\Documents\" + Filename()),csv);
                Trace.WriteLine("WriteCSVFile SUCCESS");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("WriteCSVFile ERROR: " + ex);
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
                        UserHistory.Add(new History(ids.AppTitle, ids.DBID, ids.QuestionaireID, ids.QuestionaireLength, ids.QuestionairePercentage, ids.QuestionID, ids.AnswerID, ids.CorrectAnswer));
                    }
                    Trace.WriteLine("ReadCSVFile SUCCESS");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ReadCSVFile ERROR: " + ex);
            }
        }
    }
}
