using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CoinDuplicator : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab; // Prefab de la moneda (debe incluir XRGrabInteractable y Rigidbody)
    [SerializeField] private Transform spawnPoint;  // Punto donde se creará la moneda duplicada

    private void OnEnable()
    {
        // Asegúrate de que el XRGrabInteractable original esté deshabilitado
        var grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabAttempt);
        }
    }

    private void OnDisable()
    {
        var grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabAttempt);
        }
    }

    private void OnGrabAttempt(SelectEnterEventArgs args)
    {
        // Generar una copia de la moneda
        GameObject coinCopy = Instantiate(coinPrefab, spawnPoint.position, spawnPoint.rotation);

        // Activar físicas para la copia
        var coinRigidbody = coinCopy.GetComponent<Rigidbody>();
        if (coinRigidbody != null)
        {
            coinRigidbody.isKinematic = false; // Habilitar físicas
        }

        // Hacer que la copia sea agarrable
        var grabInteractable = coinCopy.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            // Forzar que el jugador agarre la nueva moneda
            var interactor = args.interactorObject;
            grabInteractable.interactionManager.SelectEnter(interactor, grabInteractable);
        }
    }
}
