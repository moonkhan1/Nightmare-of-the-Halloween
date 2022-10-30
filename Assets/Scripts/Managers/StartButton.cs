using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Managers
{
public class StartButton : MonoBehaviour
{
    Button _button;
    GameObject _gameManager;


        private void Awake() {
            _gameManager = GameObject.FindGameObjectWithTag("GameManager");
            _button = GetComponent<Button>();
        }       

        private void OnEnable() {
            _button.onClick.AddListener(OnButtonClick);
        }
        private void OnDisable() {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        void OnButtonClick()
        {
           _gameManager.GetComponent<GameManager>().LoadScene("Game");
        }
}
}