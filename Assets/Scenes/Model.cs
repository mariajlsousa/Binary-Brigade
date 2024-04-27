using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    //public double result = 0.0;
    public string result = "";

    // Delegado para passar o resultado para a view
    public delegate void PassaResultado(string value);
    public event PassaResultado AtualizaView;

    // Construtor do modelo
    public Model(Controller controller)
    {
        // subscreve o evento do do controller ao metodo Calculateresult 
        controller.PassaAoModel += Calculateresult;
    }

    // Método para calcular o resultado da operação
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