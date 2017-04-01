using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace quiz.Models
{
	// This class implements INotifyPropertyChanged
	// to support one-way and two-way bindings
	// (such that the UI element updates when the source
	// has been changed dynamically)
	public class Question : INotifyPropertyChanged
    {
		
		public int ID { get; set; }
        public string QuestionText { get; set; }
        public IList<string> Answers { get; set; }
        public int CorrectAnswer { get; set; }
        // temporary, for the dummy question
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }


        private int selected;
        // Declare the event
      	public event PropertyChangedEventHandler PropertyChanged;
        public int AnswerSelected
		{ 
			get { return selected; }
			set 
			{
				selected = value;
				// Call OnPropertyChanged whenever the property is updated
              	OnPropertyChanged(1);
			}
		}
        // Create the OnPropertyChanged method to raise the event
		protected void OnPropertyChanged(int id)
		{
		  PropertyChangedEventHandler handler = PropertyChanged;
		  if (handler != null)
		  {
		      handler(this, new PropertyChangedEventArgs("id"));
		  }
		}


        public Question()
        {
            QuestionText = "Is this working?";
            Answer1 = "Yes.";
            Answer2 = "No.";
            Answer3 = "Maybe.";
        }

        public Question(int id, string questionText, IList<string> answers, int correctAnswer)
        {
            ID = id;
            QuestionText = questionText;
            Answers = answers;
            CorrectAnswer = correctAnswer;
            AnswerSelected = 999;
        }

        public bool Solve()
        {
            Console.WriteLine("trying to solve..");
            if (AnswerSelected == CorrectAnswer)
            {
                Console.WriteLine("Answer Correct");
                return true;
            }
            else
            {
                Console.WriteLine("Answer Inorrect");
                return false;
            }
        }

    }
}
