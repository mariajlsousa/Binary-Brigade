using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface para o controller
public interface IController
{
    void ButtonClicked(string value);
    event Action<string> PassaAoModel;
    event Action<string> AtualizaView;
    void Initialize(IModel model);
}

public class Controller : IController
{
    // Entrada atual do utilizador
    public string currentInput = "";

    public event Action<string> AtualizaView;
    public event Action<string> PassaAoModel;

    private IModel model;
    private IView view;

    public Controller(IView view)
    {
        
        this.view = view;

        // Regista o método ButtonClicked para ser chamado quando um botão é clicado na view
        view.BotaoClicado += ButtonClicked;
    }

    public void Initialize(IModel model)
    {
        this.model = model;
        model.PassaErroAoControl += ErrorHandling;
    }

    // Método chamado quando um botão é clicado na view
    public void ButtonClicked(string value)
    {
        switch (value)
        {
            case "=":
                PassaAoModel?.Invoke(currentInput);
                break;
            case "C":
                currentInput = "";
                AtualizaView?.Invoke(currentInput);
                break;
            case "B":
                if (!string.IsNullOrEmpty(currentInput))
                {
                    // Remove o último caracter
                    currentInput = currentInput.Substring(0, currentInput.Length - 1);
                    AtualizaView?.Invoke(currentInput);
                }
                break;
            default:
                currentInput += value;
                AtualizaView?.Invoke(currentInput);
                break;
        }
    }

    public void ErrorHandling(string error)
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
