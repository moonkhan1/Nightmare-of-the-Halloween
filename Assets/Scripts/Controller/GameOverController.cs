using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Controller;
using Project.UIS;

namespace Project.Controller{
public class GameOverController : MonoBehaviour
{
    [SerializeField] GameObject _player;
        [SerializeField]GameOverPanel _goPanel;
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
            if(_player.GetComponent<PlayerController>().IsPlayerDead)
            {
                Invoke("WaitAndShowUp", 1f);
            }
        }

        void WaitAndShowUp()
    {
        _goPanel.gameObject.SetActive(true);
    }
}
}
