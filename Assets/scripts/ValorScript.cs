using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class Valor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que entra en contacto tiene el tag "Coin"
        if (other.CompareTag("Coin"))
        {
            // Busca el Canvas dentro del objeto "Coin"
            Transform canvasTransform = other.transform.Find("Canvas");
            if (canvasTransform != null)
            {
                // Busca el componente TMP en el Canvas
                TextMeshProUGUI tmp = canvasTransform.GetComponentInChildren<TextMeshProUGUI>();
                if (tmp != null)
                {
                    // Imprime el texto en la consola
                    Debug.Log($"Texto encontrado en Coin: {tmp.text}");
                }
                else
                {
                    Debug.LogWarning("No se encontró un componente TextMeshProUGUI en el Canvas del Coin.");
                }
            }
            else
            {
                Debug.LogWarning("No se encontró un objeto Canvas como hijo del Coin.");
            }
        }
    }
}
