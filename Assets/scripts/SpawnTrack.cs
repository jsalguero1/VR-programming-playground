using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrack : MonoBehaviour
{
    public GameObject trackAsset; // Asset de la pista recta
    public Transform spawnPoint; // Punto donde se generará la pista

    public void Spawn()
    {
        // Instancia la pista recta en el punto de spawn con la misma rotación
        Instantiate(trackAsset, spawnPoint.position, spawnPoint.rotation);
    }
}

