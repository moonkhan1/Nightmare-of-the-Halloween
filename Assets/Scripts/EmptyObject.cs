using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeAcademyDers4.Scripts
{
    

public class EmptyObject : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjectsList;
    public List<GameObject> enemyList;

    PlayerController _Player;
    // Start is called before the first frame update


    void Awake() {
  
    }
    void Start()
    {
        foreach (GameObject all in gameObjectsList)
        {
            // if (go.tag == "Enemy")
            // {
            //     go.GetComponent<Renderer>().material.color = Color.red;
            // }
            // else if (go.tag == "Player")
            // {
            //     go.GetComponent<Renderer>().material.color = Color.blue;
            // }
            if (all.CompareTag("Enemy"))
            {
                all.GetComponent<Renderer>().material.color = Color.red;
            }
            else if (all.CompareTag("Player"))
            {
                all.GetComponent<Renderer>().material.color = Color.blue;
            }


        }
    }



}
}