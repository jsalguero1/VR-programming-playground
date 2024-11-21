using UnityEngine;
using TMPro;

public class VirtualKeyboard : MonoBehaviour
{
    public TMP_InputField targetInputField; // Referencia al InputField
    public MenuManager menuManager; // Referencia directa al MenuManager

    // Método para agregar un número al InputField
    public void AddNumber(string number)
    {
        if (targetInputField != null)
        {
            // Agregar el número al texto
            targetInputField.text += number;

            // Reflejar el valor en el MenuManager
            UpdateMenuManager();
        }
    }

    // Método para borrar el último carácter del InputField
    public void Backspace()
    {
        if (targetInputField != null && targetInputField.text.Length > 0)
        {
            // Borrar el último carácter del texto
            targetInputField.text = targetInputField.text.Substring(0, targetInputField.text.Length - 1);

            // Reflejar el valor en el MenuManager
            UpdateMenuManager();
        }
    }

    // Método para borrar todo el texto del InputField
    public void ClearText()
    {
        if (targetInputField != null)
        {
            // Limpiar todo el texto
            targetInputField.text = string.Empty;

            // Reflejar el valor en el MenuManager
            UpdateMenuManager();
        }
    }

    // Actualiza el valor en el MenuManager directamente
    private void UpdateMenuManager()
    {
        if (menuManager != null)
        {
            // Convierte el texto del InputField a un número flotante
            if (float.TryParse(targetInputField.text, out float valor))
            {
                menuManager.valorOperacion = valor; // Actualiza el valor en el MenuManager
                Debug.Log($"Valor actualizado en el MenuManager: {valor}");
            }
            else
            {
                menuManager.valorOperacion = 0f; // Si el texto no es válido, establece un valor predeterminado
                Debug.LogWarning("El texto ingresado no es un número válido.");
            }
        }
    }
}