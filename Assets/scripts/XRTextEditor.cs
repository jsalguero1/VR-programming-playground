using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class XRTextEditorNoLayers : MonoBehaviour
{
    public XRRayInteractor rayInteractor; // Referencia al XR Ray Interactor
    public float interactionDistance = 5f; // Distancia máxima para interactuar con las monedas

    private TMP_Text selectedTextMesh;

    void Update()
    {
        // Detecta si el rayo está interactuando con un objeto válido
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            // Comprueba si el objeto golpeado es una moneda buscando el hijo "Valor"
            Transform valorChild = hitObject.transform.Find("Valor");
            if (valorChild != null)
            {
                selectedTextMesh = valorChild.GetComponent<TMP_Text>();
            }
            else
            {
                selectedTextMesh = null; // Reinicia si no es una moneda válida
            }

            // Detecta si se presiona el botón A
            if (selectedTextMesh != null && Input.GetButtonDown("XRI_Right_A")) // Ajusta la entrada si es necesario
            {
                EditCoinText();
            }
        }
        else
        {
            selectedTextMesh = null; // Reinicia si no se apunta a ninguna moneda
        }
    }

    private void EditCoinText()
    {
        if (selectedTextMesh != null)
        {
            int currentValue = int.Parse(selectedTextMesh.text);
            currentValue++; // Incrementa el valor
            selectedTextMesh.text = currentValue.ToString();
        }
    }
}