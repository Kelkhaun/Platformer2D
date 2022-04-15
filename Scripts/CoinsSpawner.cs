using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime;

    private List<Coin> _coins = new List<Coin>(15);
    private List<Transform> _spawnPoints = new List<Transform>();

    private void Start()
    {
        SpawnCoin();
    }

    private void Update()
    {
        RespawnCoin();
    }

    private void RespawnCoin()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            for (int i = 0; i < _coins.Count; i++)
            {
                _coins[i].gameObject.SetActive(true);
            }

            _elapsedTime = 0;
        }
    }

    private void SpawnCoin()
    {
        foreach (Transform spawnPoints in transform)
        {
            _spawnPoints.Add(spawnPoints);
        }

        for (int i = 0; i < _coins.Capacity; i++)
        {
            Coin coin = Instantiate(_coinPrefab, _spawnPoints[i].transform.position, Quaternion.identity, transform);
            _coins.Add(coin);
        }
    }
}
