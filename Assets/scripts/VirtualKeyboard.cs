using UnityEngine;
using TMPro;

public class VirtualKeyboard : MonoBehaviour
{
    // Referencia al campo InputField objetivo
    public TMP_InputField targetInputField;

    // Método para agregar un número al InputField
    public void AddNumber(string number)
    {
        if (targetInputField != null)
        {
            // Agregar el número al texto del InputField
            targetInputField.text += number;

            // Forzar el disparo del evento On Value Changed
            targetInputField.onValueChanged?.Invoke(targetInputField.text);
        }
    }

    // Método para borrar el último carácter del InputField
    public void Backspace()
    {
        if (targetInputField != null && targetInputField.text.Length > 0)
        {
            // Borrar el último carácter del texto
            targetInputField.text = targetInputField.text.Substring(0, targetInputField.text.Length - 1);

            // Forzar el disparo del evento On Value Changed
            targetInputField.onValueChanged?.Invoke(targetInputField.text);
        }
    }

    // Método para borrar todo el texto del InputField
    public void ClearText()
    {
        if (targetInputField != null)
        {
            // Limpiar todo el texto
            targetInputField.text = string.Empty;

            // Forzar el disparo del evento On Value Changed
            targetInputField.onValueChanged?.Invoke(targetInputField.text);
        }
    }
}