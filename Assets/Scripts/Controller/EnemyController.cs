using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Project.Datas;
using Project.Managers;
using Project.Attacks;
using DG.Tweening;


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

    [SerializeField] Material mat;
    [SerializeField] Color defaultColor;
    [SerializeField] Color damageColor;

    NavMeshAgent _navMesh;
    Rigidbody rb;
    private void Awake() {
    }
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");   
        _enemyManager = GameObject.FindGameObjectWithTag("EnemyManager");  
        _playerDamage = _Player.GetComponent<PlayerController>()._rifleDamage;
        _anim = GetComponent<Animator>();     
        _meleeAttack = GetComponentInChildren<MeleeAttack>();
        _navMesh = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        SetEnemyStats();
        
        
        
    }


    
    void Update()
    { 
        _playerDead = _Player.GetComponent<PlayerController>().IsPlayerDead;
        _currentTime += Time.deltaTime;
        _canAttack = _currentTime > _attackData.AttackMaxDelay;
         _navMesh.SetDestination(_Player.transform.position);
        rb.MovePosition(transform.forward  * Time.deltaTime * Speed);
        StartCoroutine(IsDeadChecker(2f));
        _anim.SetBool("IsAttacking", false);

        
        
            if(!_playerDead && Vector3.Distance(transform.position, _Player.transform.position) <= 5f)
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
        if(_playerDead)
            {
                 _anim.SetBool("IsAttacking", false);
                 _anim.SetBool("IsPlayerDead", true);
            }
            


    }

 
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bullet"))
        {
             this.GetComponent<Health>().Damage(_playerDamage);
            var seq = DOTween.Sequence();
                        seq.Append(mat.DOColor(damageColor, "_BaseColor", 0.2f)).Join(transform.DOShakeScale(0.1f, 1));
                        seq.Append(mat.DOColor(defaultColor, "_BaseColor", 0.2f));            
            Debug.Log(_playerDamage);
        }
    }
        
    

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
        _canAttack = false;
        
        yield return new WaitForSeconds(interval);
        Destroy(gameObject);
        StopCoroutine(IsDeadChecker(1f));
        
        }
        
    }

}
}