using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class CoinInteraction : MonoBehaviour
{
    private TMP_Text valueText; // Referencia al componente TextMeshPro
    private XRBaseInteractor currentInteractor; // Para almacenar el interactor que la está seleccionando

    void Start()
    {
        // Busca el componente TextMeshPro en el hijo "Valor"
        Transform valorChild = transform.Find("Valor");
        if (valorChild != null)
        {
            valueText = valorChild.GetComponent<TMP_Text>();
        }
    }

    public void OnSelectEnter(XRBaseInteractor interactor)
    {
        currentInteractor = interactor; // Guarda el interactor que seleccionó esta moneda
    }

    public void OnSelectExit(XRBaseInteractor interactor)
    {
        if (currentInteractor == interactor)
        {
            currentInteractor = null; // Limpia el interactor al deseleccionar
        }
    }

    void Update()
    {
        // Detecta si se presiona el botón A mientras está seleccionada
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