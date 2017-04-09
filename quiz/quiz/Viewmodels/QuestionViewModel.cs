/*
 * Created by SharpDevelop.
 * User: nd
 * Date: 03/28/2017
 * Time: 21:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using quiz.Models;
using System.Collections.Generic;

namespace quiz.Viewmodels
{
    /// <summary>
    /// Description of QuestionViewModel.
    /// This class inherits from ObservableObject to enable one and two-way binding between the UI elements and the question model
    /// It handles the presentation logic
    /// </summary>
    public class QuestionViewModel : ObservableObject
	{
        private Question question;
        private int id;
		private string questionText;
        private string answer1;
        private string answer2;
        private string answer3;
        private string answer4;
        private List<string> answerList;
        private int correctAnswer;
        private int answerSelected;

        public Question Question
        {
            get { return question; }
            set
            {
                question = value;
                OnPropertyChanged("Question");
            }
        }
        public int AnswerSelected
        {
            get { return answerSelected; }
            set
            {
                answerSelected = value;
                OnPropertyChanged("AnswerSelected");
            }
        }

        // below setter property change events probably not needed, could be turned to properties to shorten the class, needs testing
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
}
        }
        public string QuestionText
        {
			get { return questionText; }
			set
			{
                questionText = value;
				OnPropertyChanged("QuestionText");
			}
		}
        public string Answer1
        {
            get { return answer1; }
            set
            {
                answer1 = value;
                OnPropertyChanged("Answer1");
            }
        }
        public string Answer2
        {
            get { return answer2; }
            set
            {
                answer2 = value;
                OnPropertyChanged("Answer2");
            }
        }
        public string Answer3
        {
            get { return answer3; }
            set
            {
                answer3 = value;
                OnPropertyChanged("Answer3");
            }
        }
        public string Answer4
        {
            get { return answer4; }
            set
            {
                answer4 = value;
                OnPropertyChanged("Answer4");
            }
        }
        public List<string> AnswerList
        {
            get { return answerList; }
            set
            {
                answerList = value;
                OnPropertyChanged("AnswerList");
            }
        }
        public int CorrectAnswer
        {
            get { return correctAnswer; }
            set
            {
                correctAnswer = value;
                OnPropertyChanged("CorrectAnswer");
            }
        }

        public QuestionViewModel()
        {
            // Instantiate the Question for the view
            Question = new Question();

            // Debug
            Trace.WriteLine(Question.QuestionText);
        }
	}
}
