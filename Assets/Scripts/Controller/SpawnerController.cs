using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Datas;

namespace Project.Controller
{
    

public class SpawnerController : MonoBehaviour
{
    [SerializeField] SpawnerData _spawnData;
    [SerializeField]float _maxTime;
    float _currentTime = 0f;

     void Start() {
        _maxTime = _spawnData.RandomSpawn;
    }

     void Update() {
        _currentTime += Time.deltaTime;

        if (_currentTime > _maxTime)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Instantiate(_spawnData.Enemy, transform.position, Quaternion.identity);
    Debug.Log("Spawned");
        _currentTime = 0f;
        _maxTime = _spawnData.RandomSpawn;
    }
}
}