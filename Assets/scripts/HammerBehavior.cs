using UnityEngine;

public class HammerBehavior : MonoBehaviour
{
    [SerializeField] private Renderer hammerRenderer; // Asigna el Renderer del martillo en el Inspector
    [SerializeField] private Color sumarColor;
    [SerializeField] private Color restarColor;
    [SerializeField] private Color dividirColor;
    [SerializeField] private Color multiplicarColor;
    [SerializeField] private Color defaultColor;

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionamos tiene el tag "Coin"
        if (collision.gameObject.CompareTag("Coin"))
        {
            // Obtenemos el script CoinBehavior de la moneda
            CoinBehavior moneda = collision.gameObject.GetComponent<CoinBehavior>();
            if (moneda != null)
            {
                // Obtenemos el valor actual del InputField desde el GlobalValueManager
                if (GlobalValueManager.Instance != null)
                {
                    string inputFieldStr = GlobalValueManager.Instance.GetInputFieldValue();
                    if (float.TryParse(inputFieldStr, out float valorGlobal))
                    {
                        string operation = GlobalValueManager.Instance.GetDropdownValue();

                        // Realizar la operación correspondiente
                        switch (operation)
                        {
                            case "Sumar":
                                moneda.ActualizarValor(moneda.valorActual + valorGlobal);
                                Debug.Log($"Sumando {valorGlobal} a la moneda.");
                                CambiarColorDelMaterial(sumarColor);
                                break;

                            case "Restar":
                                moneda.ActualizarValor(moneda.valorActual - valorGlobal);
                                Debug.Log($"Restando {valorGlobal} de la moneda.");
                                CambiarColorDelMaterial(restarColor);
                                break;

                            case "Dividir":
                                if (valorGlobal != 0)
                                {
                                    moneda.ActualizarValor(moneda.valorActual / valorGlobal);
                                    Debug.Log($"Dividiendo la moneda por {valorGlobal}.");
                                    CambiarColorDelMaterial(dividirColor);
                                }
                                else
                                {
                                    Debug.LogError("No se puede dividir por 0.");
                                    CambiarColorDelMaterial(defaultColor);
                                }
                                break;

                            case "Multiplicar":
                                moneda.ActualizarValor(moneda.valorActual * valorGlobal);
                                Debug.Log($"Multiplicando la moneda por {valorGlobal}.");
                                CambiarColorDelMaterial(multiplicarColor);
                                break;

                            default:
                                Debug.LogError($"Operación no reconocida: {operation}");
                                CambiarColorDelMaterial(defaultColor);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError($"El valor del InputField '{inputFieldStr}' no se pudo convertir a float.");
                        CambiarColorDelMaterial(defaultColor);
                    }
                }
                else
                {
                    Debug.LogError("GlobalValueManager no está inicializado.");
                }
            }
            else
            {
                Debug.LogError("No se encontró el componente CoinBehavior en la moneda.");
            }
        }
    }

    private void CambiarColorDelMaterial(Color nuevoColor)
    {
        if (hammerRenderer != null)
        {
            // Cambiar el color del primer material del array (por ejemplo)
            Material[] materials = hammerRenderer.materials;
            if (materials.Length > 0)
            {
                materials[2].color = nuevoColor; // Cambia el color del material
                hammerRenderer.materials = materials; // Aplica los cambios al Renderer
            }
            else
            {
                Debug.LogError("No se encontraron materiales en el Renderer.");
            }
        }
        else
        {
            Debug.LogError("El Renderer del martillo no está asignado.");
        }
    }
}
