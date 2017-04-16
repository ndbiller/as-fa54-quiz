using System.Windows;
using System.Windows.Controls;

namespace quiz
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
	{
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void SaveClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());
        }
    }
}