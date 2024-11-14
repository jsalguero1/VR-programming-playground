using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab de la moneda que se instanciará al intentar agarrar
    public Transform spawnPoint; // Posición donde aparecerá la moneda copiada
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        // Obtén el componente XR Grab Interactable en la moneda generadora
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            Debug.LogError("El componente XR Grab Interactable no está presente en la moneda generadora.");
            return;
        }

        // Asocia el evento para que llame a OnGrabAttempt al intentar agarrar
        grabInteractable.selectEntered.AddListener(OnGrabAttempt);
    }

    private void OnGrabAttempt(SelectEnterEventArgs args)
    {
        // Crea una copia de la moneda en la posición del spawn point
        GameObject newCoin = Instantiate(coinPrefab, spawnPoint.position, spawnPoint.rotation);

        // Activa la física en la moneda copiada para que pueda ser interactuable
        Rigidbody rb = newCoin.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false; // Habilita la física en la copia
            rb.useGravity = true;
        }

        // Configura el nuevo objeto como interactuable en VR
        XRGrabInteractable newGrabInteractable = newCoin.GetComponent<XRGrabInteractable>();
        if (newGrabInteractable != null)
        {
            // Puedes personalizar el comportamiento del nuevo XRGrabInteractable aquí si es necesario
        }
    }
}