using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Managers;
using Project.Controller;

namespace Project.UIS
{
    

public class GameOverPanel : MonoBehaviour
{
    GameObject _gameManager;
    GameObject _player;

    private void Start() {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _player = GameObject.FindGameObjectWithTag("Player");
        this.gameObject.SetActive(false);
    }
    public void TryAgain()
    {
        _gameManager.GetComponent<GameManager>().LoadScene("Game");
    }

    public void ExitToMenu()
    {
        _gameManager.GetComponent<GameManager>().LoadScene("Menu");
    }

    void Update()
    {
        if (_player.GetComponent<PlayerController>().IsPlayerDead)
        {
            Invoke("WaitAndShowUp",1f);
        }
    }

    

    void WaitAndShowUp()
    {
        this.gameObject.SetActive(true);
    }
}
}