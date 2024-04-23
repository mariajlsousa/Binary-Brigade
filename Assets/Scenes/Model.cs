/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modelold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/

// Criado por mim, para verificar o funcionamento


using System;

public class Model
{
    // Delegado para os metodoso de calculo
    public delegate void CalculationDoneHandler(double result);

    // Evento de conclusão do calculo.
    public event CalculationDoneHandler OnCalculationDone;

    // Método que realiza o cálculo baseado na entrada de valores na calculadora.
    public void CalculateResult(string input)
    {
        try
        {
            double result = Convert.ToDouble(new System.Data.DataTable().Compute(input, ""));
            OnCalculationDone?.Invoke(result);  // Mostra o evento com o resultado.
        }
        catch (Exception)
        {
            OnCalculationDone?.Invoke(double.NaN);  // Mostra o resultado com NaN para indicar erro.
        }
    }
}

