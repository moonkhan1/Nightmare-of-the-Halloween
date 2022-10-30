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
        GameObject _gameManager;
        public bool CanSpawn => _maxEnemyCount > _enemies.Count;
        public bool IsAllDead => _enemies.Count <= 0;

        void Awake()
        {
            _gameManager = GameObject.FindGameObjectWithTag("GameManager");
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
            _gameManager.GetComponent<GameManager>().DecreaseCount();
        }

    }
}
