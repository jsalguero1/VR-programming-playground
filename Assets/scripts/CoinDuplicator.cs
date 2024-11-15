using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDuplicator : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;  // Prefab de la moneda que se generará
    [SerializeField] private Transform spawnPoint;   // Punto donde aparecerá la copia
    [SerializeField] private Collider originalCollider; // Collider de la moneda original para detectar colisiones

    private void OnTriggerEnter(Collider other)
    {
        // Confirmar que se ha detectado una colisión
        Debug.Log($"Colisión detectada con: {other.name}");

        // Crear una copia de la moneda cuando algo interactúe con ella
        if (coinPrefab != null && spawnPoint != null)
        {
            Debug.Log("Generando copia de la moneda...");
            GameObject coinCopy = Instantiate(coinPrefab, spawnPoint.position, spawnPoint.rotation);

            // Activar físicas en la moneda duplicada
            var coinRigidbody = coinCopy.GetComponent<Rigidbody>();
            if (coinRigidbody != null)
            {
                coinRigidbody.isKinematic = false; // Habilitar físicas
                Debug.Log("Físicas activadas para la copia.");
            }

            // Opcional: Desactivar el collider del original después de la interacción
            if (originalCollider != null)
            {
                originalCollider.enabled = false;
                Debug.Log("El collider de la moneda original ha sido desactivado.");
            }
        }
        else
        {
            Debug.LogError("Prefab o Spawn Point no están configurados correctamente.");
        }
    }
}