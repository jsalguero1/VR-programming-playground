using UnityEngine;

public class PickupDuplicate : MonoBehaviour
{
    public GameObject objectPrefab; // Asigna aquí el prefab del objeto en el inspector
    private GameObject duplicateObject;

    void Update()
    {
        // Detectar si el jugador intenta agarrar el objeto (ej. con clic o botón)
        if (Input.GetButtonDown("Fire1") && duplicateObject == null)
        {
            DuplicateObject();
        }
    }

    void DuplicateObject()
    {
        // Crear una copia en la posición y rotación del objeto base
        duplicateObject = Instantiate(objectPrefab, transform.position, transform.rotation);
        
        // Activar física en la copia (si es necesario)
        Rigidbody rb = duplicateObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        // Opcional: Puedes añadir lógica para que el objeto se "agarre" automáticamente
        // Por ejemplo, usando otro script para manipular el objeto en la mano del jugador
    }
}
