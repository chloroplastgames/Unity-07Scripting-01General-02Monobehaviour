﻿using UnityEngine;
using UnityEngine.UI;
using MathLibrary;
using UnityEngine.Serialization;

public class CalculatorCanvas : MonoBehaviour
{

    #region UI SerializeField Variables

    [SerializeField]
    [FormerlySerializedAs("firsFactorInput")]
    private InputField firsFactorInput;

    [SerializeField]
    [FormerlySerializedAs("secondFactorInput")]
    private InputField secondFactorInput;

    [SerializeField]
    [FormerlySerializedAs("dropdown")]
    private Dropdown dropdown;

    [SerializeField]
    [FormerlySerializedAs("resultText")]
    private Text resultText;

    #endregion


    #region Private Variables 

    private float firsFactor;

    private float secondFactor;

    #endregion


    void Start()
    {
        firsFactorInput.text = "0";
        secondFactorInput.text = "0";

        firsFactor = 0f;
        secondFactor = 0f;
    }


    public void ExecuteOperation()
    {
        if (!CheckFactors()) 
            return;
       
        string valueResult = "0";

        switch (dropdown.value)
        {
            case 0: //add
                valueResult = MyMath.Add(firsFactor, secondFactor).ToString();
                break;

            case 1: //Substract
                valueResult = MyMath.Subtract(firsFactor, secondFactor).ToString();
                break;

            case 2: //Multiply
                valueResult = MyMath.Multiply(firsFactor, secondFactor).ToString();
                break;

            case 3: //Divide
                valueResult = MyMath.Divide(firsFactor, secondFactor).ToString();
                break;

            default:
                Debug.LogError("Wrong Option");
                break;
        }

        resultText.text = valueResult;
        resultText.color = Color.green;
    }


    private bool CheckFactors()
    {
        if (string.IsNullOrEmpty(firsFactorInput.text) || string.IsNullOrEmpty(secondFactorInput.text))
        {
            Debug.LogError("Fill in all the fields");
            return false;
        }

        firsFactor = float.Parse(firsFactorInput.text);
        secondFactor = float.Parse(secondFactorInput.text);

        return true;
    }
}
