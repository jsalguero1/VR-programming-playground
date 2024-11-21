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
    operacionSeleccionada = operacion;
    Debug.Log($"Operación seleccionada: {operacionSeleccionada}");
}

public void SetValorOperacion(string valor)
{
    if (float.TryParse(valor, out float resultado))
    {
        valorOperacion = resultado;
        Debug.Log($"Valor de la operación: {valorOperacion}");
    }
    else
    {
        Debug.LogWarning("El valor ingresado no es válido.");
    }
}
}