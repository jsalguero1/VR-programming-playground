using UnityEngine;

public class GlobalValueManager : MonoBehaviour
{
    // Singleton Instance
    public static GlobalValueManager Instance;

    // Variables para almacenar los valores actuales
    private string inputFieldValue;
    private string dropdownValue;

    private void Awake()
    {
        // Implementar Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Asegura que no se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Métodos para obtener valores individuales
    public string GetInputFieldValue()
    {
        return inputFieldValue;
    }

    public string GetDropdownValue()
    {
        return dropdownValue;
    }

    // Métodos para actualizar valores individuales
    public void UpdateInputFieldValue(string newValue)
    {
        inputFieldValue = newValue;
        Debug.Log($"El valor del InputField se actualizó a: {inputFieldValue}");
    }

    public void UpdateDropdownValue(string newValue)
    {
        dropdownValue = newValue;
        Debug.Log($"El valor del Dropdown se actualizó a: {dropdownValue}");
    }
}