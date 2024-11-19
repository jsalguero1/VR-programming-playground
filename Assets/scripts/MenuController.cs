using UnityEngine;
using TMPro; // Necesario para usar TMP_Dropdown y TMP_InputField

public class MenuController : MonoBehaviour
{
    // Referencia al Dropdown (para seleccionar la operación)
    public TMP_Dropdown dropdownMenu;

    // Referencia al InputField (para ingresar el valor)
    public TMP_InputField inputField;

    private void Start()
    {
        // Inicializa los valores desde el estado inicial del Dropdown y el InputField
        if (dropdownMenu != null)
        {
            int index = dropdownMenu.value; // Obtiene la opción inicial seleccionada
            OnDropdownChanged(index); // Actualiza el MenuManager
        }

        if (inputField != null)
        {
            string valor = inputField.text; // Obtiene el valor inicial del InputField
            OnInputChanged(valor); // Actualiza el MenuManager
        }
    }

    // Método llamado cuando se cambia la opción del Dropdown
    public void OnDropdownChanged(int index)
    {
        // Obtiene el texto de la opción seleccionada en el Dropdown
        string operacionSeleccionada = dropdownMenu.options[index].text;

        // Actualiza la operación en el MenuManager
        MenuManager.Instance.SetOperacion(operacionSeleccionada);
    }

    // Método llamado cuando se cambia el texto en el InputField
    public void OnInputChanged(string valor)
    {
        // Actualiza el valor numérico en el MenuManager
        MenuManager.Instance.SetValorOperacion(valor);
    }
}