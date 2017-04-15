/*
 * Created by SharpDevelop.
 * User: nd
 * Date: 03/28/2017
 * Time: 22:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Media;
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
            // TODO: create the object for the view and set viewmodel object to view datacontext when it gets instantiated in code behind
            // Instantiate the User for the view
            User = new User();
            History = new ObservableCollection<SelectedAnswer>();
            foreach (SelectedAnswer answer in User.AnswerHistory)
            {
                History.Add(answer);
                // Debug
                Trace.WriteLine("MainViewModel: " + answer.ToString());
            }
        }
    }
}
