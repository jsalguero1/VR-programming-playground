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
            OnDropdownChanged(dropdownMenu.value);
        }

        if (inputField != null)
        {
            OnInputChanged(inputField.text);
        }
    }

    public void OnDropdownChanged(int index)
    {
        // Obtiene el texto de la opción seleccionada y actualiza el MenuManager
        string operacion = dropdownMenu.options[index].text;
        MenuManager.Instance.SetOperacion(operacion);
    }

    public void OnInputChanged(string valor)
    {
        // Actualiza el valor en el MenuManager
        MenuManager.Instance.SetValorOperacion(valor);
    }
}