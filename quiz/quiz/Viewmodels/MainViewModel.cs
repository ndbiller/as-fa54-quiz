using quiz.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace quiz.Viewmodels
{
    /// <summary>
    /// Description of MainViewModel.
    /// Add models to viewmodel for data binding
    /// Adds the User model object to the app for data binding
    /// It handles the presentation logic
    /// </summary>
    public class MainViewModel : ObservableObject
    {
        // holds the displayed user
        public User User { get; set; }
        // the displayed history
        public ObservableCollection<History> History { get; set; }

        public MainViewModel()
		{
            // Instantiate the defaultUser for the view
            User = new User();
            // instantiate the displayed history and load the users answer history into it
            History = new ObservableCollection<History>();
            foreach (History answer in User.UserHistory)
            {
                History.Add(answer);
                // Debug
                Trace.WriteLine("MainViewModel: " + answer.ToString());
            }

            // Debug Load and Save
            // User.WriteCSVFile();
            // Trace.WriteLine("...done WriteCSVFiling.");
            // User.ReadCSVFile();
            // Trace.WriteLine("...done ReadCSVFiling.");

            // Debug
            Trace.WriteLine(">>> loaded user = " + User.Name);
            Trace.WriteLine("history.headers: QuestionaireID,QuestionID,AnswerID");
            foreach (History answer in User.UserHistory)
                //Trace.WriteLine(answer.QuestionaireID + "," + answer.QuestionID + "," + answer.AnswerID);
                Trace.WriteLine("history.ToString(): " + answer.ToString());
            Trace.WriteLine(">>> done creating with params.");
        }
    }
}
