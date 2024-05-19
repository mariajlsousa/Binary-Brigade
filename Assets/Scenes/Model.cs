using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// IModel.cs
public interface IModel
{
 
    public event Action<string> AtualizaView;
    public event Action<string> PassaErroAoControl;
    void CalculateResult(string value);

    void Initialize(IController controller); // Adicionando o método Initialize
}


public class Model : IModel
{
    //public double result = 0.0;
    public string result = "";

    public event Action<string> AtualizaView;
    public event Action<string> PassaErroAoControl;

    private IController controller;


    // Construtor do modelo
    public Model()
    {
    }

    public void Initialize(IController controller)
    {
        this.controller = controller;
        controller.PassaAoModel += CalculateResult;
    }


    // Método para calcular o resultado da operação
    public void CalculateResult(string value)
    {
        try
        {
            result = (System.Convert.ToDouble(new System.Data.DataTable().Compute(value, ""))).ToString() ;
            AtualizaView?.Invoke(result);
        }
        catch (FormatException ex)
        {
            // Handle format-related errors
            //result = "Erro no formato: " + ex.Message;
            PassaErroAoControl?.Invoke(ex.Message);
            //Debug.Log("Format Error: " + ex.Message);
        }
        catch (OverflowException ex)
        {
            // Handle overflow errors
            //result = "Erro de Overflow: " + ex.Message;
            PassaErroAoControl?.Invoke(ex.Message);
            //Debug.Log("Overflow Error: " + ex.Message);
        }
        catch (System.Exception ex)
        {
            //result = "Error";
            // = ex.Message;
            PassaErroAoControl?.Invoke(ex.Message);
            //Debug.Log("Error = " + ex.Message);
        }

        

    }

   }