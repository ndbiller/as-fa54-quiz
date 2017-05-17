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

        public void LoadSettings()
        {
            if (UserHistory.Count > 0)
                foreach (History element in UserHistory)
                {
                    Title = element.AppTitle;
                    PassingPercentage = element.QuestionairePercentage;
                    QuestionLimit = element.QuestionaireLength;
                }
            else
            {
                Title = "Sportbootführerschein Binnen (unter Antriebsmaschine)";
                PassingPercentage = 95;
                QuestionLimit = 4;
            }
        }

        public List<string> EvaluateHistory()
        {
            // variables for results
            List<string> results = new List<string>();
            string displayedString = "";
            History previousElement = new History();
            int elementsMatch = 0;
            decimal percentage = -1;
            int correct = -1;
            decimal calcResult = -1;
            string ergebnis = "";

            // history auswerten, elements: AppTitle,DBID,QuestionaireID,QuestionaireLength,QuestionairePercentage,QuestionID,AnswerID,CorrectAnswer
            foreach (History element in UserHistory)
            {
                // compare previous element with current element
                // if they match
                if (previousElement.AppTitle == element.AppTitle && 
                    previousElement.DBID == element.DBID && 
                    previousElement.QuestionaireID == element.QuestionaireID && 
                    previousElement.QuestionaireLength == element.QuestionaireLength)
                {
                    elementsMatch += 1;
                    if (element.AnswerID == element.CorrectAnswer)
                    {
                        if (correct == -1)
                        {
                            correct = 1;
                        }
                        else
                        {
                            correct += 1;
                        }
                    }

                    // if previous and current are equal but current elements questionaireLength is also equal to matched elements
                    if (elementsMatch == element.QuestionaireLength)
                    {
                        // result calculation
                        percentage = element.QuestionairePercentage / 100;
                        calcResult = (decimal)correct / (decimal)elementsMatch;
                        // calculate result
                        if (calcResult >= percentage)
                            ergebnis = "bestanden";
                        else
                            ergebnis = "nicht bestanden";

                        // set the display string to the current elements values
                        displayedString = element.AppTitle + " (Fragebogen " + element.QuestionaireID + ") - " + ergebnis;
                        results.Add(displayedString);
                        elementsMatch = 0;
                        // reset values for result calculation
                        correct = 0;
                        percentage = -1;
                        calcResult = -1;
                        ergebnis = "";
                    }
                }
                // if previous has init values (e. g. first element)
                else if (previousElement.AppTitle == "" && previousElement.DBID == -1 && previousElement.QuestionaireID == -1 && previousElement.QuestionaireLength == -1)
                {
                    elementsMatch = 1;
                    if (element.AnswerID == element.CorrectAnswer)
                    {
                        if (correct == -1)
                        {
                            correct = 1;
                        }
                        else
                        {
                            correct += 1;
                        }
                    }

                    // if the first elements questionaireLength is one
                    if (elementsMatch == element.QuestionaireLength)
                    {
                        // result calculation
                        percentage = element.QuestionairePercentage / 100;
                        calcResult = (decimal)correct / (decimal)elementsMatch;
                        // calculate result
                        if (calcResult >= percentage)
                            ergebnis = "bestanden";
                        else
                            ergebnis = "nicht bestanden";

                        // set the display string to first elements values
                        displayedString = element.AppTitle + " (Fragebogen " + element.QuestionaireID + ") - " + ergebnis;
                        results.Add(displayedString);
                        elementsMatch = 0;
                        // reset values for result calculation
                        correct = 0;
                        percentage = -1;
                        calcResult = -1;
                        ergebnis = "";
                    }
                }
                else // if they don't match
                {
                    elementsMatch = 1;
                    if (element.AnswerID == element.CorrectAnswer)
                    {
                        if (correct == -1)
                        {
                            correct = 1;
                        }
                        else
                        {
                            correct += 1;
                        }
                    }

                    // if the new elements questionaireLength is one
                    if (elementsMatch == element.QuestionaireLength)
                    {
                        // result calculation
                        percentage = element.QuestionairePercentage / 100;
                        calcResult = (decimal)correct / (decimal)elementsMatch;
                        // calculate result
                        if (calcResult >= percentage)
                            ergebnis = "bestanden";
                        else
                            ergebnis = "nicht bestanden";

                        // set the display string to the elements values
                        displayedString = element.AppTitle + " (Fragebogen " + element.QuestionaireID + ") - " + ergebnis;
                        // add the elements displayedString
                        results.Add(displayedString);
                        // reset values for result calculation
                        correct = 0;
                        percentage = -1;
                        calcResult = -1;
                        ergebnis = "";
                    }
                }
                // lastly set current element as previous element
                previousElement = element;
            }

            return results;
        }

        // returns username as filename
        public string Filename()
        {
            return Name + ".txt";
        }

        // write and load other user settings
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
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ReadCSVFile ERROR: " + ex);
            }
        }

        public void DeleteCSVFile()
        {
            string file = @"C: \Users\Public\Documents\" + Filename();
            if (Directory.Exists(Path.GetDirectoryName(file)))
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("DeleteCSVFile ERROR: " + ex);
                } 
            }
        }
    }
}
