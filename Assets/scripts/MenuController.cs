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
    if (dropdownMenu != null)
    {
        string operacion = dropdownMenu.options[index].text;
        Debug.Log($"OnDropdownChanged llamado. Operación seleccionada: {operacion}");
        MenuManager.Instance.SetOperacion(operacion);
    }
    else
    {
        Debug.LogError("Dropdown no está configurado.");
    }
}

public void OnInputChanged(string valor)
{
    if (!string.IsNullOrEmpty(valor))
    {
        Debug.Log($"OnInputChanged llamado. Valor ingresado: {valor}");
        MenuManager.Instance.SetValorOperacion(valor);
    }
    else
    {
        Debug.LogWarning("El InputField está vacío.");
    }
}
}