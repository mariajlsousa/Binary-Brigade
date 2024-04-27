using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;



public class View : MonoBehaviour
{
    // Referência para o controlador e modelo
    private Controller controller;
    private Model model;

    // Referência para o texto na tela
    public TextMeshProUGUI Screen;


    // Definição de um delegate para lidar com cliques nos botões
    public delegate void AoClicarNoBotao(string value);
    public event AoClicarNoBotao BotaoClicado;


    void Start()
    {
        // Inicialização do controlador e modelo
        controller = new Controller(this); 
        model = new Model(controller );

        // Registro de métodos para atualizar a view quando necessário
        controller.AtualizaView += UpdateDisplay;
        model.AtualizaView += UpdateDisplay;

    }

    // Método chamado quando um botão é clicado
    public void OnButtonCLick(string buttonValue )
    {
        BotaoClicado?.Invoke(buttonValue);
    }

    // Método para atualizar o texto exibido na tela
    public void UpdateDisplay(string current)
    {
        Screen.text = current;
    }
}