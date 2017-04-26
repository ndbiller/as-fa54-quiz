namespace quiz.Models
{
    /// <summary>
    /// Description of Answers.
    /// Answer class for the observable object Answers
    /// </summary>
    public class Answer
    {
        public int Index { get; set; }
        public string Text { get; set; }

        // parametrisierter ctor zum Befüllen aus DB durch ctor Question
        public Answer(int index, string text)
        {
            Index = index;
            Text = text;
        }
    }
}
