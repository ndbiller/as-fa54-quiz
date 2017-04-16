using System.Windows;
using System.Windows.Controls;

namespace quiz
{
	/// <summary>
	/// Interaction logic for StartPage.xaml
	/// </summary>
	public partial class StartPage : Page
	{
        public StartPage()
        {
            InitializeComponent();
        }

        private void StartClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new QuestionairePage());
        }

        private void SettingsClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SettingsPage());
        }
    }
}