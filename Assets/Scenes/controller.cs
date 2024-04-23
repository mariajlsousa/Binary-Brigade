/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllerold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

}

*/
// para verificar o funcionamento


using UnityEngine;

public class Controller : MonoBehaviour
{
    public View view; // apontador para a View.
    private Model model; // apontador para o Model.

    void Start()
    {
        model = new Model();
        model.OnCalculationDone += HandleCalculationDone; // assume o evento da calculadora
    }

    void OnDestroy()
    {
        model.OnCalculationDone -= HandleCalculationDone; // apaga o evento da calculadora
    }

    // chamada do método chamado quando um botão é pressionado.
    public void ButtonClicked(string value)
    {
        if (value == "=")
        {
            model.CalculateResult(view.currentInput); // Faz o cálculode valores.
        }
        else if (value == "C")
        {
            view.ClearInput(); // se for pressionado o botao clear, apaga
        }
        else
        {
            view.currentInput += value; // Adiciona o valor do botão à entrada atual
            view.UpdateDisplay(); // atualiza o valor com a operação solicitada
        }
    }

    // Método para a chamada do calculo de operações
    private void HandleCalculationDone(double result)
    {
        if (double.IsNaN(result))
        {
            view.currentInput = "Error"; // devolve erro se o resultado não for um número.
        }
        else
        {
            view.result = result;
            view.currentInput = result.ToString(); // Atualiza os valores de resultado
        }
        view.UpdateDisplay(); // Atualiza a calculadora.
    }
}
