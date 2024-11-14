using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickupDuplicate : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab del objeto que se va a copiar
    private GameObject duplicateObject;
    private Collider originalCollider; // Para desactivar el collider del objeto original
    private XRGrabInteractable originalGrabInteractable; // Para desactivar el XR Grab del original

    void Start()
    {
        // Obtén el collider y XR Grab Interactable del objeto original al inicio
        originalCollider = GetComponent<Collider>();
        originalGrabInteractable = GetComponent<XRGrabInteractable>();
    }

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

        // Desactivar el collider y el XR Grab Interactable del objeto original
        if (originalCollider != null)
        {
            originalCollider.enabled = false;
        }
        if (originalGrabInteractable != null)
        {
            originalGrabInteractable.enabled = false;
        }

        // Hacer que la copia también tenga el componente XR Grab Interactable
        duplicateObject.AddComponent<XRGrabInteractable>();
    }
}