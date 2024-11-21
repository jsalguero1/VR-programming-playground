using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance; // Singleton para acceso global

    public string operacionSeleccionada = "Sumar"; // Operación inicial
    public float valorOperacion = 1f; // Valor inicial

    private void Awake()
    {
        // Configuración del Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetOperacion(string operacion)
    {
        operacionSeleccionada = operacion; // Actualiza la operación seleccionada
    }

    public void SetValorOperacion(string valor)
    {
        if (float.TryParse(valor, out float resultado))
        {
            valorOperacion = resultado; // Convierte el texto en un número
        }
        else
        {
            Debug.LogWarning("El valor ingresado no es válido.");
        }
    }
}