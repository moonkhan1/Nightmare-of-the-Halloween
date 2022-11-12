using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float Speed = 20f;
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


    void OnTriggerEnter(Collider other)
        {
            Destroy(this.gameObject);
           
        }

    public void SetDirection(Vector3 direction)
        {
            rb.velocity = direction * Speed;
        }

    


}
