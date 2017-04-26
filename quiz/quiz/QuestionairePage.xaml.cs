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
        public QuestionairePage(QuestionViewModel questionVM)
        {
            // the Viewmodel (and thus the Model)
            QuestionVM = questionVM;
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

        public int CompletedQuestionsCount(QuestionViewModel questionVM)
        {
            int questionsCompleted = 0;
            foreach (Question question in questionVM.Questionaire.Questions)
                foreach (Answer answer in question.AnswerList)
                    if (answer.SelectedAnswer)
                        questionsCompleted += 1;
            return questionsCompleted;
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
            // zähle beantwortete fragen
            QuestionVM.CompletedQuestions = CompletedQuestionsCount(QuestionVM);
            // Debug
            Trace.WriteLine("click! FOWARD: QuestionVM.CompletedQuestions = " + QuestionVM.CompletedQuestions);
            Trace.WriteLine("click! FOWARD: QuestionVM.Questionaire.Questions.Count = " + QuestionVM.Questionaire.Questions.Count);
            // wenn alle fragen beantwortet sind
            if (QuestionVM.CompletedQuestions == QuestionVM.Questionaire.Questions.Count)
                NavigationService.Navigate(new ResultsPage(QuestionVM));
            else // gehe zur nächsten (unbeantworteten) Frage
                NavigationService.Navigate(new QuestionairePage(QuestionVM, QuestionVM.DisplayedQuestionIndex + 1));
        }
        private void BackClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            QuestionVM.CompletedQuestions = CompletedQuestionsCount(QuestionVM);
            // Debug
            Trace.WriteLine("click! BACK: QuestionVM.CompletedQuestions = " + QuestionVM.CompletedQuestions);
            Trace.WriteLine("click! BACK: QuestionVM.Questionaire.Questions.Count = " + QuestionVM.Questionaire.Questions.Count);
            // wenn alle fragen beantwortet sind
            if (QuestionVM.CompletedQuestions == QuestionVM.Questionaire.Questions.Count)
                NavigationService.Navigate(new ResultsPage(QuestionVM));
            else // gehe zur vorherigen (oder letzten unbeantworteten) Frage
                NavigationService.Navigate(new QuestionairePage(QuestionVM, QuestionVM.DisplayedQuestionIndex - 1));
        }
    }
}