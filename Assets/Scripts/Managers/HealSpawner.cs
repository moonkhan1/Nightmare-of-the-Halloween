using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Datas;
using Project.Controller;

namespace Project.Managers
{
    
public class HealSpawner : MonoBehaviour
{

    
    [SerializeField] List<HealPortion> _potions;
    [SerializeField] public int _healPortionCount = 4;
    GameObject _gameManager;
    public bool CanSpawnPotion => _healPortionCount > _potions.Count;
    public bool IsAllTaken => _potions.Count <= 0;
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");  
        _potions = new List<HealPortion>();
        

    }

    public void AddProtion(HealPortion _healPortion)
        {
            _healPortion.transform.parent = this.transform;
            _potions.Add(_healPortion);
        }
public void RemoveProtion(HealPortion _healPortion)
        {
            _potions.Remove(_healPortion);
        }
    void Update()
    {
         
    }

    
}
}