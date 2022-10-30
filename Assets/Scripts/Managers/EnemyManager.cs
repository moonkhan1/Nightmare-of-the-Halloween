using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Controller;

namespace Project.Managers
{

    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] List<EnemyController> _enemies;
        [SerializeField] int _maxEnemyCount = 2;
        public bool CanSpawn => _maxEnemyCount > _enemies.Count;

        void Awake()
        {
            _enemies = new List<EnemyController>();
        }
        public void AddEnemy(EnemyController enemyController)
        {
            enemyController.transform.parent = this.transform;
            _enemies.Add(enemyController);
        }

        public void RemoveEnemy(EnemyController enemyController)
        {
            _enemies.Remove(enemyController);
        }

    }
}
