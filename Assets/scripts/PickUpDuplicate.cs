using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab de la moneda a instanciar (la moneda interactuable)
    public Transform spawnPoint; // Posición en la que aparecerá la copia

    private void Start()
    {
        // Verificar que el prefab está asignado
        if (coinPrefab == null)
        {
            Debug.LogError("No se ha asignado un prefab de moneda.");
        }
    }

    // Este método se ejecutará cuando el jugador intente agarrar la moneda
    public void OnGrabAttempt()
    {
        // Instanciar una copia de la moneda interactuable en la posición indicada
        GameObject newCoin = Instantiate(coinPrefab, spawnPoint.position, spawnPoint.rotation);

        // Hacer la moneda manipulable activando su física
        Rigidbody rb = newCoin.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; // Activa el Rigidbody para que tenga física
            rb.useGravity = true; // Activa la gravedad, si se necesita
        }
    }
}