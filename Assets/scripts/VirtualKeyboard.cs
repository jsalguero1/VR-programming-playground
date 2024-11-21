using UnityEngine;
using TMPro;

public class VirtualKeyboard : MonoBehaviour
{
    // Reference to the target TMP_InputField
    public TMP_InputField targetInputField;

    private void Start()
    {
        if (targetInputField != null)
        {
            // Subscribe to the onValueChanged event
            targetInputField.onValueChanged.AddListener(OnInputFieldValueChanged);
        }
    }

    // Method to add a number to the InputField
    public void AddNumber(string number)
    {
        if (targetInputField != null)
        {
            targetInputField.text += number;
            targetInputField.ForceLabelUpdate(); // Ensure the text update is visible
        }
    }

    // Method to remove the last character from the InputField
    public void Backspace()
    {
        if (targetInputField != null && targetInputField.text.Length > 0)
        {
            targetInputField.text = targetInputField.text.Substring(0, targetInputField.text.Length - 1);
            targetInputField.ForceLabelUpdate(); // Ensure the text update is visible
        }
    }

    // Callback for the onValueChanged event
    private void OnInputFieldValueChanged(string updatedText)
    {
        Debug.Log($"InputField value updated: {updatedText}");
    }

    private void OnDestroy()
    {
        if (targetInputField != null)
        {
            // Unsubscribe from the onValueChanged event
            targetInputField.onValueChanged.RemoveListener(OnInputFieldValueChanged);
        }
    }
}