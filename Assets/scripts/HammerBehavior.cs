using UnityEngine;

public class HammerBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
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
        float valorMoneda = moneda.valorActual;
        float valorOperacion = MenuManager.Instance.valorOperacion;
        string operacion = MenuManager.Instance.operacionSeleccionada;

        float nuevoValor = valorMoneda;

        switch (operacion.ToLower())
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
                {
                    nuevoValor = valorMoneda / valorOperacion;
                }
                else
                {
                    Debug.LogWarning("No se puede dividir entre cero.");
                }
                break;
            default:
                Debug.LogWarning($"Operación no reconocida: {operacion}");
                break;
        }

        moneda.ActualizarValor(nuevoValor);
    }
}