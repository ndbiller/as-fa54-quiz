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

        private void BackToMainClicked(object sender, RoutedEventArgs e)
        {
            // TODO: Save Result in History
            NavigationService.Navigate(new StartPage());
        }
    }
}