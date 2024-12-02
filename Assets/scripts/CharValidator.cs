using UnityEngine;
using TMPro;

public class CharValidator : MonoBehaviour
{
    private TrackValues trackValues;

    private void Start()
    {
        // Obtener referencia al TrackValues en el padre
        trackValues = GetComponentInParent<TrackValues>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Char"))
        {
            // Buscar el Canvas dentro del objeto detectado
            Transform canvasTransform = other.transform.Find("Canvas");
            if (canvasTransform != null)
            {
                // Obtener el TMP_Text del Canvas
                TextMeshProUGUI tmp = canvasTransform.GetComponentInChildren<TextMeshProUGUI>();
                if (tmp != null)
                {
                    string text = tmp.text;

                    // Validar si el texto está vacío o nulo
                    if (string.IsNullOrEmpty(text))
                    {
                        Debug.LogError("El texto detectado en el Char es nulo o vacío. No se registrará.");
                        return;
                    }

                    // Validar si el texto es un operador lógico válido
                    if (IsValidOperator(text))
                    {
                        Debug.Log($"Texto válido encontrado en Char: {text}");
                        trackValues?.UpdateCharValue(text); // Actualizar valor en TrackValues
                    }
                    else
                    {
                        Debug.Log($"Operador lógico inválido detectado: '{text}'. No se registrará en TrackValues.");
                    }
                }
                else
                {
                    Debug.LogError("No se encontró un componente TextMeshProUGUI en el Canvas del Char.");
                }
            }
            else
            {
                Debug.LogError("No se encontró un Canvas en el objeto Char.");
            }
        }
    }

    // Validar si el operador lógico es válido
    private bool IsValidOperator(string op)
    {
        // Lista de operadores válidos
        string[] validSymbols = { "<", ">", "≤", "≥", "=" };

        // Verificar si el operador pertenece a los válidos
        return System.Array.Exists(validSymbols, symbol => symbol == op);
    }
}
