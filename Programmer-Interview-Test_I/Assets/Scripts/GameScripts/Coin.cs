using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private readonly int instanceID = -1;

    public Coin(int _instanceID)
    {
        instanceID = _instanceID;
    }

    public void Destroy()
    {
        GameData.coinsCollectedOnRun++;
        CoinManager.Manager.CreateCoins(1);
        Destroy(gameObject);
    }
}
