using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    //public double result = 0.0;
    public string result = "";

    // Delegado para passar o resultado para a view
    public delegate void PassaResultado(string value);
    public event PassaResultado? AtualizaView;

    // Construtor do modelo
    public Model(Controller controller)
    {
        // Registar o m�todo Calculateresult para ser chamado quando uma opera��o � solicitada
        controller.PassaAoModel += Calculateresult;
    }

    // M�todo para calcular o resultado da opera��o
    public void Calculateresult(string value)
    {
        try
        {
            result = (System.Convert.ToDouble(new System.Data.DataTable().Compute(value, ""))).ToString() ;

        }
        catch (System.Exception)
        {
            result = "Error";
        }

        AtualizaView?.Invoke(result);


    }

}