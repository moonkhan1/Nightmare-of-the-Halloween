using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float Speed;



    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    

    // public void Shoot()
    // {
    //     Instantiate(Bullet, FireFrom.position, Quaternion.Euler(0, 0, 0));
    // }
}
