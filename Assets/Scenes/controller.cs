using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    // Entrada atual do utilizador
    public string currentInput = "";

    // Delegado para passar o buffer para a vista
    public delegate void PassabufferView(string value);
    public event PassabufferView AtualizaView;

    // Delegado para passar o buffer para o modelo
    public delegate void PassabufferModel(string value);
    public event PassabufferModel PassaAoModel;

    public Controller(View view)
    {
        // Regista o m�todo buttonClicked para ser chamado quando um bot�o � clicado na vista
        view.BotaoClicado += buttonClicked;
    }

    // M�todo chamado quando um bot�o � clicado na view
    public void buttonClicked(string value)
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
            
        // implement the logic to remove the last character
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            AtualizaView?.Invoke(currentInput);
}
else

            // implement the logic to remove the last character

            //AtualizaView?.Invoke(currentInput);
        }
        else
        {
            currentInput += value;
            AtualizaView?.Invoke(currentInput);
        }
    }
