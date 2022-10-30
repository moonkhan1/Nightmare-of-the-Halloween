using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Controller;


namespace Project.Datas
{
[CreateAssetMenu (fileName ="Spawner Data", menuName ="Info/SpawnerData")]
public class SpawnerData : ScriptableObject
{
    [SerializeField] EnemyController _enemy;
    [SerializeField] float _maxSpawnTime = 20f;
    [SerializeField] float _minSpawnTime = 5f;

    public EnemyController Enemy => _enemy;
    public float RandomSpawn => Random.Range(_minSpawnTime, _maxSpawnTime);
}
}