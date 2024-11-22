using UnityEngine;
using TMPro;

public class VirtualCharacterKeyboard : MonoBehaviour
{
    // Referencia al TMP_InputField
    public TMP_InputField targetInputField;

    private void Start()
    {
        if (targetInputField != null)
        {
            // Suscribir el evento onValueChanged
            targetInputField.onValueChanged.AddListener(OnInputFieldValueChanged);
        }
    }

    // Método para agregar un carácter al InputField
    public void AddCharacter(string character)
    {
        if (targetInputField != null && character.Length == 1)
        {
            // Restringir a un solo carácter
            targetInputField.text = character;
            targetInputField.ForceLabelUpdate(); // Actualizar visualmente el texto
        }
        else
        {
            Debug.LogWarning("Solo se permite un carácter.");
        }
    }

    // Método para eliminar el carácter del InputField
    public void Backspace()
    {
        if (targetInputField != null && targetInputField.text.Length > 0)
        {
            targetInputField.text = ""; // Eliminar el único carácter
            targetInputField.ForceLabelUpdate(); // Actualizar visualmente el texto
        }
    }

    // Método para agregar un espacio vacío
    public void AddSpace()
    {
        if (targetInputField != null)
        {
            targetInputField.text = " "; // Establecer un espacio vacío
            targetInputField.ForceLabelUpdate(); // Actualizar visualmente el texto
        }
    }

    // Callback para el evento onValueChanged
    private void OnInputFieldValueChanged(string updatedText)
    {
        Debug.Log($"Valor del InputField actualizado: '{updatedText}'");
    }

    private void OnDestroy()
    {
        if (targetInputField != null)
        {
            // Cancelar la suscripción al evento onValueChanged
            targetInputField.onValueChanged.RemoveListener(OnInputFieldValueChanged);
        }
    }
}