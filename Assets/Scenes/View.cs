using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;



public class View : MonoBehaviour
{
    // Refer�ncia para o controlador e modelo
    private Controller controller;
    private Model model;

    // Refer�ncia para o texto na tela
    public TextMeshProUGUI Screen;


    // Defini��o de um delegate para lidar com cliques nos bot�es
    public delegate void AoClicarNoBotao(string value);
    public event AoClicarNoBotao BotaoClicado;


    void Start()
    {
        // Inicializa��o do controlador e modelo
        controller = new Controller(this); 
        model = new Model(controller );

        // Registro de m�todos para atualizar a view quando necess�rio
        controller.AtualizaView += UpdateDisplay;
        model.AtualizaView += UpdateDisplay;

    }

    // M�todo chamado quando um bot�o � clicado
    public void OnButtonCLick(string buttonValue )
    {
        BotaoClicado?.Invoke(buttonValue);
    }

    // M�todo para atualizar o texto exibido na tela
    public void UpdateDisplay(string current)
    {
        Screen.text = current;
    }
}