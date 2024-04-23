/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class View : MonoBehaviour
{

    private Controller controller;

    void Start()
    {
        controller = new Controller(this); // Pass reference to this View instance
    }

    public TextMeshProUGUI Screen;

    public event System.EventHandler UserPressedButtom;

    public delegate void Clicked(string value);

    public Clicked buttonPressed;




    public string currentInput = "";

    public double result = 0.0;

    public void OnButtonCLick(string buttonValue)
    {

        controller.buttonClicked(buttonValue);

    }



    public void Clearinput()
    {
        currentInput = "";
        result = 0.0;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        Screen.text = currentInput;

    }


}


public class Controller
{

    private View view;
    private Model model;

    public Controller(View viewInstance)
    {
        view = viewInstance;
        model = new Model(viewInstance);
    }

    public void buttonClicked(string value)
    {


        //Debug.Log("Hello, " + value);

        if (value == "=")
        {

            model.Calculateresult();
        }
        else if (value == "C")
        {
            view.Clearinput();
        }
        else
        {
            view.currentInput += value;
            view.UpdateDisplay();
        }


    }

}


public class Model
{

    private View view;

    public Model(View viewInstance)
    {
        view = viewInstance;
    }


    public void Calculateresult()
    {
        try
        {
            view.result = System.Convert.ToDouble(new System.Data.DataTable().Compute(view.currentInput, ""));

            view.currentInput = view.result.ToString();
        }
        catch (System.Exception)
        {
            view.currentInput = "Error";
        }


        view.UpdateDisplay();

    }

}
*/

// ----- Criado por mim para ver o funcionamento


using UnityEngine;
using TMPro;

public class View : MonoBehaviour
{
    public TextMeshProUGUI Screen; // Componente de texto para mostrar o resultado dos calculos na calculadora
    public string currentInput = ""; // Entrada dos valores pelo utilizador
    public double result = 0.0; // Resultado do �ltimo c�lculo efetuado

    // Atualiza a calculadora, ou com a entrada de valores, ou com o resultado final
    public void UpdateDisplay()
    {
        Screen.text = currentInput;
    }

    // Limpa todos os registos e resultados - clear.
    public void ClearInput()
    {
        currentInput = "";
        result = 0.0;
        UpdateDisplay();
    }
}

