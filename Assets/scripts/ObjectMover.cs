using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private Transform endPoint; // Punto final hacia donde moverse
    private bool isMoving = false; // Controla el estado del movimiento
    public float speed = 1.0f; // Velocidad del movimiento

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
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar si el objeto entra en contacto con un StartPoint
        TrackController trackController = other.GetComponentInParent<TrackController>();
        if (trackController != null)
        {
            Debug.Log($"{name} detectó el StartPoint de {trackController.name}");
            endPoint = trackController.GetEndPoint();
            isMoving = true;
        }
    }
}
