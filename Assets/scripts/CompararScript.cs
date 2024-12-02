using UnityEngine;
using TMPro;

public class CompararScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            // Obtener el componente TextMeshPro del objeto Coin
            TextMeshPro tmpComponent = other.GetComponent<TextMeshPro>();

            if (tmpComponent != null)
            {
                string tmpValue = tmpComponent.text;

                // Guardar el valor TMP donde lo necesites
                // Por ejemplo, imprimir en consola
                Debug.Log("Valor TMP leído: " + tmpValue);

                // Aquí puedes almacenar tmpValue en una variable o lista
                // Ejemplo: listaValoresTMP.Add(tmpValue);
            }
            else
            {
                Debug.LogWarning("El objeto Coin no tiene un componente TextMeshPro.");
            }
        }
    }
}
