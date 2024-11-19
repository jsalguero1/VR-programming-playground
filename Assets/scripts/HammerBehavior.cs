using UnityEngine;

public class HammerBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionamos tiene el tag "Coin"
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Colisión detectada con una moneda.");

            // Obtenemos el script CoinBehavior de la moneda
            CoinBehavior moneda = collision.gameObject.GetComponent<CoinBehavior>();
            if (moneda != null)
            {
                // Aumentamos el valor de la moneda en 1
                float nuevoValor = moneda.valorActual + 1;
                moneda.ActualizarValor(nuevoValor);

                Debug.Log($"Nuevo valor de la moneda: {nuevoValor}");
            }
        }
    }
}