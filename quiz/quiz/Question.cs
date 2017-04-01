using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace quiz
{
	// This class implements INotifyPropertyChanged
	// to support one-way and two-way bindings
	// (such that the UI element updates when the source
	// has been changed dynamically)
	public class Question : INotifyPropertyChanged
    {
		
		int ID { get; set; }
        string QuestionText { get; set; }
        IList<string> Answers { get; set; }
        int CorrectAnswer { get; set; }
        
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
