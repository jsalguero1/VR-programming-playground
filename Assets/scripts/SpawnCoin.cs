using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject coin_asset;
    public Transform SpawnPoint;

    public void Spawn()
    {
        Instantiate(coin_asset, SpawnPoint.position, SpawnPoint.rotation);
    } 
}
