using UnityEngine;
using TMPro;

public class CharValidator : MonoBehaviour
{
    private TrackValues trackValues;
    [SerializeField] private string defaultOperator = "="; // Operador lógico predeterminado

    private void Start()
    {
        // Obtener referencia al TrackValues en el padre
        trackValues = GetComponentInParent<TrackValues>();

        // Configurar el valor inicial del TMP
        TextMeshProUGUI tmp = GetComponentInChildren<TextMeshProUGUI>();
        if (tmp != null && string.IsNullOrEmpty(tmp.text))
        {
            tmp.text = defaultOperator; // Asignar el operador predeterminado
            Debug.Log($"Operador lógico predeterminado asignado: {defaultOperator}");
            trackValues?.UpdateCharValue(defaultOperator); // Actualizar el TrackValues
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Char"))
        {
            Transform canvasTransform = other.transform.Find("Canvas");
            if (canvasTransform != null)
            {
                TextMeshProUGUI tmp = canvasTransform.GetComponentInChildren<TextMeshProUGUI>();
                if (tmp != null)
                {
                    string text = tmp.text;

                    // Validar si el texto es un operador lógico válido
                    if (IsValidOperator(text))
                    {
                        Debug.Log($"Texto válido encontrado en Char: {text}");
                        trackValues?.UpdateCharValue(text); // Actualizar TrackValues
                    }
                    else
                    {
                        Debug.LogError($"Operador lógico inválido detectado: {text}. No se registrará en TrackValues.");
                    }
                }
            }
        }
    }

    // Validar si el operador lógico es válido
    private bool IsValidOperator(string op)
    {
        string[] validSymbols = { "<", ">", "≤", "≥", "=" };
        return System.Array.Exists(validSymbols, symbol => symbol == op);
    }
}
