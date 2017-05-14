using quiz.Models;
using quiz.Viewmodels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace quiz
{
    /// <summary>
    /// Interaction logic for ResultsPage.xaml
    /// </summary>
    public partial class ResultsPage : Page
	{
        // Property for the Viewmodel
        public QuestionViewModel QuestionVM { get; set; }

        public ResultsPage(QuestionViewModel questionVM)
        {
            // get the viewmodel with data
            QuestionVM = questionVM;
            // fragebogen auswerten
            QuestionVM.Questionaire.Evaluate(QuestionVM.User.PassingPercentage);
            // falsche fragen für page in viewmodel erstellen
            foreach (Question question in QuestionVM.Questionaire.Questions)
                if (!question.Solve())
                {
                    List<string> wrong = new List<string>();
                    WrongAnswer wrongAnswer = new WrongAnswer();
                    wrongAnswer.Question = "Frage " + question.ID + ": " + question.QuestionText; // get wrongly answered question
                    foreach (Answer answer in question.AnswerList)
                    {
                        //Trace.WriteLine("answer.SelectedAnswer: " + answer.SelectedAnswer);
                        //Trace.WriteLine("answer.CorrectAnswer: " + answer.CorrectAnswer);
                        //Trace.WriteLine("!answer.CorrectAnswer: " + !answer.CorrectAnswer);
                        //Trace.WriteLine("answer.Text: " + answer.Text);
                        if (answer.SelectedAnswer && !answer.CorrectAnswer)
                            wrongAnswer.SelectedAnswer = "FALSCH: " + answer.Text; // get wrong answer
                    }
                    foreach (Answer answer in question.AnswerList)
                    {
                        //Trace.WriteLine("answer.SelectedAnswer: " + answer.SelectedAnswer);
                        //Trace.WriteLine("answer.CorrectAnswer: " + answer.CorrectAnswer);
                        //Trace.WriteLine("answer.Text: " + answer.Text);
                        if (answer.CorrectAnswer)
                            wrongAnswer.RightAnswer = "RICHTIG: " + answer.Text; // get right answer
                    }
                    QuestionVM.WrongAnswers.Add(wrongAnswer);
                    //Trace.WriteLine("QuestionVM.WrongQuestions[0].ToString(): " + QuestionVM.WrongQuestions[0].ToString());
                }
            //foreach (string s in QuestionVM.WrongQuestions)
            //        Trace.WriteLine("s: " + s);

            InitializeComponent();
            this.DataContext = QuestionVM;
        }

        private void BackToMainClicked(object sender, RoutedEventArgs e)
        {
            User currentUser =  QuestionVM.User;
            // TODO: Save Result in History
            // change back to QuestionVM
            NavigationService.Navigate(new StartPage(new QuestionViewModel() { User = currentUser }));
        }
    }

    public class WrongAnswer
    {
        public string Question { get; set; }
        public string SelectedAnswer { get; set; }
        public string RightAnswer { get; set; }

        public WrongAnswer()
        {
            Question = "";
            SelectedAnswer = "";
            RightAnswer = "";
        }

        public WrongAnswer(string question, string selectedAnswer, string rightAnswer)
        {
            Question = question;
            SelectedAnswer = selectedAnswer;
            RightAnswer = rightAnswer;
        }
    }
}