using UnityEngine;

public class GlobalValueManager : MonoBehaviour
{
    // Singleton Instance
    public static GlobalValueManager Instance;

    // Variable para almacenar el valor actual
    private string currentValue;

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

    public string GetCurrentValue()
    {
        return currentValue;
    }

    // Método para actualizar el valor y mostrarlo
    public void UpdateValue(string newValue)
    {
        currentValue = newValue;
        Debug.Log($"El valor actual es: {currentValue}");
    }
}