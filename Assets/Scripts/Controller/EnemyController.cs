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

    //  GameObject PlayerEye;
    public int _enemyDamage;
    float _enemySpeed;

    [SerializeField] Data _data;
    PlayerController _player;
    int _playerDamage;
    GameObject _enemyManager;
    Animator _anim;
     MeleeAttack _meleeAttack;
    [SerializeField] AttackData _attackData;

     [SerializeField] bool _canAttack;
    float _currentTime = 0f;
    bool _playerDead;
    private void Awake() {
    }
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");   
        _enemyManager = GameObject.FindGameObjectWithTag("EnemyManager");  
        _playerDamage = _Player.GetComponent<PlayerController>()._rifleDamage;
        
        _anim = GetComponent<Animator>();     
        _meleeAttack = GetComponentInChildren<MeleeAttack>();
        
        SetEnemyStats();
        
        
    }


    
    void Update()
    { 
        _playerDead = _Player.GetComponent<PlayerController>().IsPlayerDead;
        _currentTime += Time.deltaTime;
        _canAttack = _currentTime > _attackData.AttackMaxDelay;
        
        transform.LookAt(_Player.transform.position);

        
        // new Vector3(0,0,1);

        //Debug.Log(Vector3.Distance(transform.position,_Player.transform.position));

        if (Vector3.Distance(transform.position, _Player.transform.position) <= 1.5f)
        {
            _anim.SetBool("IsAttacking", true);
            if (!_canAttack) 
            {
                return;
        
            }
            else
            {
                _meleeAttack.AttackAction("Player", _enemyDamage);
            }
            _currentTime = 0f;
        }
        else
        {
            if(!_playerDead)
            {
        // transform.position += transform.forward * Speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _Player.transform.position, Speed * Time.deltaTime);
                _anim.SetBool("IsAttacking", false);
            }
            if(_playerDead)
            {
                transform.position = gameObject.transform.position;
                 _anim.SetBool("IsAttacking", false);
                 _anim.SetBool("IsPlayerDead", true);
            }
            else{
                StartCoroutine(IsDeadChecker(3.5f));
            }
        }


    }

    // void OnTriggerEnter(Collision other) {
    //     if (other.gameObject.CompareTag("Bullet"))
    //     {
            
    //         this.GetComponent<Health>().Damage(_playerDamage);
    //         Debug.Log("collision and damage");
            
    //         Debug.Log(_playerDamage);
    //     }
    // }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bullet"))
        {
             this.GetComponent<Health>().Damage(_playerDamage);
            Debug.Log("collision and damage");
            
            Debug.Log(_playerDamage);
        }
    }
        
    // }

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
  

    IEnumerator IsDeadChecker(float interval)

    {

        if(GetComponent<Health>().IsDead)
        {
         _anim.SetBool("IsDead", true);
        yield return new WaitForSeconds(interval);
        Destroy(gameObject);
        
        }
        
    }

}
}