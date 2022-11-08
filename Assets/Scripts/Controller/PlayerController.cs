using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Move;
using Project.Inputs;
using UnityEngine.InputSystem;
using Project.Datas;
using UnityEditor.Animations;
using Project.Attacks;
using DG.Tweening;

namespace Project.Controller
{

public class PlayerController : MonoBehaviour
{
    // GameObject Body;
    // [SerializeField] Color BodyColor;

    // GameObject Eye;
    // [SerializeField] Color EyeColor;

    // GameObject LeftArm;
    // [SerializeField] Color LeftAramColor;

    // GameObject RightArm;
    // [SerializeField] Color RightArmColor;
    GameObject _Enemy;

    [SerializeField] float _moveSpeed = 18f;
    [SerializeField] float _turnSpeed;
    [SerializeField] Transform _cameraTransform;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform FireFrom;

    EmptyObject emptyObject;

    InputRead _input;
    Mover _mover;
    XRotation _xRotation;
    YRotation _yRotation;

    Vector3 _direction;
    Vector2 _rotation;

    // bool _isTriggered;
    // bool waitTime = true;
    public int _swordDamage { get;private set; }
    public int _rifleDamage { get;private set; }

    [SerializeField] Data _data;

    [SerializeField] AvatarMask RunAttack;
    [SerializeField] AvatarMask FullAttack;
    [SerializeField] AnimatorController _animC;
    Animator _anim;
    WeaponSwtcher _weaponSwitch;
    MeleeAttack _meleeAttack;
    [SerializeField]RangeAttacks _rangedAttack;

     bool _isTriggered;
    bool waitTime = true;
    public bool IsPlayerDead;


    // public Controller _controller;

    public Transform CameraTransform => _cameraTransform;
    

    private void Awake() {
        _swordDamage =5;
        _rifleDamage = 2;
        _input = GetComponent<InputRead>();
        _mover = new Mover(this);
        _xRotation = new XRotation(this);
        _yRotation = new YRotation(this);
        

    }


    void Start()
    {
        
        SetPlayerStats();
        _Enemy = GameObject.FindGameObjectWithTag("Enemy");
        _anim = GetComponent<Animator>();
        _weaponSwitch = GetComponentInChildren<WeaponSwtcher>();
        _meleeAttack = GetComponentInChildren<MeleeAttack>();
        // _rangedAttack = GetComponentInChildren<RangeAttacks>();
 
    }

   
    // Update is called once per frame
    void Update()
    {
        IsPlayerDead = GetComponent<Health>().IsDead;
        
        // IsDeadChecker();
        if (_input.Shoot)
        {
             _isTriggered = true;

        }
        if(!IsPlayerDead)
        {
            // gameObject.layer = LayerMask.NameToLayer("Base Layer"); 
            
             _yRotation.RotationAction(_input.Rotation.y, 0);
            _xRotation.RotationAction(_input.Rotation.x, 0);
       
        _direction = _input.Direction;
        _yRotation.RotationAction(_input.Rotation.y, _turnSpeed);
        _xRotation.RotationAction(_input.Rotation.x, _turnSpeed);
    

        if (_weaponSwitch._weaponIndex == 1)
        {
            _anim.SetBool("IsRifleIdle", true);
            _anim.SetBool("RifleAttack2", false);
                if (_isTriggered && waitTime)
                {
                    waitTime = false;
                    StartCoroutine(Reload(0.3f));
                    _anim.SetBool("RifleAttack2", true);
                    _rangedAttack.AttackAction("Enemy", _rifleDamage);
                }
                _isTriggered= false;
        }
        if (_weaponSwitch._weaponIndex == 0)
        {
            _anim.SetBool("IsRifleIdle", false);
            _anim.SetBool("SwordAttack2", false);
                if (_isTriggered && waitTime)
                {
                    waitTime = false;
                    StartCoroutine(Reload(0.5f));
                    _anim.SetBool("SwordAttack2", true);
                    _meleeAttack.AttackAction("Enemy", _swordDamage);
                    Debug.Log("Hitted");
                }
                _isTriggered= false;
        }

        }
        else{
            _anim.SetBool("IsDead", true);
        }
    }
    private void FixedUpdate() {
        
     _mover.MovePlayer(_direction, _moveSpeed);

        // if (_isTriggered && waitTime)
        // {
        //     waitTime = false;
        //     StartCoroutine(Reload());

            
        // }
        // _isTriggered= false;


    }
    void LateUpdate() {
        Debug.Log(_direction.magnitude);
            _animC.layers[1].avatarMask = FullAttack;
        if (_anim.GetFloat("moveSpeed") == _direction.magnitude) return;
        else
        {
            _animC.layers[1].avatarMask = RunAttack;
            _anim.SetFloat("moveSpeed",  _direction.magnitude, 0.1f, Time.deltaTime);
        }
    }


    //    IEnumerator SpawnAndKillBullet()
    // {
        
    //     GameObject _bullet = Instantiate(Bullet, FireFrom.position, transform.rotation);
        
    //     yield return new WaitForSeconds(4f);
    //     Destroy(_bullet);
    // }

    IEnumerator Reload(float interval)

    {
        yield return new WaitForSeconds(interval);
        waitTime=true;
    }

void SetPlayerStats()
    {
        GetComponent<Health>().SetHealth(_data.HP,_data.HP);
        _rifleDamage = _data.damage;
        _swordDamage = _data.damage;
        _moveSpeed = _data.speed;
    }

    // void IsDeadChecker()
    // {
    //     if(GetComponent<Health>().IsDead)
    //     {
    //         // gameObject.layer = LayerMask.NameToLayer("Base Layer"); 
    //         _anim.SetBool("IsDead", true);
    //         _mover.MovePlayer(_direction, 0);
    //     }
    // }

}
}
