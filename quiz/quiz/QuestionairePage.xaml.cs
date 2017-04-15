using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Data;
using System.Xml;
using System.Configuration;
using System.ComponentModel;
using quiz.Models;
using quiz.Viewmodels;

namespace quiz
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class QuestionairePage : Page
	{
        // Property for the Viewmodel
        public QuestionViewModel QuestionVM { get; set; }

        public QuestionairePage()
        {
            // Instantiate the Viewmodel (and thus the Model)
            QuestionVM = new QuestionViewModel();
            InitializeComponent();
            // set the views data context to the model object in the viewmodel
            this.DataContext = QuestionVM;

            // Debug
            Trace.WriteLine("QuestionairePage(QuestionVM.Answers.Count): " + QuestionVM.Answers.Count);
            bool result = QuestionVM.Question.Solve();
            Trace.WriteLine("result: " + result.ToString());
        }
    }
}