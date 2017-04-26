using System.Diagnostics;
using System.Windows.Controls;
using quiz.Viewmodels;
using System;
using quiz.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace quiz
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class QuestionairePage : Page
	{
        // Property for the Viewmodel
        public QuestionViewModel QuestionVM { get; set; }

        // ctor for first question of a questionaire
        // TODO: questionaire selection
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
        // ctor for forward and back navigation
        public QuestionairePage(QuestionViewModel questionVM, int questionIndex)
        {
            // Instantiate the Viewmodel (and thus the old Model)
            QuestionVM = questionVM;
            if (questionIndex >= 0 && questionIndex < QuestionVM.Questionaire.Questions.Count)
            {
                QuestionVM.Question = QuestionVM.Questionaire.Questions[questionIndex];
                //QuestionVM.AnswerSelected = -1;  // Do this only forward
                ObservableCollection<Answer> answersVM = new ObservableCollection<Answer>();
                for (int i = 0; i < QuestionVM.Questionaire.Questions[questionIndex].AnswerList.Count; i++)
                {
                    answersVM.Add(QuestionVM.Questionaire.Questions[questionIndex].AnswerList[i]);
                }
                QuestionVM.Answers = answersVM;
                QuestionVM.DisplayedQuestionIndex = questionIndex;
            }
            InitializeComponent();
            // set the views data context to the model object in the viewmodel
            this.DataContext = QuestionVM;
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
        private void ForwardClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new QuestionairePage(QuestionVM, QuestionVM.DisplayedQuestionIndex + 1));
            // Debug
            Trace.WriteLine("click! FOWARD");
        }
        private void BackClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new QuestionairePage(QuestionVM, QuestionVM.DisplayedQuestionIndex - 1));
            // Debug
            Trace.WriteLine("click! BACK");
        }
    }
}