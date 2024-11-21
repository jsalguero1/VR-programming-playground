using UnityEngine;

public class HammerBehavior : MonoBehaviour
{
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
                                break;

                            case "Restar":
                                moneda.ActualizarValor(moneda.valorActual - valorGlobal);
                                Debug.Log($"Restando {valorGlobal} de la moneda.");
                                break;

                            case "Dividir":
                                if (valorGlobal != 0)
                                {
                                    moneda.ActualizarValor(moneda.valorActual / valorGlobal);
                                    Debug.Log($"Dividiendo la moneda por {valorGlobal}.");
                                }
                                else
                                {
                                    Debug.LogError("No se puede dividir por 0.");
                                }
                                break;

                            case "Multiplicar":
                                moneda.ActualizarValor(moneda.valorActual * valorGlobal);
                                Debug.Log($"Multiplicando la moneda por {valorGlobal}.");
                                break;

                            default:
                                Debug.LogError($"Operación no reconocida: {operation}");
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError($"El valor del InputField '{inputFieldStr}' no se pudo convertir a float.");
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
}