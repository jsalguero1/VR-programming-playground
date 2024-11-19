using UnityEngine;

public class HammerBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto golpeado es una moneda
        if (other.CompareTag("Coin"))
        {
            CoinBehavior coin = other.GetComponent<CoinBehavior>();
            if (coin != null)
            {
                AplicarOperacion(coin);
            }
        }
    }

    private void AplicarOperacion(CoinBehavior coin)
    {
        // Obtener los valores del MenuManager
        float valorOperacion = MenuManager.Instance.valorOperacion;
        string operacion = MenuManager.Instance.operacionSeleccionada;

        // Valor actual de la moneda
        float valorActual = coin.valorActual;
        float nuevoValor = valorActual;

        // Aplicar la operación seleccionada
        switch (operacion)
        {
            case "Sumar":
                nuevoValor = valorActual + valorOperacion;
                break;
            case "Restar":
                nuevoValor = valorActual - valorOperacion;
                break;
            case "Multiplicar":
                nuevoValor = valorActual * valorOperacion;
                break;
            case "Dividir":
                if (valorOperacion != 0)
                    nuevoValor = valorActual / valorOperacion;
                else
                    Debug.LogWarning("División por cero no permitida.");
                break;
        }

        // Actualizar el valor de la moneda
        coin.ActualizarValor(nuevoValor);
    }
}