using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    public TMP_Dropdown dropdownMenu; // Referencia al Dropdown
    public TMP_InputField inputField; // Referencia al InputField

    private void Start()
    {
        // Configurar valores iniciales
        if (dropdownMenu != null)
        {
            Debug.Log($"Dropdown inicial: {dropdownMenu.options[dropdownMenu.value].text}");
            OnDropdownChanged(dropdownMenu.value);
        }

        if (inputField != null)
        {
            Debug.Log($"InputField inicial: {inputField.text}");
            OnInputChanged(inputField.text);
        }
    }

public void OnDropdownChanged(int index)
{
    if (dropdownMenu != null && index >= 0 && index < dropdownMenu.options.Count)
    {
        string operacion = dropdownMenu.options[index].text;
        Debug.Log($"Dropdown seleccionado: {operacion}");
        MenuManager.Instance.SetOperacion(operacion);
    }
    else
    {
        Debug.LogWarning("Dropdown index fuera de rango o dropdown no configurado.");
    }
}

public void OnInputChanged(string valor)
{
    if (!string.IsNullOrEmpty(valor))
    {
        Debug.Log($"Valor ingresado en InputField: {valor}");
        MenuManager.Instance.SetValorOperacion(valor);
    }
    else
    {
        Debug.LogWarning("El InputField está vacío o no tiene un valor válido.");
    }
}
}