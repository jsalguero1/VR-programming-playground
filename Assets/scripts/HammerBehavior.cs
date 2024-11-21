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
                // Obtenemos el valor actual del GlobalValueManager como string
                if (GlobalValueManager.Instance != null)
                {
                    string valorGlobalStr = GlobalValueManager.Instance.GetCurrentValue();
                    if (float.TryParse(valorGlobalStr, out float valorGlobal))
                    {
                        // Incrementamos el valor de la moneda usando el valor convertido
                        moneda.ActualizarValor(moneda.valorActual + valorGlobal);
                    }
                    else
                    {
                        Debug.LogError($"El valor global '{valorGlobalStr}' no se pudo convertir a float.");
                    }
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