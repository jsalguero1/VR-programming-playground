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
            targetInputField.text += number;
        }
    }

    // Método para borrar el último carácter del InputField
    public void Backspace()
    {
        if (targetInputField != null && targetInputField.text.Length > 0)
        {
            targetInputField.text = targetInputField.text.Substring(0, targetInputField.text.Length - 1);
        }
    }
}
