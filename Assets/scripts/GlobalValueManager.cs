using UnityEngine;

public class GlobalValueManager : MonoBehaviour
{
    // Singleton Instance
    public static GlobalValueManager Instance;

    // Variables para almacenar los valores actuales
    private string inputFieldValue = "1"; // Valor inicial por defecto
    private string dropdownValue = "Sumar"; // Operación inicial por defecto
    private string inputFieldCharValue;

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

    public string GetInputFieldCharValue()
    {
        return inputFieldCharValue;
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

    public void UpdateInputFieldCharValue(string newValue)
    {
        inputFieldCharValue = newValue;
        Debug.Log($"El valor del InputField de un solo carácter se actualizó a: {inputFieldCharValue}");
    }
}
