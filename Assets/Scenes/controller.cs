using System;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;

// IController.cs
public interface IController
{
    void ButtonClicked(string value);

    event Action<string> PassaAoModel;
    event Action<string> AtualizaView;

    void Initialize(IModel model); // Adicionando o método Initialize
}



public class Controller : IController
{
    // Entrada atual do utilizador
    public string currentInput = "";

    // Delegado para passar o buffer para a vista
    //public delegate void PassabufferView(string value);
    //public event PassabufferView AtualizaView;

    public event Action<string> AtualizaView;

    private IModel model;
    private IView view;


    // Delegado para passar o buffer para o modelo
    //public delegate void PassabufferModel(string value);
    //public event PassabufferModel PassaAoModel;
    public event Action<string> PassaAoModel;

    public Controller(IView view)
    {
        // Regista o m�todo buttonClicked para ser chamado quando um bot�o � clicado na vista

        this.view = view;
        view.BotaoClicado += ButtonClicked;
    }

    public void Initialize(IModel model)
    {
        this.model = model;
        model.PassaErroAoControl += errorHandling;
    }


    // M�todo chamado quando um bot�o � clicado na view
    public void ButtonClicked(string value)
    {
        if (value == "=")
        {
            PassaAoModel?.Invoke(currentInput);
        }
        else if (value == "C")
        {
            currentInput = "";
            AtualizaView?.Invoke(currentInput);
        }
        else if (value == "B")
        {

            if (!string.IsNullOrEmpty(currentInput))
            {
                // implement the logic to remove the last character
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
                AtualizaView?.Invoke(currentInput);
            }
        }
            
        else
        {
            currentInput += value;
            AtualizaView?.Invoke(currentInput);
        }
    }

    public void errorHandling(string error)
    {
        
        ((MonoBehaviour)view).StartCoroutine(ErrorHandlingCoroutine(error));

    }

    private IEnumerator ErrorHandlingCoroutine(string error)
    {
        AtualizaView?.Invoke(error);
        yield return new WaitForSeconds(2);
        AtualizaView?.Invoke(currentInput);
    }


}
