using UnityEngine;
using TMPro; // Usar esto si es un TMP_Dropdown

public class DropdownHandler : MonoBehaviour
{
    public TMP_Dropdown dropdown; // Referencia al Dropdown (o Dropdown normal si no usas TMP)

    private void Start()
    {
        if (dropdown != null)
        {
            // Suscribimos el método al evento onValueChanged
            dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        }
        else
        {
            Debug.LogError("No se asignó un Dropdown al script.");
        }
    }

    private void OnDropdownValueChanged(int valueIndex)
    {
        // Imprimimos la opción seleccionada
        string selectedOption = dropdown.options[valueIndex].text;
        Debug.Log($"Opción seleccionada: {selectedOption}");
    }

    private void OnDestroy()
    {
        if (dropdown != null)
        {
            // Removemos el listener al destruir el objeto para evitar problemas
            dropdown.onValueChanged.RemoveListener(OnDropdownValueChanged);
        }
    }
}