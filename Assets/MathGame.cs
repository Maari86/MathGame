using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathGame : MonoBehaviour
{
    int primaryNumber, secondryNumber, numberTemporary, finalAnswer;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) // To Add
        {
            Calculator("Add");
        }


        if (Input.GetKeyDown(KeyCode.R)) // To sub
        {
            Calculator("Subtract");
        }

        if (Input.GetKeyDown(KeyCode.M)) // To Multi
        {
            Calculator("Multiple");
        }
        if (Input.GetKeyDown(KeyCode.D)) // To divide
        {
            Calculator("Divide");
        }
    }
    public void Calculator(string operation)
    {
        primaryNumber = Random.Range(1, 10);
        secondryNumber = Random.Range(1, 10);

        if (primaryNumber-secondryNumber < 0)
        {
            numberTemporary = secondryNumber;
            secondryNumber = primaryNumber;
            primaryNumber = numberTemporary;
        }

        if (operation == "Add")
        {
            finalAnswer = primaryNumber + secondryNumber;
        }
        if (operation == "Subtract")
        {
            finalAnswer = primaryNumber - secondryNumber;
        }
        if (operation == "Multiple")
        {
            finalAnswer = primaryNumber * secondryNumber;
        }

        if (operation == "Divide")
        {
            finalAnswer = primaryNumber / secondryNumber;
        }

        Debug.Log("1number: " + primaryNumber + "2number: " + secondryNumber + " finalanswer :" + finalAnswer);
    }
}