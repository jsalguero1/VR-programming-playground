using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSnapper : MonoBehaviour
{
    public float snapDistance = 0.1f; // Distancia para activar el snapping
    public float breakForce = 50f;   // Fuerza máxima antes de romper el Joint
    public float breakTorque = 50f;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<Rigidbody>() != null)
        {
            // Encuentra el punto más cercano en el lado más pequeño del colisionador
            Vector3 closestPoint = FindClosestSmallSide(col);

            if (Vector3.Distance(closestPoint, transform.position) <= snapDistance)
            {
                // Crea un HingeJoint para conectar los objetos
                HingeJoint joint = gameObject.AddComponent<HingeJoint>();
                joint.connectedBody = col.GetComponent<Rigidbody>();

                // Define el punto de anclaje (ajusta la posición al lado más cercano)
                joint.anchor = transform.InverseTransformPoint(closestPoint);

                // Define las propiedades del Joint
                joint.breakForce = breakForce;
                joint.breakTorque = breakTorque;
                joint.enableCollision = false; // Evita colisiones repetidas

                Debug.Log("HingeJoint creado.");
            }
        }
    }

    private Vector3 FindClosestSmallSide(Collider col)
    {
        Vector3 closestPoint = Vector3.zero;
        float closestDistance = float.MaxValue;

        Bounds bounds = col.bounds;

        // Calcula los lados más pequeños del BoxCollider
        Vector3[] smallSides = {
            bounds.min, // Esquina inferior izquierda
            new Vector3(bounds.min.x, bounds.min.y, bounds.max.z), // Esquina inferior derecha
            new Vector3(bounds.max.x, bounds.min.y, bounds.min.z), // Esquina superior izquierda
            new Vector3(bounds.max.x, bounds.min.y, bounds.max.z)  // Esquina superior derecha
        };

        // Encuentra el punto más cercano
        foreach (Vector3 side in smallSides)
        {
            float distance = Vector3.Distance(transform.position, side);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = side;
            }
        }

        return closestPoint;
    }
}
