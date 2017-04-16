using System.Diagnostics;
using quiz.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using quiz.Viewmodels.Commands;
using System;

namespace quiz.Viewmodels
{
    /// <summary>
    /// Description of QuestionViewModel. Handles the presentation logic.
    /// This class inherits from ObservableObject to enable one and two-way binding between the UI elements and the question model
    /// </summary>
    public class QuestionViewModel : ObservableObject
	{
        // field holds the model
        private Question question;
        private int answerSelected;
        // TODO: remove once all functionality is on question model answer list
        private ObservableCollection<Answer> answers;

        // viewmodel constructor (hook the model up to the viewmodel)
        public QuestionViewModel()
        {
            // create a new question model
            Question = new Question();

            // TODO: remove later, fills the observable collection with Answer objects
            Answers = new ObservableCollection<Answer>();
            for (int i = 0; i < Question.AnswerList.Count; i++)
            {
                Answers.Add(new Answer() { Index = i, Text = Question.AnswerList[i] });
            }
            // Debug
            foreach (Answer answer in Answers)
                Trace.WriteLine("QuestionViewModel(Answers[" + answer.Index + "]): " + answer.Text);
        }

        // properties to display changes in the view
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

        // ICommand property provides specific implementation for each action.
        // the delegate will forward to methods defined here in the viewmodel.
        public ICommand AnswerClickedCommand
        {
            get
            {
                return new DelegatingCommand(o => AnswerClicked((int)o));
            }
        }
        // links to AnswerClicked method in Question model 
        public void AnswerClicked(int o)
        {
            Question.AnswerClicked(o);
            OnPropertyChanged("AnswerSelected");
        }
    }
}
