using quiz.Viewmodels;
using System.Windows;
using System.Windows.Controls;

namespace quiz
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
	{
        public QuestionViewModel QuestionVM { get; set; }

        public SettingsPage(QuestionViewModel questionVM)
        {
            QuestionVM = questionVM;
            InitializeComponent();
            this.DataContext = QuestionVM;
        }

        private void SaveClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage(QuestionVM));
        }
    }
}