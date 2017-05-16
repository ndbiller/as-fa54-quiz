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

        public List<string> EvaluateHistory()
        {
            // variables for results
            List<string> results = new List<string>();
            string displayedString = "";

            // foreach logic vars, init values are -1
            int currentDBID = -1;
            int currentQuestionaireID = -1;
            int currentQuestionaireLength = -1;

            // used to check if there are as many answered questions per questionaire as we expected
            int observedLength = 0;

            // hold the temp results for display string
            string tempTitle = "";
            int tempID = -1;

            // history auswerten, elements: AppTitle,DBID,QuestionaireID,QuestionaireLength,QuestionairePercentage,QuestionID,AnswerID,CorrectAnswer
            foreach (History element in UserHistory)
            {
                // on first element (set to history element values if all logic vars are init value -1)
                if (currentDBID == -1 && 
                    currentQuestionaireID == -1 && 
                    currentQuestionaireLength == -1)
                {
                    // set to element values
                    currentDBID = element.DBID;
                    currentQuestionaireID = element.QuestionaireID;
                    currentQuestionaireLength = element.QuestionaireLength;

                    // set the checkup value to init
                    observedLength = 1;

                    // set the temp results
                    tempTitle = element.AppTitle;
                    tempID = element.QuestionaireID;

                    // set the result string to set element values
                    displayedString = tempTitle + " (Fragebogen " + tempID + ") - " + "bestanden/nicht bestanden";

                    Trace.WriteLine("ONCE");
                }
                else // on all following elements (if even one of the logic vars is set to something else than init value -1)
                {
                    // set to element values
                    currentDBID = element.DBID;
                    currentQuestionaireID = element.QuestionaireID;
                    currentQuestionaireLength = element.QuestionaireLength;

                    Trace.WriteLine("x outside: " + currentDBID + "=" + element.DBID + "," + currentQuestionaireID + "=" + element.QuestionaireID + "," + currentQuestionaireLength + "=" + element.QuestionaireLength);
                    // compare the logic vars with element values, if they all match it is still the same set
                    // and compare the observedLength with QuestionaireLength and count it up if it is less
                    if (currentDBID == element.DBID && 
                        currentQuestionaireID == element.QuestionaireID && 
                        currentQuestionaireLength == element.QuestionaireLength)
                    {
                        Trace.WriteLine("x inside: " + currentDBID + "="+ element.DBID + "," + currentQuestionaireID + "=" + element.QuestionaireID + "," + currentQuestionaireLength + "=" + element.QuestionaireLength);
                        Trace.WriteLine("more outside: " + observedLength + " < " + element.QuestionaireLength);
                        // if there are more expected elements in this set
                        if (observedLength < element.QuestionaireLength)
                        {
                            Trace.WriteLine("more inside: " + observedLength + " < " + element.QuestionaireLength);
                            // increase the checkup length value
                            observedLength += 1;
                        }
                        else if (observedLength == element.QuestionaireLength) // we have reached the last set element 
                        {
                            Trace.WriteLine("more else if: " + observedLength + "==" + element.QuestionaireLength);
                            Trace.WriteLine("<<<<<< Add(" + displayedString + ")");
                            // write the temp result to the result list
                            results.Add(displayedString);
                        }
                        else
                        {
                            Trace.WriteLine("more else: " + observedLength + ", " + element.QuestionaireLength);
                        }
                    }
                    else // if not we are in the next set of elements
                    {
                        Trace.WriteLine("x else: " + currentDBID + "=" + element.DBID + "," + currentQuestionaireID + "=" + element.QuestionaireID + "," + currentQuestionaireLength + "=" + element.QuestionaireLength);
                        // set to element values
                        currentDBID = element.DBID;
                        currentQuestionaireID = element.QuestionaireID;
                        currentQuestionaireLength = element.QuestionaireLength;

                        // set the checkup value to init
                        observedLength = 1;

                        // set the temp results
                        tempTitle = element.AppTitle;
                        tempID = element.QuestionaireID;

                        // set the result string to set element values
                        displayedString = tempTitle + " (Fragebogen " + tempID + ") - " + "bestanden/nicht bestanden";
                    }
                }

                // Debug
                Trace.WriteLine(">>> displayedString = " + displayedString);
                Trace.WriteLine("element = " + element.ToString());
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
                //Trace.WriteLine("WriteCSVFile SUCCESS");
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
                    //Trace.WriteLine("ReadCSVFile SUCCESS");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ReadCSVFile ERROR: " + ex);
            }
        }
    }
}
