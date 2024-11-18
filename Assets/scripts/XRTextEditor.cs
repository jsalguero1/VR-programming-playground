using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class XRTextEditor : MonoBehaviour
{
    public XRRayInteractor rayInteractor; // Referencia al XR Ray Interactor
    public LayerMask coinLayer; // Capa de las monedas para filtrar

    private TMP_Text selectedTextMesh;

    void Update()
    {
        // Detecta si el rayo está interactuando con un objeto válido
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            // Comprueba si el objeto pertenece a la capa de monedas
            if (((1 << hit.collider.gameObject.layer) & coinLayer) != 0)
            {
                // Busca el hijo llamado "Valor" dentro del objeto golpeado
                Transform valorChild = hit.collider.transform.Find("Valor");
                if (valorChild != null)
                {
                    selectedTextMesh = valorChild.GetComponent<TMP_Text>();
                }

                // Detecta si se presiona el botón A
                if (selectedTextMesh != null && Input.GetButtonDown("XRI_Right_A")) // Ajusta la entrada si es necesario
                {
                    EditCoinText();
                }
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