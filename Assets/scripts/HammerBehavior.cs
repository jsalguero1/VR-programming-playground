using UnityEngine;

public class HammerBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionamos tiene el tag "Coin"
        if (collision.gameObject.CompareTag("Coin"))
        {
            // Obtenemos el script CoinBehavior de la moneda
            CoinBehavior moneda = collision.gameObject.GetComponent<CoinBehavior>();
            if (moneda != null)
            {
                // Obtenemos el valor actual del GlobalValueManager
                if (GlobalValueManager.Instance != null)
                {
                    float valorGlobal = GlobalValueManager.Instance.GetCurrentValue();
                    // Incrementamos el valor de la moneda usando el valor del GlobalValueManager
                    moneda.ActualizarValor(moneda.valorActual + valorGlobal);
                }
                else
                {
                    Debug.LogError("GlobalValueManager no está inicializado.");
                }
            }
            else
            {
                Debug.LogError("No se encontró el componente CoinBehavior en la moneda.");
            }
        }
    }
}