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
using System.Collections.ObjectModel;

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
        private ObservableCollection<Answer> answers;
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
        public ObservableCollection<Answer> Answers
        {
            get { return answers; }
            set
            {
                answers = value;
                OnPropertyChanged("Answers");
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

        public QuestionViewModel()
        {
            // Instantiate the Question for the view
            Question = new Question();
            // Fill the observable collection with Answer objects
            Answers = new ObservableCollection<Answer>();
            for (int i = 0; i < Question.AnswerList.Count; i++)
            {
                Answers.Add(new Answer() { Index = i, Text = Question.AnswerList[i]});
            }

            // Debug
            foreach(Answer answer in Answers)
                Trace.WriteLine("QuestionViewModel(Answers[" + answer.Index + "]): " + answer.Text);
        }
	}

    // Answer class for the observable object Answers
    public class Answer
    {
        public int Index { get; set; }
        public string Text { get; set; }
    }
}
