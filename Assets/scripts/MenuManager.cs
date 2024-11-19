using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Instancia Singleton para acceso global
    public static MenuManager Instance;

    // Almacena el valor ingresado en el InputField
    public float valorOperacion = 0f;

    // Almacena la operación seleccionada en el Dropdown
    public string operacionSeleccionada = "Sumar";

    private void Awake()
    {
        // Implementación del Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Opcional, si deseas que persista entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para actualizar el valor ingresado desde el InputField
    public void SetValorOperacion(string valor)
    {
        if (float.TryParse(valor, out float resultado))
        {
            valorOperacion = resultado; // Convierte el texto a un número
        }
        else
        {
            Debug.LogWarning("El valor ingresado no es válido.");
        }
    }

    // Método para actualizar la operación seleccionada desde el Dropdown
    public void SetOperacion(string operacion)
    {
        operacionSeleccionada = operacion; // Guarda la operación seleccionada
    }
}