using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Project.Managers;

public class DisplayWave : MonoBehaviour
{
    GameObject _gameManager;
   TMP_Text _levelText;

    void Awake() 
   {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _levelText = GetComponent<TMP_Text>();
   }

   private void OnEnable() {
    _gameManager.GetComponent<GameManager>().NextWave += ShowWave;
   }

   private void OnDisable() {
    _gameManager.GetComponent<GameManager>().NextWave -= ShowWave;
   }

   void ShowWave(int level)
   {
    _levelText.text = level.ToString();
   }
}
