using UnityEngine;
using TMPro;

public class CoinBehavior : MonoBehaviour
{
    public TextMeshProUGUI Valor; // Referencia al componente TextMeshPro dentro del Canvas
    public float valorActual = 1f; // Valor inicial de la moneda

private void Start()
{
    Valor.text = "0"; // Inicializamos el texto con un valor por defecto
    // Si el TMP no tiene texto inicial, lo asignamos desde el valor actual
    if (Valor.text == "0")
    {
        Valor.text = valorActual.ToString("F0"); // Por defecto, muestra un entero
    }

    // Actualizamos el texto para reflejar el valor inicial
    ActualizarValor(valorActual);
}

    public void ActualizarValor(float nuevoValor)
    {
        valorActual = nuevoValor; // Actualizamos el valor interno
        if (Valor != null)
        {
            Valor.text = valorActual.ToString("F0"); // Mostramos el nuevo valor como entero
            Debug.Log($"Valor de la moneda actualizado a: {valorActual}");
        }
        else
        {
            Debug.LogError("El componente TextMeshPro no está asignado en la moneda.");
        }
    }
}