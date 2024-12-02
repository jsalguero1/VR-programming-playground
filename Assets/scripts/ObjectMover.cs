using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private Transform endPoint; // Punto final hacia donde moverse
    private Collider endPointCollider; // Referencia al Collider del EndPoint
    private bool isMoving = false; // Controla el estado del movimiento
    public float speed = 0.2f; // Velocidad del movimiento
    public float deactivateTime = 2.0f; // Tiempo que el Collider estará desactivado

    void Update()
    {
        if (isMoving)
        {
            // Mover hacia el punto final
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);

            // Detener el movimiento al llegar al punto final
            if (transform.position == endPoint.position)
            {
                isMoving = false;
                Debug.Log($"{name} ha llegado al EndPoint.");
                StartCoroutine(DeactivateEndPointColliderTemporarily());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar si el objeto entra en contacto con un StartPoint
        if (other.CompareTag("StartPoint"))
        {
            TrackController trackController = other.GetComponentInParent<TrackController>();
            if (trackController != null)
        {
            Debug.Log($"{name} detectó el StartPoint de {trackController.name}");
            endPoint = trackController.GetEndPoint();
            endPointCollider = endPoint.GetComponent<Collider>(); // Obtener el Collider del EndPoint
            isMoving = true;
        }
        }

    }

    private System.Collections.IEnumerator DeactivateEndPointColliderTemporarily()
    {
        if (endPointCollider != null)
        {
            Debug.Log($"Desactivando el Collider del EndPoint: {endPoint.name}");
            endPointCollider.enabled = false; // Desactiva el Collider
            yield return new WaitForSeconds(deactivateTime); // Espera el tiempo especificado
            endPointCollider.enabled = true; // Reactiva el Collider
            Debug.Log($"Collider del EndPoint {endPoint.name} reactivado.");
        }
    }
}
