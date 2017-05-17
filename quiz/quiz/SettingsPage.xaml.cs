using quiz.Models;
using quiz.Viewmodels;
using System.Collections.Generic;
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
            QuestionVM.User.WriteCSVFile();
            NavigationService.Navigate(new StartPage(QuestionVM));
        }

        private void DeleteClicked(object sender, RoutedEventArgs e)
        {
            // Delete History and History File
            QuestionViewModel currentVM = QuestionVM;
            currentVM.User.UserHistory = new List<History>();
            currentVM.QuestionaireHistory.Clear();
            currentVM.User.DeleteCSVFile();
            // Set default Values for user
            currentVM.User.LoadSettings();
            // go to start page
            NavigationService.Navigate(new StartPage(currentVM));
        }
    }
}