using UnityEngine;
using TMPro;

public class ConditionalTrack : MonoBehaviour
{
    public GameObject comparar; // Objeto donde se almacena el número.
    public GameObject condicional; // Objeto donde se almacena el operador lógico.
    public Material successMaterial; // Material verde.
    public Material failureMaterial; // Material rojo.
    public Renderer trackRenderer; // Renderer de la pista para cambiar el material.

    private float comparisonValue; // Valor a comparar.
    private string comparisonOperator; // Operador lógico.

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto es una moneda y se asigna un valor al "Comparar".
        if (other.CompareTag("Coin"))
        {
            CoinBehavior coinBehavior = other.GetComponent<CoinBehavior>();
            if (coinBehavior != null)
            {
                // Lee el valor actual de la moneda y lo asigna al TMP del "Comparar".
                comparisonValue = coinBehavior.valorActual;
                comparar.GetComponent<TextMeshProUGUI>().text = comparisonValue.ToString("F2");
                Debug.Log($"[Comparar] Valor leído de la moneda: {comparisonValue}");
            }
        }

        // Verifica si el objeto es un carácter y se asigna un operador al "Condicional".
        if (other.CompareTag("Char"))
        {
            TextMeshProUGUI charTMP = other.GetComponentInChildren<TextMeshProUGUI>();
            if (charTMP != null)
            {
                // Lee el operador lógico desde el objeto y lo asigna al TMP del "Condicional".
                comparisonOperator = charTMP.text;
                condicional.GetComponent<TextMeshProUGUI>().text = comparisonOperator;
                Debug.Log($"[Condicional] Operador leído del carácter: {comparisonOperator}");
            }
        }

        // Si la moneda activa la pista después de configurar el valor y el operador.
        if (other.CompareTag("Coin"))
        {
            EvaluateAndSetMaterial(other.GetComponent<CoinBehavior>());
        }
    }

    private void EvaluateAndSetMaterial(CoinBehavior coinBehavior)
    {
        if (coinBehavior != null)
        {
            float coinValue = coinBehavior.valorActual;
            Debug.Log($"[Evaluación] Evaluando condición: {coinValue} {comparisonOperator} {comparisonValue}");

            bool conditionMet = EvaluateCondition(coinValue);
            Debug.Log($"[Evaluación] Resultado de la condición: {conditionMet}");

            UpdateTrackMaterial(conditionMet);
        }
    }

    private bool EvaluateCondition(float coinValue)
    {
        // Evaluar la condición basada en el operador lógico.
        switch (comparisonOperator)
        {
            case "<":
                return coinValue < comparisonValue;
            case ">":
                return coinValue > comparisonValue;
            case "==":
                return Mathf.Approximately(coinValue, comparisonValue);
            case "<=":
                return coinValue <= comparisonValue;
            case ">=":
                return coinValue >= comparisonValue;
            default:
                Debug.LogError($"[Error] Operador no válido: {comparisonOperator}");
                return false;
        }
    }

    private void UpdateTrackMaterial(bool conditionMet)
    {
        // Cambiar el material de la pista basado en el resultado de la evaluación.
        trackRenderer.material = conditionMet ? successMaterial : failureMaterial;
        Debug.Log(conditionMet ? "[Pista] Condición cumplida: Material cambiado a verde." : "[Pista] Condición no cumplida: Material cambiado a rojo.");
    }
}