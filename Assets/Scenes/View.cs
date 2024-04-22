using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class View : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    public TextMeshProUGUI Screen;

    public event System.EventHandler UserPressedButtom;

    public delegate void Clicked(string value);

    public Clicked buttonPressed;

    

    //public TextMeshProUGUI displayText;

    private string currentInput = "";

    private double result = 0.0;

    public void OnButtonCLick(string buttonValue)
    {

        Debug.Log("Hello, " + buttonValue);

        //UserPressedButtom(buttonValue, );



        if (buttonValue == "=")
        {

            Calculateresult();
        }
        else if (buttonValue == "C")
        {
            Clearinput();
        }
        else
        {
            currentInput += buttonValue;
            UpdateDisplay();
        }
    }

    public void Calculateresult()
    {
        try
        {
            result = System.Convert.ToDouble(new System.Data.DataTable().Compute(currentInput, ""));

            currentInput = result.ToString();
        }
        catch (System.Exception)
        {
            currentInput = "Error";
        }


        UpdateDisplay();

    }


    private void Clearinput()
    {
        currentInput = "";
        result = 0.0;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        Screen.text = currentInput;

    }


}