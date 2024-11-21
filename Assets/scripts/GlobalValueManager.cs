using UnityEngine;

public class GlobalValueManager : MonoBehaviour
{
    public static GlobalValueManager Instance;

    private float currentValue = 1f; // Valor inicial global

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Asegura que este objeto persista entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para obtener el valor actual
    public float GetCurrentValue()
    {
        return currentValue;
    }

    // Método para actualizar el valor global
    public void UpdateValue(float newValue)
    {
        currentValue = newValue;
        Debug.Log($"El valor global se ha actualizado a: {currentValue}");
    }
}