using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Datas;
using Project.Managers;

namespace Project.Controller
{
    

public class SpawnerController : MonoBehaviour
{
    [SerializeField] SpawnerData _spawnData;
    [SerializeField]float _maxTime;
    GameObject _enemyManager;
    GameObject _gameManager;
    float _currentTime = 0f;

     void Start() {
        _enemyManager = GameObject.FindGameObjectWithTag("EnemyManager");  
         _gameManager = GameObject.FindGameObjectWithTag("GameManager");  
        _maxTime = _spawnData.RandomSpawn;
    }

     void Update() {
        _currentTime += Time.deltaTime;

        if (_currentTime > _maxTime && _enemyManager.GetComponent<EnemyManager>().CanSpawn && !_gameManager.GetComponent<GameManager>().IsWaveFinished)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        EnemyController enemyController =  Instantiate(_spawnData.Enemy, transform.position, Quaternion.identity);
        _enemyManager.GetComponent<EnemyManager>().AddEnemy(enemyController);

        Debug.Log("Spawned");
        _currentTime = 0f;
        _maxTime = _spawnData.RandomSpawn;
    }
}
}