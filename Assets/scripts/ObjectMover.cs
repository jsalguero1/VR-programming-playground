using UnityEngine;
using TMPro;

public class ObjectMover : MonoBehaviour
{
    private Transform endPoint; // Punto final hacia donde moverse
    private Collider endPointCollider; // Referencia al Collider del EndPoint
    private bool isMoving = false; // Controla el estado del movimiento
    public float speed = 0.2f; // Velocidad del movimiento
    public float deactivateTime = 2.0f; // Tiempo que el Collider estará desactivado

    void Update()
    {
        if (isMoving)
        {
            // Mover hacia el punto final
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);

            // Detener el movimiento al llegar al punto final
            if (transform.position == endPoint.position)
            {
                isMoving = false;
                Debug.Log($"{name} ha llegado al EndPoint.");
                StartCoroutine(DeactivateEndPointColliderTemporarily());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar si el objeto entra en contacto con un StartPoint
        if (other.CompareTag("StartPoint"))
        {
            TrackController trackController = other.GetComponentInParent<TrackController>();
            if (trackController != null)
            {
                Debug.Log($"{name} detectó el StartPoint de {trackController.name}");
                endPoint = trackController.GetEndPoint();
                endPointCollider = endPoint.GetComponent<Collider>(); // Obtener el Collider del EndPoint
                isMoving = true;

                // Verificar si la pista es condicional
                TrackValues trackValues = trackController.GetComponent<TrackValues>();
                if (trackValues != null)
                {
                    // Validar si los valores están configurados
                    (string valorValue, string charValue) = trackValues.GetRegisteredValues();
                    if (string.IsNullOrEmpty(valorValue) || string.IsNullOrEmpty(charValue))
                    {
                        Debug.LogWarning($"Valores incompletos en la pista condicional {trackController.name}. Comparación omitida.");
                        return;
                    }

                    // Validar que el operador lógico sea válido
                    if (!IsValidOperator(charValue))
                    {
                        Debug.LogError($"Operador lógico inválido en la pista condicional: {charValue}. Comparación omitida.");
                        return;
                    }

                    // Obtener el valor dinámico del TMP en la moneda
                    TMP_Text coinTMP = GetComponentInChildren<TMP_Text>();
                    if (coinTMP != null)
                    {
                        string coinValue = coinTMP.text;

                        // Validar que el valor de la moneda sea un número
                        if (!float.TryParse(coinValue, out _))
                        {
                            Debug.LogError($"El valor de la moneda '{coinValue}' no es un número válido. Comparación omitida.");
                            return;
                        }

                        // Evaluar la condición lógica
                        bool conditionMet = trackValues.EvaluateComparison(coinValue);
                        Debug.Log($"Resultado de la comparación: {conditionMet}");

                        // Cambiar el color de la pista basado en el resultado
                        Renderer trackRenderer = trackController.GetComponent<Renderer>();
                        if (trackRenderer != null)
                        {
                            trackRenderer.material.color = conditionMet ? Color.green : Color.red;
                        }
                        else
                        {
                            Debug.LogError("El TrackController no tiene un Renderer asignado.");
                        }
                    }
                    else
                    {
                        Debug.LogError("No se encontró un TMP_Text en la moneda.");
                    }
                }
            }
        }
    }

    private System.Collections.IEnumerator DeactivateEndPointColliderTemporarily()
    {
        if (endPointCollider != null)
        {
            Debug.Log($"Desactivando el Collider del EndPoint: {endPoint.name}");
            endPointCollider.enabled = false; // Desactiva el Collider
            yield return new WaitForSeconds(deactivateTime); // Espera el tiempo especificado
            endPointCollider.enabled = true; // Reactiva el Collider
            Debug.Log($"Collider del EndPoint {endPoint.name} reactivado.");
        }
    }

    // Método para validar el operador lógico
    private bool IsValidOperator(string op)
    {
        string[] validOperators = { "<", ">", "≤", "≥", "=" };
        return System.Array.Exists(validOperators, validOp => validOp == op);
    }
}
