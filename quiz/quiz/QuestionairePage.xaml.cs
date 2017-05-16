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
            //Trace.WriteLine("QuestionVM.DisplayedQuestionIndex: " + QuestionVM.DisplayedQuestionIndex);

            InitializeComponent();
            // set the views data context to the model object in the viewmodel
            this.DataContext = QuestionVM;

            // Debug
            //Trace.WriteLine("QuestionairePage(QuestionVM.Answers.Count): " + QuestionVM.Answers.Count);
            bool result = QuestionVM.Question.Solve();
            //Trace.WriteLine("result: " + result.ToString());
            //Trace.WriteLine("QuestionVM.Question.PathToImage: " + QuestionVM.Question.PathToImage);
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
            // reset image source
            QuestionVM.PathToImage = QuestionVM.Question.PathToImage;
            InitializeComponent();
            // set the views data context to the model object in the viewmodel
            this.DataContext = QuestionVM;
            //Trace.WriteLine("QuestionVM.Question.PathToImage: " + QuestionVM.Question.PathToImage);
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
            //Trace.WriteLine("click! sender as RadioButton = test.Tag: "+ i +" ... " + test.Tag.GetType());
            QuestionVM.AnswerClicked(i);
        }

        private void ForwardClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            // zähle beantwortete fragen
            QuestionVM.CompletedQuestions = CompletedQuestionsCount(QuestionVM);
            // Debug
            //Trace.WriteLine("click! FOWARD: QuestionVM.CompletedQuestions = " + QuestionVM.CompletedQuestions);
            //Trace.WriteLine("click! FOWARD: QuestionVM.Questionaire.Questions.Count = " + QuestionVM.Questionaire.Questions.Count);
            //Trace.WriteLine("click! FOWARD: QuestionVM.DisplayedQuestionIndex = " + QuestionVM.DisplayedQuestionIndex);
            // wenn alle fragen beantwortet sind
            if (QuestionVM.CompletedQuestions == QuestionVM.Questionaire.Questions.Count)
            {
                // get selected and correct answer ids
                int selectedAnswerID = -1;
                int correctAnswerID = -1;
                foreach (Answer answer in QuestionVM.Answers)
                {
                    if (answer.SelectedAnswer)
                        selectedAnswerID = answer.Index;
                    if (answer.CorrectAnswer)
                        correctAnswerID = answer.Index;
                }
                // save AppTitle,DBID,QuestionaireID,QuestionaireLength,QuestionairePercentage,QuestionID,AnswerID,CorrectAnswer to history
                QuestionVM.User.UserHistory.Add(new History(QuestionVM.User.Title, QuestionVM.User.SelectedDB, QuestionVM.QuestionaireID, QuestionVM.User.QuestionLimit, QuestionVM.User.PassingPercentage, QuestionVM.Question.ID, selectedAnswerID, correctAnswerID));
                // gehe zur lösung
                NavigationService.Navigate(new ResultsPage(QuestionVM));
            }
            else // wenn nicht alle fragen beantwortet sind
            {
                // wenn es nicht die letzte frage ist
                if (QuestionVM.DisplayedQuestionIndex + 1 < QuestionVM.Questionaire.Questions.Count)
                {
                    //Trace.WriteLine("click! FOWARD nicht die letzte frage: QuestionVM.Questionaire.Questions.Count = " + QuestionVM.Questionaire.Questions.Count);
                    //Trace.WriteLine("click! FOWARD nicht die letzte frage: QuestionVM.DisplayedQuestionIndex + 1 = " + QuestionVM.DisplayedQuestionIndex + 1);
                    // get selected and correct answer ids
                    int selectedAnswerID = -1;
                    int correctAnswerID = -1;
                    foreach (Answer answer in QuestionVM.Answers)
                    {
                        if (answer.SelectedAnswer)
                            selectedAnswerID = answer.Index;
                        if (answer.CorrectAnswer)
                            correctAnswerID = answer.Index;
                    }
                    // save AppTitle,DBID,QuestionaireID,QuestionaireLength,QuestionairePercentage,QuestionID,AnswerID,CorrectAnswer to history
                    QuestionVM.User.UserHistory.Add(new History(QuestionVM.User.Title, QuestionVM.User.SelectedDB, QuestionVM.QuestionaireID, QuestionVM.User.QuestionLimit, QuestionVM.User.PassingPercentage, QuestionVM.Question.ID, selectedAnswerID, correctAnswerID));
                    // gehe zur nächsten frage
                    NavigationService.Navigate(new QuestionairePage(QuestionVM, QuestionVM.DisplayedQuestionIndex + 1));
                }
                else // wenn es die letzte frage ist
                {
                    //Trace.WriteLine("click! FOWARD letzte frage: QuestionVM.Questionaire.Questions.Count = " + QuestionVM.Questionaire.Questions.Count);
                    //Trace.WriteLine("click! FOWARD letzte frage: QuestionVM.DisplayedQuestionIndex = " + QuestionVM.DisplayedQuestionIndex);
                    // finde die position der ersten unbeantworteten frage
                    int positionUnansweredQuestion = 0;
                    foreach (Question question in QuestionVM.Questionaire.Questions) // gehe durch alle fragen des questionairs
                    {
                        bool selectedFound = false;
                        foreach (Answer answer in question.AnswerList) // gehe durch alle antworten der frage
                        {
                            // wenn bereits eine antwort ausgewählt ist
                            if (answer.SelectedAnswer)
                            {
                                // position hochzählen und abbruchbedingung deaktivieren
                                positionUnansweredQuestion += 1;
                                selectedFound = true;
                            }
                        }
                        // wenn eine Frage mit nicht gewählter antwort gefunden wurde
                        if (!selectedFound)
                            NavigationService.Navigate(new QuestionairePage(QuestionVM, positionUnansweredQuestion)); // gehe zur position der unbeantworteten frage
                    }
                }
            }
        }

        private void BackClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            QuestionVM.CompletedQuestions = CompletedQuestionsCount(QuestionVM);
            // Debug
            //Trace.WriteLine("click! BACK: QuestionVM.CompletedQuestions = " + QuestionVM.CompletedQuestions);
            //Trace.WriteLine("click! BACK: QuestionVM.Questionaire.Questions.Count = " + QuestionVM.Questionaire.Questions.Count);
            //Trace.WriteLine("click! BACK: QuestionVM.DisplayedQuestionIndex = " + QuestionVM.DisplayedQuestionIndex);
            // wenn es nicht die erste frage ist
            if (QuestionVM.DisplayedQuestionIndex > 0)
            {
                // wenn alle fragen beantwortet sind
                if (QuestionVM.CompletedQuestions == QuestionVM.Questionaire.Questions.Count)
                {
                    // gehe evtl. zur lösung
                    // NavigationService.Navigate(new ResultsPage(QuestionVM));
                    NavigationService.Navigate(new QuestionairePage(QuestionVM, QuestionVM.DisplayedQuestionIndex - 1));
                }
                else // gehe zur vorherigen (oder letzten unbeantworteten) Frage
                    NavigationService.Navigate(new QuestionairePage(QuestionVM, QuestionVM.DisplayedQuestionIndex - 1));
            }
            else // wenn es die erste frage ist
            {
                // do nothing
                //Trace.WriteLine("click! BACK impossible: QuestionVM.DisplayedQuestionIndex = " + QuestionVM.DisplayedQuestionIndex);
            }
        }
    }
}