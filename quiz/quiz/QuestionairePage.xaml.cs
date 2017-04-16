using System.Diagnostics;
using System.Windows.Controls;
using quiz.Viewmodels;
using System;

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

        private void AnswerClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var test = sender as RadioButton;
            string str = test.Tag.ToString();
            int i = Int32.Parse(str);
            // Debug
            Trace.WriteLine("click! sender as RadioButton = test.Tag: "+ i +" ... " + test.Tag.GetType());
            QuestionVM.AnswerClicked(i);
        }
    }
}