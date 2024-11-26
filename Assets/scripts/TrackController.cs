using UnityEngine;

public class TrackController : MonoBehaviour
{
    public Transform startPoint; // Punto de inicio de la pista
    public Transform endPoint;   // Punto final de la pista

    // Métodos para exponer los puntos
    public Transform GetStartPoint() => startPoint;
    public Transform GetEndPoint() => endPoint;
}
