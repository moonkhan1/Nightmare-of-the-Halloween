using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Managers
{
public class ExitButton : MonoBehaviour
{
    Button _button;
    GameObject _gameManager;

    void Awake() {
            _gameManager = GameObject.FindGameObjectWithTag("GameManager");
            _button = GetComponent<Button>();
        }  

         private void OnEnable() {
            _button.onClick.AddListener(ExitGameClick);
        }
        private void OnDisable() {
            _button.onClick.RemoveListener(ExitGameClick);
        }  

     public void ExitGameClick()
    {
        _gameManager.GetComponent<GameManager>().ExitGame();
    }

}
}
