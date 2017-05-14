using System.Diagnostics;
using quiz.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using quiz.Viewmodels.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
        //// holds the index of the user selected answer
        //private int answerSelected;
        // answers to display
        private ObservableCollection<Answer> answers;
        // number of questions with selected answers
        private int completedQuestions;
        // index of displayed question
        private int displayedQuestionIndex;
        // the User History, Settings, etc.
        private User user;
        // the wrong questions for results page
        private ObservableCollection<WrongAnswer> wrongAnswers;
        // image path and source (convert one to the other)
        private string pathToImage;
        private ImageSource imageSource;
        // the selected/displayed questionaire id and the list for selection (from class user, TODO: get from db there)
        private int questionaireID;
        private ObservableCollection<int> questionaireIDList;
        // Debug-Properties
        private int questionLimit;

        // viewmodel constructor (hook the model up to the viewmodel)
        public QuestionViewModel()
        {
            // create the questionnaire id, add to list
            QuestionaireIDList = new ObservableCollection<int>();
            QuestionaireID = 1;
            QuestionaireIDList.Add(QuestionaireID);
            //db sollte vom user ausgewählt werden
            //dbID 0 = binnen
            //dbID 1 = ubi
            // create the model
            Questionaire = new Questionaire(0, questionaireID);
            // create the displayed question
            Question = Questionaire.Questions[0];
            // fills the observable collection with Answer objects
            Answers = new ObservableCollection<Answer>();
            for (int i = 0; i < Question.AnswerList.Count; i++)
            {
                Answers.Add(new Answer(i, Question.AnswerList[i].Text, Question.AnswerList[i].CorrectAnswer, Question.AnswerList[i].SelectedAnswer));
            }
            // set these counters for logic and display
            CompletedQuestions = 0; // answers selected by user, wrapping
            DisplayedQuestionIndex = 0; // base 0 for navigation, wrapping
            // image string path
            PathToImage = Question.PathToImage;
            // image source from string
            ImageSource = new BitmapImage(new Uri(@"" + Question.PathToImage, UriKind.Relative));
            // for results page
            WrongAnswers = new ObservableCollection<WrongAnswer>();
        }
        // ctor for new userselected questionaires
        public QuestionViewModel(QuestionViewModel oldQuestionViewModel)
        {
            User = oldQuestionViewModel.User;

            // create the questionnaire id, add to list
            QuestionaireIDList = new ObservableCollection<int>();
            foreach (int id in oldQuestionViewModel.User.QuestionaireIDs)
                Trace.WriteLine("userselected >>> (single id values) >>> oldQuestionViewModel.User.QuestionaireIDs = " + oldQuestionViewModel.User.QuestionaireIDs.ToString());
            foreach (int id in oldQuestionViewModel.User.QuestionaireIDs)
                questionaireIDList.Add(id);

            Trace.WriteLine("userselected >>> oldQuestionViewModel.User.SelectedQuestionaire = " + oldQuestionViewModel.User.SelectedQuestionaire);
            QuestionaireID = oldQuestionViewModel.User.SelectedQuestionaire;
            //db sollte vom user ausgewählt werden
            //dbID 0 = binnen
            //dbID 1 = ubi
            // create the model
            int selectedID = oldQuestionViewModel.User.SelectedQuestionaire;
            int selectedDB = oldQuestionViewModel.User.SelectedDB;
            QuestionLimit = oldQuestionViewModel.User.QuestionLimit;
            Questionaire = new Questionaire(selectedDB, selectedID, questionLimit);
            // create the displayed question
            Question = Questionaire.Questions[0];
            // fills the observable collection with Answer objects
            Answers = new ObservableCollection<Answer>();
            for (int i = 0; i < Question.AnswerList.Count; i++)
            {
                Answers.Add(new Answer(i, Question.AnswerList[i].Text, Question.AnswerList[i].CorrectAnswer, Question.AnswerList[i].SelectedAnswer));
            }
            // set these counters for logic and display
            CompletedQuestions = 0; // base 0, questions with answers selected by user, for wrapping
            DisplayedQuestionIndex = 0; // base 0, for navigation, for wrapping
            // image string path
            PathToImage = Question.PathToImage;
            // image source from string
            ImageSource = new BitmapImage(new Uri(@"" + Question.PathToImage, UriKind.Relative));
            // for results page
            WrongAnswers = new ObservableCollection<WrongAnswer>();
        }

        // properties to display changes in the view
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }
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
        public int QuestionaireID
        {
            get { return questionaireID; }
            set
            {
                questionaireID = value;
                OnPropertyChanged("QuestionaireID");
            }
        }
        public ObservableCollection<int> QuestionaireIDList
        {
            get { return questionaireIDList; }
            set
            {
                questionaireIDList = value;
                OnPropertyChanged("QuestionaireIDList");
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
        public ObservableCollection<WrongAnswer> WrongAnswers
        {
            get { return wrongAnswers; }
            set
            {
                wrongAnswers = value;
                OnPropertyChanged("WrongAnswers");
            }
        }
        public int CompletedQuestions
        {
            get { return completedQuestions; }
            set
            {
                completedQuestions = value;
                // Debug
                // Trace.WriteLine("after click! FOWARD: CompletedQuestions = " + value);
                OnPropertyChanged("CompletedQuestions");
            }
        }
        public int DisplayedQuestionIndex
        {
            get { return displayedQuestionIndex; }
            set
            {
                displayedQuestionIndex = value;
                OnPropertyChanged("DisplayedQuestionIndex");
            }
        }
        public string PathToImage
        {
            get { return pathToImage; }
            set
            {
                ImageSource = new BitmapImage(new Uri(@"" + value, UriKind.Relative));
                pathToImage = value;
                OnPropertyChanged("PathToImage");
            }
        }
        public ImageSource ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }
        public int QuestionLimit
        {
            get { return questionLimit; }
            set
            {
                questionLimit = value;
                OnPropertyChanged("QuestionLimit");
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
