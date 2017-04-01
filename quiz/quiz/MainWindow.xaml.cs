/*
 * Created by SharpDevelop.
 * User: nd
 * Date: 15/02/2017
 * Time: 00:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;
using System.ComponentModel;
using quiz.Models;

namespace quiz
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        //        private BinnenschifffahrtEntities binnenschifffahrt = new BinnenschifffahrtEntities();
        //IQueryable<int> fragenQuery = binnenschifffahrt.T_SBF_Binnen.Select(d => d.P_Id);
        //comboBox1.DataSource= fragenQuery.ToList();

        //habe den projekt ausgabetyp erstmal auf konsole geändert, um debugging zu erleichtern
        //DUMMY QUESTIONS
        static List<string> answers = new List<string>()
        {
            "oOoOoOoo",
            "aAaAaAaAaaa",
            "uUuUuUuUuUuu",
            "kukukukukuu"
        };
        static Question testQuestion1 = new Question(1, "What does the fox say?", answers, 2);
        static Question testQuestion2 = new Question(1, "What does the other fox say?", answers, 3);
        static List<Question> myQuestions = new List<Question>()
        {
            testQuestion1,
            testQuestion2
        };
        Questionaire myQuestionaire = new Questionaire(myQuestions);

        public MainWindow()
        {
            InitializeComponent();

            //example answers
            //myQuestionaire.Questions[0].AnswerSelected = 1;
            //myQuestionaire.Questions[1].AnswerSelected = 3;
            //myQuestionaire.Evaluate(50);
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new StartPage();
        }

        private void MinimizeClicked(object sender, RoutedEventArgs e)
        {
            // TODO: minimize window
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