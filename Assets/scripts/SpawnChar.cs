using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnChar : MonoBehaviour
{
    public GameObject char_asset; // Prefab del carácter
    public Transform SpawnPoint; // Punto de spawn

    public void Spawn()
    {
        // Instanciar el prefab en el punto de spawn
        GameObject spawnedChar = Instantiate(char_asset, SpawnPoint.position, SpawnPoint.rotation);

        // Buscar el componente TMP_Text en el objeto instanciado
        TMP_Text textComponent = spawnedChar.GetComponentInChildren<TMP_Text>();
        
        if (textComponent != null)
        {
            // Asignar el valor actual del inputFieldCharValue al TMP_Text
            textComponent.text = GlobalValueManager.Instance.GetInputFieldCharValue();
        }
        else
        {
            Debug.LogWarning("El prefab no tiene un componente TMP_Text asignado.");
        }
    }
}
