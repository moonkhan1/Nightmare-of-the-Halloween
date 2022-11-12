using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Controller;

namespace Project.Managers{
public class HealPortion : MonoBehaviour
{
    [SerializeField] int value;
    GameObject _spawner;
    
    GameObject _Player;
    MeshRenderer[] _mesh;

    public ParticleSystem _healParticles;
    void Start()
    {
        value = Random.Range(6,13);
        _Player = GameObject.FindGameObjectWithTag("Player");  
        _spawner =  GameObject.FindGameObjectWithTag("HealManager");  
        
        _mesh = GetComponentsInChildren<MeshRenderer>();
            
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && _Player.GetComponent<Health>().PlayerHealth < 100)
        {
        _healParticles.Play();
        for (int i = 0; i <_mesh.Length ; i++)
        {
            _mesh[i].GetComponent<MeshRenderer>().enabled = false;
        }
        
            
            other.transform.GetComponent<Health>().Heal(value);
            StartCoroutine(DestroyPotion());

        }
        
    }

    IEnumerator DestroyPotion()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy() {
        _spawner.GetComponent<HealSpawner>().RemoveProtion(this);
    }
}
}