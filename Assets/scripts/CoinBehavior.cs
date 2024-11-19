using UnityEngine;
using TMPro;

public class CoinBehavior : MonoBehaviour
{
    public TMP_Text valorText; // Campo de texto para mostrar el valor
    public float valorActual = 1f; // Valor inicial de la moneda

    private void Start()
    {
        // Inicializar el valor visual
        ActualizarValor(valorActual);
    }

    public void ActualizarValor(float nuevoValor)
    {
        valorActual = nuevoValor;
        if (valorText != null)
        {
            valorText.text = valorActual.ToString("F2"); // Dos decimales para claridad
        }
    }
}