using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSnapper : MonoBehaviour
{
    public float snapDistance = 0.1f; // Distancia para activar el snapping
    public float breakForce = 50f;   // Fuerza máxima antes de romper el Joint
    public float breakTorque = 50f;

    private void OnTriggerEnter(Collider col)
    {
        // Verifica si el objeto tiene el tag "Char"
        if (col.gameObject.CompareTag("Char") && col.gameObject.GetComponent<Rigidbody>() != null)
        {
            // Encuentra el lado más cercano para hacer el snapping
            Vector3 closestPoint = FindClosestSide(col);

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

                Debug.Log($"HingeJoint creado entre {gameObject.name} y {col.gameObject.name}");
            }
        }
        else
        {
            Debug.Log($"{col.gameObject.name} no tiene el tag 'Char' o no tiene Rigidbody.");
        }
    }

    private Vector3 FindClosestSide(Collider col)
    {
        Vector3 closestPoint = Vector3.zero;
        float closestDistance = float.MaxValue;

        // Itera por cada lado del colisionador (puedes mejorar esto con puntos específicos)
        Bounds bounds = col.bounds;
        Vector3[] sides = {
            bounds.min, new Vector3(bounds.min.x, bounds.min.y, bounds.max.z),
            bounds.max, new Vector3(bounds.max.x, bounds.max.y, bounds.min.z)
        };

        foreach (Vector3 side in sides)
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
