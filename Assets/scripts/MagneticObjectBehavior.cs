using UnityEngine;

public class MagneticObjectBehavior : MonoBehaviour
{
    public float attractionRadius = 0.5f;
    public float snapDistance = 0.1f;
    public float attractionSpeed = 5f;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRadius);

        foreach (var collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.CompareTag("MagneticChar"))
            {
                Vector3 direction = collider.transform.position - transform.position;
                float distance = direction.magnitude;

                if (distance > snapDistance)
                {
                    // Atracción suave
                    transform.position = Vector3.Lerp(transform.position, collider.transform.position, attractionSpeed * Time.deltaTime);
                }
                else
                {
                    // Ajustar posición exacta al rango mínimo
                    transform.position = collider.transform.position;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attractionRadius);
    }
}