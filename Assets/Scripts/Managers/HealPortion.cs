using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Managers{
public class HealPortion : MonoBehaviour
{
    [SerializeField] int value;
    GameObject _spawner;
    
    GameObject _Player;
    void Start()
    {
        value = Random.Range(6,13);
        _Player = GameObject.FindGameObjectWithTag("Player");  
        _spawner =  GameObject.FindGameObjectWithTag("HealManager");  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Heal");
            other.transform.GetComponent<Health>().Heal(value);
            // _spawner.GetComponent<HealSpawner>()._healPortionCount --;
            Destroy(this.gameObject);

        }
    }

    private void OnDestroy() {
        _spawner.GetComponent<HealSpawner>().RemoveProtion(this);
    }
}
}