using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSnapper : MonoBehaviour
{
    public float snapDistance = 0.1f; // Distancia para activar el snapping
    public float breakForce = 50f;   // Fuerza máxima antes de romper el Joint
    public float breakTorque = 50f;

    public Transform anchorTab; // Punto de anclaje de la pestaña
    public Transform anchorSlot; // Punto de anclaje de la ranura

    private void OnTriggerEnter(Collider col)
    {
        TrackSnapper otherSnapper = col.gameObject.GetComponent<TrackSnapper>();

        if (otherSnapper != null)
        {
            // Verifica si la pestaña está cerca de la ranura del otro objeto
            if (Vector3.Distance(anchorTab.position, otherSnapper.anchorSlot.position) <= snapDistance)
            {
                CreateJoint(col, otherSnapper.anchorSlot.position, anchorTab.position);
            }
            else if (Vector3.Distance(anchorSlot.position, otherSnapper.anchorTab.position) <= snapDistance)
            {
                CreateJoint(col, otherSnapper.anchorTab.position, anchorSlot.position);
            }
        }
    }

    private void CreateJoint(Collider col, Vector3 targetPosition, Vector3 anchorPosition)
    {
        // Crea un HingeJoint para conectar los objetos
        HingeJoint joint = gameObject.AddComponent<HingeJoint>();
        joint.connectedBody = col.GetComponent<Rigidbody>();

        // Ajusta la posición del anclaje al punto objetivo
        joint.anchor = transform.InverseTransformPoint(anchorPosition);

        // Ajusta la posición del Joint al punto objetivo
        joint.connectedAnchor = col.transform.InverseTransformPoint(targetPosition);

        // Configura las propiedades del Joint
        joint.breakForce = breakForce;
        joint.breakTorque = breakTorque;
        joint.enableCollision = false; // Evita colisiones repetidas
    }
}

