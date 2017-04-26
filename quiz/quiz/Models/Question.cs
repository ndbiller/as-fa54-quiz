using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace quiz.Models
{
	public class Question
    {
        // Properties
        public int ID { get; set; }
        public int DBID { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> AnswerList { get; set; }

        public Question(int id, string questionText, List<Answer> answers)
        {
            ID = id;
            QuestionText = questionText;
            AnswerList = answers;
        }

        public void AnswerClicked(int index)
        {
            foreach (Answer answer in AnswerList)
                if (answer.Index != index)
                    answer.SelectedAnswer = false;
            AnswerList.ElementAt<Answer>(index).SelectedAnswer = true;

            // Debug
            foreach (Answer answer in AnswerList)
                Trace.WriteLine("New Answer " + index + " selected! Value of Answer.SelectedAnswer at " + answer.Index + " is now " + answer.SelectedAnswer);
        }
        public void ForwardClicked(int nextQuestionID)
        {
            // Debug
            Trace.WriteLine("nextQuestionID is " + nextQuestionID + "! ID is now " + ID);
        }

        public bool Solve()
        {
            bool correct = false;
            foreach (Answer answer in AnswerList)
                if (answer.CorrectAnswer && answer.SelectedAnswer)
                    correct = true;
            return correct;
        }
    }
}
