using quiz.Viewmodels;
using System.Windows;
using System.Windows.Controls;

namespace quiz
{
	/// <summary>
	/// Interaction logic for StartPage.xaml
	/// </summary>
	public partial class StartPage : Page
	{
        public QuestionViewModel QuestionVM { get; set; }

        //public StartPage()
        //{
        //    QuestionVM = new QuestionViewModel();
        //    InitializeComponent();
        //    this.DataContext = QuestionVM;
        //}
        public StartPage(QuestionViewModel questionVM)
        {
            QuestionVM = questionVM;
            InitializeComponent();
            this.DataContext = QuestionVM;
        }

        private void StartClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new QuestionairePage(QuestionVM));
        }

        private void SettingsClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SettingsPage(QuestionVM));
        }
    }
}