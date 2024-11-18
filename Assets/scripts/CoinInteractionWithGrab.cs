using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class CoinInteractionWithGrab : MonoBehaviour
{
    private TMP_Text valueText; // Referencia al TextMeshPro del hijo "Valor"
    private XRBaseInteractor currentInteractor; // Interactor que está agarrando esta moneda

    void Start()
    {
        // Busca el componente TextMeshPro en el hijo "Valor"
        Transform valorChild = transform.Find("Valor"); // Busca al hijo por su nombre
        if (valorChild != null)
        {
            valueText = valorChild.GetComponent<TMP_Text>();
        }
        else
        {
            Debug.LogError("No se encontró un hijo llamado 'Valor' con un componente TMP_Text en el prefab.");
        }
    }

    public void OnSelectEnter(XRBaseInteractor interactor)
    {
        currentInteractor = interactor; // Guarda el interactor que agarró la moneda
    }

    public void OnSelectExit(XRBaseInteractor interactor)
    {
        if (currentInteractor == interactor)
        {
            currentInteractor = null; // Limpia el interactor al soltar
        }
    }

    void Update()
    {
        // Detecta si el botón A se presiona mientras está agarrada
        if (currentInteractor != null && Input.GetButtonDown("XRI_Right_A"))
        {
            IncrementValue();
        }
    }

    private void IncrementValue()
    {
        if (valueText != null)
        {
            int currentValue = int.Parse(valueText.text);
            currentValue++; // Incrementa el valor
            valueText.text = currentValue.ToString();
        }
    }
}