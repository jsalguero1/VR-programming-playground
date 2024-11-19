using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class CoinBehavior : MonoBehaviour
{
    public TextMeshPro Valor; // Referencia al texto que muestra el valor
    public float valorActual = 1f; // Valor inicial de la moneda

    private void Start()
    {
        ActualizarValor(valorActual); // Inicializa el texto con el valor actual
    }

    public void ActualizarValor(float nuevoValor)
    {
        valorActual = nuevoValor; // Actualiza el valor interno
        Valor.text = valorActual.ToString("F2"); // Actualiza el texto visible con dos decimales
    }
}