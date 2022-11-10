using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Managers;
using Project.Datas;

public class SpawnHeal : MonoBehaviour
{
    float currentTimeForHeal = 0f;
    [SerializeField] HealPortion _healPortion;
    [SerializeField] HealSpawner _healSpawner;
    [SerializeField] SpawnerData _spawnData;

    [SerializeField] float _maxTimeforHeal;
    GameObject _gameManager;
    void Start()
    {
         _gameManager = GameObject.FindGameObjectWithTag("GameManager");  
         _maxTimeforHeal = _spawnData.RandomSpawn;

    }

    // Update is called once per frame
    void Update()
    {
        currentTimeForHeal +=(Time.deltaTime * 0.5f);

         if (currentTimeForHeal > _maxTimeforHeal && !_gameManager.GetComponent<GameManager>().IsWaveFinished && _healSpawner.GetComponent<HealSpawner>().CanSpawnPotion)
        {
            SpawnPortion();
            
        }
    }

    void SpawnPortion()
    {
        HealPortion healPortion = Instantiate(_healPortion, transform.position, Quaternion.identity);
        _healSpawner.GetComponent<HealSpawner>().AddProtion(healPortion);
        currentTimeForHeal = 0f;
        _maxTimeforHeal = _spawnData.RandomSpawn;
    }
}
