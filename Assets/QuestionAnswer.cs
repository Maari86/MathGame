using System.Collections.Generic;

[System.Serializable]
public class QuestionAnswer
{
    public string Question;
    public List<string> Answers;
    public int CorrectAnswer;

    public QuestionAnswer(string question, List<string> answers, int correctAnswer)
    {
        Question = question;
        Answers = answers;
        CorrectAnswer = correctAnswer;
    }
}

