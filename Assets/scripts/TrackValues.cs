using UnityEngine;

public class TrackValues : MonoBehaviour
{
    private string valorValue; // Valor numérico almacenado
    private string charValue; // Operador de comparación almacenado

    // Método llamado por el hijo Valor
    public void UpdateValorValue(string value)
    {
        valorValue = value;
        Debug.Log($"TrackValues ({name}) - Valor actualizado: {valorValue}");
    }

    // Método llamado por el hijo Char
    public void UpdateCharValue(string value)
    {
        charValue = value;
        Debug.Log($"TrackValues ({name}) - Char actualizado: {charValue}");
    }

    // Método para realizar la comparación lógica
    public bool EvaluateComparison(string coinValue)
    {
        Debug.Log($"Iniciando comparación lógica con CoinValue: {coinValue}, CharValue: {charValue}, ValorValue: {valorValue}");
        
        if (float.TryParse(valorValue, out float trackNumber) && float.TryParse(coinValue, out float coinNumber))
        {
            switch (charValue)
            {
                case "<":
                    Debug.Log($"Comparando si {coinNumber} < {trackNumber}");
                    return coinNumber < trackNumber;
                case ">":
                    Debug.Log($"Comparando si {coinNumber} > {trackNumber}");
                    return coinNumber > trackNumber;
                case "≤":
                    Debug.Log($"Comparando si {coinNumber} ≤ {trackNumber}");
                    return coinNumber <= trackNumber;
                case "≥":
                    Debug.Log($"Comparando si {coinNumber} ≥ {trackNumber}");
                    return coinNumber >= trackNumber;
                case "=":
                    Debug.Log($"Comparando si {coinNumber} = {trackNumber}");
                    return Mathf.Approximately(coinNumber, trackNumber);
                default:
                    Debug.LogError($"Operador no válido en TrackValues: {charValue}");
                    return false;
            }
        }
        Debug.LogError("Error en los valores: no son números válidos para la comparación.");
        return false;
    }

    // Método opcional para obtener ambos valores (si se necesita en algún punto)
    public (string, string) GetRegisteredValues()
    {
        return (valorValue, charValue);
    }
}
