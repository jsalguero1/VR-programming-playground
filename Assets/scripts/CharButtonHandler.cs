using UnityEngine;
using TMPro;

public class CharButtonHandler : MonoBehaviour
{
    // Referencia al campo de texto (InputField)
    public TMP_InputField inputField;

    // Método que se ejecuta al presionar el botón
    public void OnButtonPress()
    {
        // Enviar el valor del InputField al GlobalValueManager
        if (inputField != null)
        {
            string inputValue = inputField.text;
            if (GlobalValueManager.Instance != null)
            {
                GlobalValueManager.Instance.UpdateInputFieldCharValue(inputValue);
                Debug.Log($"Valor del InputField enviado al GlobalValueManager: {inputValue}");
            }
        }
    }
}