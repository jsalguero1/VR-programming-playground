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
                float nuevoValor = moneda.valorActual + 1; // Incrementamos el valor en 1
                moneda.ActualizarValor(nuevoValor); // Actualizamos el valor en la moneda
            }
            else
            {
                Debug.LogError("No se encontró el componente CoinBehavior en la moneda.");
            }
        }
    }
}