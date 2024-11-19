using UnityEngine;

public class HammerBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionamos tiene el tag "Coin"
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Colisión detectada con una moneda.");
        }
        else
        {
            Debug.Log("Colisión con otro objeto: " + collision.gameObject.name);
        }
    }
}