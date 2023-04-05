using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public bool isCorrect = false;
    public Quiz quizManager;
    public Image image;

    public void Ans()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.Correct();
            image.color = Color.green;
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.Correct();
            image.color = Color.red;
        }

        StartCoroutine(ResetColor());
    }

    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.2f);
        image.color = Color.white;
    }
}
