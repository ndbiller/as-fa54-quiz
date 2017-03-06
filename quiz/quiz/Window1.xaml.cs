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

namespace quiz
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 

    public partial class Window1 : Window
    {

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
        public Window1()
        {
            InitializeComponent();
        }
    }
}