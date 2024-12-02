using UnityEngine;
using TMPro;

public class CharValidator : MonoBehaviour
{
    private TrackValues trackValues;

    private void Start()
    {
        // Obtén la referencia al padre
        trackValues = GetComponentInParent<TrackValues>();
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
                    if (IsValidText(text))
                    {
                        Debug.Log($"Texto válido encontrado en Char: {text}");
                        trackValues?.UpdateCharValue(text); // Informa al padre
                    }
                }
            }
        }
    }

    private bool IsValidText(string text)
    {
        char[] validSymbols = { '<', '>', '≤', '≥', '=' };
        foreach (char c in text)
        {
            if (System.Array.IndexOf(validSymbols, c) == -1)
            {
                return false;
            }
        }
        return true;
    }
}
