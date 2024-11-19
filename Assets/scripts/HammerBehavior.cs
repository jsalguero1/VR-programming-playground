using UnityEngine;

public class HammerBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionamos es una moneda
        if (collision.gameObject.CompareTag("Coin")) // Asegúrate de que las monedas tienen el tag "Coin"
        {
            CoinBehavior moneda = collision.gameObject.GetComponent<CoinBehavior>();
            if (moneda != null)
            {
                AplicarOperacion(moneda);
            }
        }
    }

    private void AplicarOperacion(CoinBehavior moneda)
    {
        float valorMoneda = moneda.valorActual; // Obtiene el valor actual de la moneda
        float valorOperacion = MenuManager.Instance.valorOperacion; // Valor del menú
        string operacion = MenuManager.Instance.operacionSeleccionada; // Operación del menú

        float nuevoValor = valorMoneda; // Inicializamos con el valor actual de la moneda

        // Comparamos las palabras seleccionadas y aplicamos la operación correspondiente
        switch (operacion.ToLower()) // Convertimos a minúsculas para evitar problemas de mayúsculas/minúsculas
        {
            case "sumar":
                nuevoValor = valorMoneda + valorOperacion;
                break;
            case "restar":
                nuevoValor = valorMoneda - valorOperacion;
                break;
            case "multiplicar":
                nuevoValor = valorMoneda * valorOperacion;
                break;
            case "dividir":
                if (valorOperacion != 0)
                    nuevoValor = valorMoneda / valorOperacion;
                else
                    Debug.LogWarning("No se puede dividir entre cero.");
                break;
            default:
                Debug.LogWarning($"Operación '{operacion}' no reconocida.");
                break;
        }

        // Actualizamos el valor de la moneda
        moneda.ActualizarValor(nuevoValor);
    }
}