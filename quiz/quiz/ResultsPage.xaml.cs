using quiz.Viewmodels;
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

        //public ResultsPage()
        //{
        //    InitializeComponent();
        //}

        public ResultsPage(QuestionViewModel questionVM)
        {
            // viewmodel with data
            QuestionVM = questionVM;
            // Solve for x
            QuestionVM.Questionaire.Evaluate(QuestionVM.User.PassingPercentage);
            InitializeComponent();
            this.DataContext = QuestionVM;
        }

        private void BackToMainClicked(object sender, RoutedEventArgs e)
        {
            // TODO: Save Result in History
            NavigationService.Navigate(new StartPage(QuestionVM));
        }
    }
}