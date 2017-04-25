using System.Diagnostics;
using quiz.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using quiz.Viewmodels.Commands;
using System;
using System.Collections.Generic;

namespace quiz.Viewmodels
{
    /// <summary>
    /// Description of QuestionViewModel. Handles the presentation logic.
    /// This class inherits from ObservableObject to enable one and two-way binding between the UI elements and the question model
    /// </summary>
    public class QuestionViewModel : ObservableObject
	{
        // fields hold observable objects of the models and results of user interaction
        // selected Questionaire
        private Questionaire questionaire;
        // question to display
        private Question question;
        // holds the index of the user selected answer
        private int answerSelected;
        // answers to display
        private ObservableCollection<Answer> answers;

        // viewmodel constructor (hook the model up to the viewmodel)
        public QuestionViewModel()
        {
            // TODO: display the dummy
            // TODO: exchange dummies with db created ones
            // create the dummy questionaire
            List<Question> dummyQuestions = new List<Question>();
            // create the dummy questions
            for (int qi = 0; qi < 4; qi++)
            {
                string dummyText = "Wie lautet die Frage Nummer " + qi;
                List<Answer> dummyAnswers = new List<Answer>();
                // create the dummy answers
                for (int ai = 0; ai < 4; ai++)
                {
                    bool correctBool;
                    string textAnswer;
                    if (ai == 0)
                    {
                        textAnswer = "Wie lautet die Frage Nummer " + qi;
                        correctBool = true;
                    }
                    else
                    {
                        textAnswer = "Wer läutet doi Fruge Dummer " + qi;
                        correctBool = false;
                    }
                    dummyAnswers.Add(new Answer(ai, textAnswer, correctBool));
                }
                dummyQuestions.Add(new Question(qi, dummyText,dummyAnswers));
            }
            // create the selected questionnaire model
            Questionaire = new Questionaire(0, dummyQuestions);
            // create the displayed question
            Question = Questionaire.Questions[0];
            // fills the observable collection with Answer objects
            Answers = new ObservableCollection<Answer>();
            for (int i = 0; i < Question.AnswerList.Count; i++)
            {
                Answers.Add(new Answer(i, Question.AnswerList[i].Text, Question.AnswerList[i].CorrectAnswer));
            }
            // Debug
            foreach (Answer answer in Answers)
                Trace.WriteLine("ctor of QuestionViewModel( Question.AnswerList[" + answer.Index + "].Text ): " + answer.Text);
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
        public Questionaire Questionaire
        {
            get { return questionaire; }
            set
            {
                questionaire = value;
                OnPropertyChanged("Questionaire");
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
