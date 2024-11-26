using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrackConnector : MonoBehaviour
{
    public string targetTag = "Track"; // Tag objetivo para verificar
    private XRGrabInteractable grabInteractable; // Referencia al XRGrabInteractable
    private bool isBeingGrabbed = false; // Indica si el objeto está siendo agarrado

    private void Awake()
    {
        // Obtener el componente XRGrabInteractable
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            // Suscribirse a los eventos de agarre y liberación
            grabInteractable.selectEntered.AddListener(OnGrabbed);
            grabInteractable.selectExited.AddListener(OnReleased);
        }
    }

    private void OnDestroy()
    {
        // Desuscribirse de los eventos para evitar referencias nulas
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
            grabInteractable.selectExited.RemoveListener(OnReleased);
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        isBeingGrabbed = true; // Marcar como agarrado
        SetKinematicState(false); // Desactivar cinético mientras está agarrado
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        isBeingGrabbed = false; // Marcar como no agarrado
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Solo procesar colisiones si el objeto no está siendo agarrado
        if (!isBeingGrabbed && collision.gameObject.CompareTag(targetTag))
        {
            SetKinematicState(false); // Desactivar cinético al colisionar
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Solo procesar si el objeto no está siendo agarrado
        if (!isBeingGrabbed && collision.gameObject.CompareTag(targetTag))
        {
            SetKinematicState(true); // Activar cinético al dejar de colisionar
        }
    }

    private void SetKinematicState(bool state)
    {
        // Cambiar el estado cinético del objeto actual
        Rigidbody thisRigidbody = GetComponent<Rigidbody>();
        if (thisRigidbody != null)
        {
            thisRigidbody.isKinematic = state;
        }
    }
}
