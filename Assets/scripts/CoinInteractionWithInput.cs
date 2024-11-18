using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class CoinInteractionWithInput : MonoBehaviour
{
    private TMP_Text valueText; // Referencia al TextMeshPro del hijo "Valor"
    private TMP_InputField inputField; // Referencia al InputField
    private bool isGrabbed = false; // Verifica si la moneda está siendo agarrada

    void Start()
    {
        // Busca el componente TextMeshPro en el hijo "Valor"
        Transform valorChild = transform.Find("Valor");
        if (valorChild != null)
        {
            valueText = valorChild.GetComponent<TMP_Text>();
        }
        else
        {
            Debug.LogError("No se encontró un hijo llamado 'Valor' con un componente TMP_Text.");
        }

        // Encuentra un InputField en la escena
        inputField = FindObjectOfType<TMP_InputField>();
        if (inputField == null)
        {
            Debug.LogError("No se encontró un TMP_InputField en la escena.");
        }
    }

    public void OnSelectEnter() // Evento al agarrar la moneda
    {
        isGrabbed = true; // Marca la moneda como agarrada
        if (inputField != null)
        {
            inputField.gameObject.SetActive(true); // Muestra el InputField
        }
    }

    public void OnSelectExit() // Evento al soltar la moneda
    {
        isGrabbed = false; // Marca la moneda como no agarrada
        if (inputField != null)
        {
            inputField.gameObject.SetActive(false); // Oculta el InputField
        }
    }

    void Update()
    {
        // Detecta si se presiona Enter para actualizar el valor
        if (isGrabbed && Input.GetKeyDown(KeyCode.Return) && inputField != null)
        {
            ApplyInputValue();
        }
    }

    private void ApplyInputValue()
    {
        if (valueText != null && inputField != null)
        {
            int newValue;
            // Intenta convertir el valor ingresado en el InputField a un número
            if (int.TryParse(inputField.text, out newValue))
            {
                valueText.text = newValue.ToString(); // Actualiza el texto con el nuevo valor
                Debug.Log("Nuevo valor aplicado: " + newValue);
            }
            else
            {
                Debug.LogError("El valor ingresado no es un número válido: " + inputField.text);
            }

            inputField.text = ""; // Limpia el InputField después de aplicar el valor
        }
    }
}