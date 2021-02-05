using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Manager { get; private set; }

    [SerializeField] private Coin coinPrefab;

    private Coin spawnCoin = null;


    private void Awake()
    {
        Manager = this;
    }

    public void CreateCoins(int _amount)
    {
        if (_amount <= 0)
            return;

        for (int i = 0; i < _amount; i++)
        {
            spawnCoin = Coin.Instantiate(coinPrefab, transform);
            spawnCoin.transform.localPosition = new Vector3(Random.Range(-50, 40), 0.5f, Random.Range(-45, 55));
            spawnCoin.gameObject.SetActive(true);
            spawnCoin = new Coin(Random.Range(1, 1000000));
        }
    }
}
