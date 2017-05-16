namespace quiz.Models
{
    public class WrongAnswer
    {
        public string Question { get; set; }
        public string SelectedAnswer { get; set; }
        public string RightAnswer { get; set; }

        public WrongAnswer()
        {
            Question = "";
            SelectedAnswer = "";
            RightAnswer = "";
        }

        public WrongAnswer(string question, string selectedAnswer, string rightAnswer)
        {
            Question = question;
            SelectedAnswer = selectedAnswer;
            RightAnswer = rightAnswer;
        }
    }
}
