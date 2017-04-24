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
        // TODO: add fields and/or properties
        public User User { get; set; }
        public ObservableCollection<SelectedAnswer> History { get; set; }

        public MainViewModel()
		{
            // Instantiate the defaultUser for the view
            // User = new User();
            User = new User();
            History = new ObservableCollection<SelectedAnswer>();
            foreach (SelectedAnswer answer in User.AnswerHistory)
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
            Trace.WriteLine("loaded user:");
            Trace.WriteLine("QuestionID;AnswerID");
            foreach (SelectedAnswer answer in User.AnswerHistory)
                Trace.WriteLine(answer.QuestionID + ";" + answer.AnswerID);
            Trace.WriteLine("done creating with params.");
        }
    }
}
