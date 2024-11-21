using UnityEngine;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    // Referencia al campo de texto (InputField)
    public TMP_InputField inputField;

    // Referencia al Dropdown
    public TMP_Dropdown dropdown;

    // Método que se ejecuta al presionar el botón
    public void OnButtonPress()
    {
        // Enviar el valor del InputField al GlobalValueManager
        if (inputField != null)
        {
            string inputValue = inputField.text;
            if (GlobalValueManager.Instance != null)
            {
                GlobalValueManager.Instance.UpdateInputFieldValue(inputValue);
                Debug.Log($"Valor del InputField enviado al GlobalValueManager: {inputValue}");
            }
        }

        // Enviar el valor del Dropdown al GlobalValueManager
        if (dropdown != null)
        {
            string dropdownValue = dropdown.options[dropdown.value].text;
            if (GlobalValueManager.Instance != null)
            {
                GlobalValueManager.Instance.UpdateDropdownValue(dropdownValue);
                Debug.Log($"Valor del Dropdown enviado al GlobalValueManager: {dropdownValue}");
            }
        }
    }
}