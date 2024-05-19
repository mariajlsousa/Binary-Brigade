using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;


public interface IView
{
    event Action<string> BotaoClicado;
    void UpdateDisplay(string current);
}


public class View : MonoBehaviour, IView
{
    // Referência para o controlador e modelo
    private IController controller;
    private IModel model;

    // Referência para o texto na tela
    public TextMeshProUGUI Screen;


    // Definição de um delegate para lidar com cliques nos botões
    //public delegate void AoClicarNoBotao(string value);
    //public event AoClicarNoBotao BotaoClicado;
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

    // Método para atualizar o texto exibido no ecra
    public void UpdateDisplay(string current)
    {
        Screen.text = current;
    }
}