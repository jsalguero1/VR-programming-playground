using UnityEngine;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    // Referencia al campo de texto (InputField)
    public TMP_InputField inputField;

    // Método que se ejecuta al presionar el botón
    public void OnButtonPress()
    {
        if (inputField != null)
        {
            string valueToSend = inputField.text;

            // Enviar el valor al GlobalValueManager
            if (GlobalValueManager.Instance != null)
            {
                GlobalValueManager.Instance.UpdateValue(valueToSend);
            }
        }
    }
}