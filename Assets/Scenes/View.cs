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
    // Refer�ncia para o controlador e modelo
    private IController controller;
    private IModel model;

    // Refer�ncia para o texto na tela
    public TextMeshProUGUI Screen;


    // Defini��o de um delegate para lidar com cliques nos bot�es
    //public delegate void AoClicarNoBotao(string value);
    //public event AoClicarNoBotao BotaoClicado;
    public event Action<string> BotaoClicado;

    void Start()
    {
        // Inicializa��o das inst�ncias concretas sem depend�ncias
        controller = new Controller(this);
        model = new Model();

        // Inje��o das depend�ncias depois da inicializa��o
        controller.Initialize(model);
        model.Initialize(controller);


        // Registro de m�todos para atualizar a view quando necess�rio
        controller.AtualizaView += UpdateDisplay;
        model.AtualizaView += UpdateDisplay;

    }

    // M�todo chamado quando um bot�o � clicado
    public void OnButtonCLick(string buttonValue )
    {
        BotaoClicado?.Invoke(buttonValue);
    }

    // M�todo para atualizar o texto exibido no ecra
    public void UpdateDisplay(string current)
    {
        Screen.text = current;
    }
}