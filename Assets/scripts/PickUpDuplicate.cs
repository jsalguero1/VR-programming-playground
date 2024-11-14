using UnityEngine;

public class PickupDuplicate : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab del objeto que se va a copiar
    private GameObject duplicateObject;

    void Update()
    {
        // Detectar si el jugador intenta agarrar el objeto (ej. clic o botón)
        if (Input.GetButtonDown("Fire1") && duplicateObject == null)
        {
            DuplicateAndPickupObject();
        }
    }

    void DuplicateAndPickupObject()
    {
        // Crear una copia en la posición y rotación del objeto base
        duplicateObject = Instantiate(objectPrefab, transform.position, transform.rotation);
        
        // Habilitar física en la copia para que responda a la gravedad
        Rigidbody rb = duplicateObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; // Permitir que responda a la gravedad
            rb.useGravity = true;    // Activar gravedad para el objeto duplicado
        }

        // Aquí agregamos la lógica para "agarrar" inmediatamente la copia
        // Esto depende de cómo manejes los objetos agarrados en tu VR o sistema de agarre:
        // - Si tienes un script de "agarre" en el jugador o controlador, llama el método desde allí.
        // - Si usas VR, puedes llamar a un script de "agarre" en el controlador de la mano.
        
        // Ejemplo simple: mover el objeto copiado al "agarrarlo"
        duplicateObject.transform.SetParent(transform); // opcional, asigna el objeto copiado al jugador o controlador
    }
}