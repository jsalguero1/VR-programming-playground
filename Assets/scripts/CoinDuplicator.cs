using UnityEngine;
using UnityEngine.InputSystem; // Necesario para el sistema de entrada

public class CoinDuplicator : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;  // Prefab de la moneda que se generará
    [SerializeField] private Transform spawnPoint;   // Punto donde aparecerá la copia

    private void Update()
    {
        // Verificar si el botón A en el controlador derecho ha sido presionado
        if (Gamepad.current != null && Gamepad.current.aButton.wasPressedThisFrame)
        {
            GenerateCoin();
        }
    }

    private void GenerateCoin()
    {
        if (coinPrefab != null && spawnPoint != null)
        {
            // Crear una copia de la moneda
            GameObject coinCopy = Instantiate(coinPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Moneda duplicada.");

            // Activar físicas en la copia
            var coinRigidbody = coinCopy.GetComponent<Rigidbody>();
            if (coinRigidbody != null)
            {
                coinRigidbody.isKinematic = false; // Habilitar físicas
            }
        }
        else
        {
            Debug.LogError("Prefab o Spawn Point no asignados en el Inspector.");
        }
    }
}