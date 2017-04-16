using System.Windows;
using System.ComponentModel;
using quiz.Models;
using quiz.Viewmodels;
using System.Diagnostics;

namespace quiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Basicaly the entrypoint for our app (after App.xaml)
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        // private BinnenschifffahrtEntities binnenschifffahrt = new BinnenschifffahrtEntities();
        // IQueryable<int> fragenQuery = binnenschifffahrt.T_SBF_Binnen.Select(d => d.P_Id);
        // comboBox1.DataSource= fragenQuery.ToList();

        // create the main viewmodel and set it as data context for the views in constructor
        public MainViewModel MainVM { get; set; }

        public MainWindow()
        {
            MainVM = new MainViewModel();
            InitializeComponent();
            DataContext = MainVM;

            // Debug
            foreach (SelectedAnswer answer in MainVM.History)
                Trace.WriteLine("MainWindow(MainVM.History): " + answer.ToString());
            foreach (SelectedAnswer answer in MainVM.User.AnswerHistory)
                Trace.WriteLine("MainWindow(MainVM.User.AnswerHistory): " + answer.ToString());
            MainVM.User.ToCSV();
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new StartPage();
        }

        // TODO: maximize button and method, views should behave correctly no matter the screensize (windowed or fullscreen or other resolutions / resized ) used 

        private void MinimizeClicked(object sender, RoutedEventArgs e)
        {
            // TODO: minimize window here

            // TODO: remove temporary function to go to Results Page once questions from db are loaded and answers get validated correctly
            MainFrame.Content = new ResultsPage();
        }

        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            // close the app window to call the window closing event
            this.Close();

            // TODO: save user progress
        }

        // Method to handle the Window.Closing event.
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            var response = MessageBox.Show("Do you really want to exit?", "Exiting...",
                                           MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (response == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                // stop all running programm processes
                Application.Current.Shutdown();
            }
        }
    }
}