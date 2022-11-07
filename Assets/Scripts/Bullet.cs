using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float Speed = 100f;
    [SerializeField] float _maxLifeTime = 3f;
     float _currentLifeTime = 0f;
    Rigidbody rb;

private void Awake() {
    rb = GetComponent<Rigidbody>();
}
    void Update()
    {
          _currentLifeTime += Time.deltaTime;
          if (_currentLifeTime > _maxLifeTime)
          {
            Destroy(this.gameObject);
          }
        transform.position += transform.forward * Speed * Time.deltaTime;
    }
    // void OnCollisionEnter(Collision collision) {
    //     if (collision.gameObject.CompareTag("Enemy"))
    //     {
    //         Destroy(gameObject);
    //          Debug.Log(other.name);
    //     }
    // }

    void OnTriggerEnter(Collider other)
        {
            Destroy(this.gameObject);
           
        }

    public void SetDirection(Vector3 direction)
        {
            rb.velocity = direction * Speed;
        }

    

    // public void Shoot()
    // {
    //     Instantiate(Bullet, FireFrom.position, Quaternion.Euler(0, 0, 0));
    // }
}
