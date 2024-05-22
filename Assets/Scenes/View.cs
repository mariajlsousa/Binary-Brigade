using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;

// Interface para a View
public interface IView
{
    event Action<string> BotaoClicado;
    void UpdateDisplay(string current);
}


// Implementação da View
public class View : MonoBehaviour, IView
{
    // Referência para o controlador e modelo
    private IController controller;
    private IModel model;

    // Referência para o texto no ecrã
    public TextMeshProUGUI Screen;


    // Evento acionado quando um botão é clicado
    public event Action<string> BotaoClicado;

    void Start()
    {
        // Inicialização das instâncias concretas sem dependências
        controller = new Controller(this);
        model = new Model();

        // Injeção das dependências depois da inicialização
        controller.Initialize(model);
        model.Initialize(controller);


        // Registro de métodos para atualizar a view quando necessário
        controller.AtualizaView += UpdateDisplay;
        model.AtualizaView += UpdateDisplay;

    }

    // Método chamado quando um botão é clicado
    public void OnButtonCLick(string buttonValue )
    {
        BotaoClicado?.Invoke(buttonValue);
    }

    // Método para atualizar o texto exibido no ecrã
    public void UpdateDisplay(string current)
    {
        Screen.text = current;
    }
}