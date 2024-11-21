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
        // Obtiene el texto de la opción seleccionada y actualiza el MenuManager
        string operacion = dropdownMenu.options[index].text;
        MenuManager.Instance.SetOperacion(operacion);
        Debug.Log($"Dropdown cambiado: {operacion}");
    }

    public void OnInputChanged(string valor)
    {
        // Actualiza el valor en el MenuManager
        MenuManager.Instance.SetValorOperacion(valor);
        Debug.Log($"InputField cambiado: {valor}");
    }
}