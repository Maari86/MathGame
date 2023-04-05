using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public List<QuestionAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;

    private void Start()
    {
        generateQuestion();
    }

    public void Correct()
    {
        if (QnA.Count > 0 && currentQuestion < QnA.Count)
        {
            QnA.RemoveAt(currentQuestion);
        }
        generateQuestion();
    }

    void SetAnswers()
    {
        List<string> answerOptions = new List<string>(QnA[currentQuestion].Answers);

        // Generate random numbers for the answer options
        List<int> usedNumbers = new List<int>(); // Keep track of used numbers
        for (int i = 0; i < answerOptions.Count; i++)
        {
            if (i != QnA[currentQuestion].CorrectAnswer - 1) // Skip the correct answer option
            {
                int randomNum = 0;
                do
                {
                    randomNum = Random.Range(-5, 6); // Generate a random number between -5 and 5
                } while (usedNumbers.Contains(randomNum)); // Generate a new number if it has already been used
                usedNumbers.Add(randomNum); // Add the new number to the used numbers list
                answerOptions[i] = (int.Parse(answerOptions[i]) + randomNum).ToString(); // Add the random number to the answer option
            }
        }

        // Check if any of the answer options are the same, and generate new options if necessary
        for (int i = 0; i < answerOptions.Count - 1; i++)
        {
            for (int j = i + 1; j < answerOptions.Count; j++)
            {
                if (answerOptions[i] == answerOptions[j])
                {
                    int randomNum = 0;
                    do
                    {
                        randomNum = Random.Range(-5, 6); // Generate a new random number
                    } while (usedNumbers.Contains(randomNum)); // Generate a new number if it has already been used
                    usedNumbers.Add(randomNum); // Add the new number to the used numbers list
                    answerOptions[j] = (int.Parse(answerOptions[j]) + randomNum).ToString(); // Add the random number to the answer option
                }
            }
        }

        // Shuffle the answer options
        for (int i = 0; i < answerOptions.Count; i++)
        {
            string temp = answerOptions[i];
            int randomIndex = Random.Range(i, answerOptions.Count);
            answerOptions[i] = answerOptions[randomIndex];
            answerOptions[randomIndex] = temp;
        }

        // Set the text and correctness of the answer options
        for (int i = 0; i < options.Length; i++)
        {
            options[i].transform.GetChild(0).GetComponent<Text>().text = answerOptions[i];
            options[i].GetComponent<Answer>().isCorrect = (answerOptions[i] == QnA[currentQuestion].Answers[QnA[currentQuestion].CorrectAnswer - 1]);
        }
    }




    void GenerateAddQuestion()
    {
        int a = Random.Range(0, 11);
        int b = Random.Range(0, 11);
        int answer = a + b;
        QnA.Add(new QuestionAnswer("What is " + a + " + " + b + "?", new List<string> { (answer - 1).ToString(), answer.ToString(), (answer + 1).ToString(), (answer + 2).ToString() }, 2));
    }

    void GenerateSubQuestion()
    {
        int a = Random.Range(0, 11);
        int b = Random.Range(0, a + 1);
        int answer = a - b;
        QnA.Add(new QuestionAnswer("What is " + a + " - " + b + "?", new List<string> { (answer - 1).ToString(), answer.ToString(), (answer + 1).ToString(), (answer + 2).ToString() }, 2));
    }

    void GenerateMultQuestion()
    {
        int a = Random.Range(0, 11);
        int b = Random.Range(0, 11);
        int answer = a * b;
        QnA.Add(new QuestionAnswer("What is " + a + " x " + b + "?", new List<string> { (answer - 1).ToString(), answer.ToString(), (answer + 1).ToString(), (answer + 2).ToString() }, 2));
    }

    void GenerateDivQuestion()
    {
        int b = Random.Range(1, 11);
        int answer = Random.Range(1, 11);
        int a = answer * b;
        QnA.Add(new QuestionAnswer("What is " + a + " ÷ " + b + "?", new List<string> { (answer - 1).ToString(), answer.ToString(), (answer + 1).ToString(), (answer + 2).ToString() }, 2));
    }

    void ResetOptionColors()
    {
        foreach (GameObject option in options)
        {
            option.GetComponent<Image>().color = Color.white; // Reset color to white
        }
    }
    void generateQuestion()
    {
        ResetOptionColors(); // Reset option colors

        int operation = Random.Range(1, 5);
        switch (operation)
        {
            case 1:
                GenerateAddQuestion();
                break;
            case 2:
                GenerateSubQuestion();
                break;
            case 3:
                GenerateMultQuestion();
                break;
            case 4:
                GenerateDivQuestion();
                break;
        }

        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
        }
    }
}
