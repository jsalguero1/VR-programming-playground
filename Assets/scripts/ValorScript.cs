using UnityEngine;
using TMPro;

public class Valor : MonoBehaviour
{
    private TrackValues trackValues;

    private void Start()
    {
        // Obtén la referencia al padre
        trackValues = GetComponentInParent<TrackValues>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Transform canvasTransform = other.transform.Find("Canvas");
            if (canvasTransform != null)
            {
                TextMeshProUGUI tmp = canvasTransform.GetComponentInChildren<TextMeshProUGUI>();
                if (tmp != null)
                {
                    string text = tmp.text;
                    Debug.Log($"Texto encontrado en Coin: {text}");
                    trackValues?.UpdateValorValue(text); // Informa al padre
                }
            }
        }
    }
}

