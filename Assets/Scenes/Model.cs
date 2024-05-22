using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface para o model
public interface IModel
{
    event Action<string> AtualizaView;
    event Action<string> PassaErroAoControl;
    void CalculateResult(string value);
    void Initialize(IController controller);
}

public class Model : IModel
{
    public string result = "";

    public event Action<string> AtualizaView;
    public event Action<string> PassaErroAoControl;

    private IController controller;

    public Model() { }

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
            // Calcula o resultado usando a DataTable.Compute
            result = (System.Convert.ToDouble(new System.Data.DataTable().Compute(value, ""))).ToString();
            AtualizaView?.Invoke(result);
        }
        catch (FormatException ex)
        {
            // Tratamento para erros de formato
            PassaErroAoControl?.Invoke("Erro no formato: " + ex.Message);
        }
        catch (OverflowException ex)
        {
            // Tratamento para erros de overflow
            PassaErroAoControl?.Invoke("Erro de Overflow: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Tratamento para outros tipos de erro
            PassaErroAoControl?.Invoke("Erro: " + ex.Message);
        }
    }
}
