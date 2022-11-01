using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Datas;
using Project.Managers;
using Project.Attacks;


namespace Project.Controller{
public class EnemyController : MonoBehaviour
{
   
    GameObject _Player;
    [Range(0, 20)]
    [SerializeField] float Speed = 5f;

    EmptyObject emptyObject;

     GameObject Player;
    int _enemyDamage = 2;
    float _enemySpeed = 5f;

    [SerializeField] Data _data;
    PlayerController _player;
    int _playerDamage;
    GameObject _enemyManager;
    Animator _anim;

    MeleeAttack _meleeAttack;

 
    private void Awake() {
    }
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");   
        _enemyManager = GameObject.FindGameObjectWithTag("EnemyManager");  
        _playerDamage = _Player.GetComponent<PlayerController>()._damage;
        _anim = GetComponent<Animator>();     
        _meleeAttack = GetComponentInChildren<MeleeAttack>();
        
        SetEnemyStats();
        
        
    }


    
    void Update()
    {
        
        
        transform.LookAt(_Player.transform.position);


        // new Vector3(0,0,1);

        //Debug.Log(Vector3.Distance(transform.position,_Player.transform.position));

        if (Vector3.Distance(transform.position, _Player.transform.position) <= 1)
        {
            _anim.SetBool("IsAttacking", true);
            return;
        }
        else
        {
            
        // transform.position += transform.forward * Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _Player.transform.position, Speed * Time.deltaTime);
        _anim.SetBool("IsAttacking", false);
        }


    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            
            this.GetComponent<Health>().Damage(_playerDamage);
            Debug.Log("collision and damage");
            
            Debug.Log(_playerDamage);
        }

        
    }

    //  void OnCollisionStay(Collision collision) {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         if (collision.gameObject.GetComponent<Health>() != null)
    //         {
    //             if (Time.time >= nextAttack )
    //             {
                    
    //             collision.gameObject.GetComponent<Health>().Damage(_enemyDamage);
    //             nextAttack = Time.time + AttackTime/AttackRate;
    //             }
    //         }
    //     }
    // }

    void SetEnemyStats()
    {
        GetComponent<Health>().SetHealth(_data.HP,_data.HP);
        _enemyDamage = _data.damage;
        _enemySpeed = _data.speed;
    }
 

    private void OnDestroy() {
        _enemyManager.GetComponent<EnemyManager>().RemoveEnemy(this);
    }

}
}