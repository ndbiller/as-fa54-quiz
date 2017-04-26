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
        public ResultsPage()
        {
            InitializeComponent();
        }

        public ResultsPage(QuestionViewModel questionVM)
        {
            QuestionViewModel QuestionVM = questionVM;
            InitializeComponent();
            this.DataContext = QuestionVM;
        }

        private void BackToMainClicked(object sender, RoutedEventArgs e)
        {
            // TODO: Save Result in History
            NavigationService.Navigate(new StartPage());
        }
    }
}