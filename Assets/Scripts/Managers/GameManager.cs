using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Project.Managers
{
    
    public class GameManager : MonoBehaviour
    {
        [SerializeField] int _waveMaxCount = 5;
        [SerializeField] float _waitForNextWave = 6f;
        [SerializeField] float _nextWaveMultiplier = 2.2f;

        GameObject _enemyManager;

        int _currentMaxWaveCount;
        public bool IsWaveFinished => _currentMaxWaveCount <= 0;

        private void Awake() {
            _enemyManager = GameObject.FindGameObjectWithTag("EnemyManager");
        }
        private void Start() {
            _currentMaxWaveCount = _waveMaxCount;
        }
        public void LoadScene(string name)
        {
            StartCoroutine(LoadLevel(name));
        }

        IEnumerator LoadLevel(string name)
        {
            yield return SceneManager.LoadSceneAsync(name);
        }

        public void DecreaseCount()
        {
            if (IsWaveFinished)
            {
                if (_enemyManager.GetComponent<EnemyManager>().IsAllDead)
                {
                    StartCoroutine(StartNextWave());
                }
            }
                else
                {
                    _currentMaxWaveCount--;
                }
            
        }

        IEnumerator StartNextWave()
        {
            yield return new WaitForSeconds(_waitForNextWave);
            _waveMaxCount = System.Convert.ToInt32(_waveMaxCount * _nextWaveMultiplier);
            _currentMaxWaveCount = _waveMaxCount;
        }
    }
}