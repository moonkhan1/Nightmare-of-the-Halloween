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
using Cinemachine;

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

    [SerializeField] float _moveSpeed = 12f;
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

    [SerializeField] CinemachineVirtualCamera _cinemachineVirtualCamera;
    public ParticleSystem _muzzleLight;



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
         _cinemachineVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        _Enemy = GameObject.FindGameObjectWithTag("Enemy");
        _anim = GetComponent<Animator>();
        _weaponSwitch = GetComponentInChildren<WeaponSwtcher>();
        _meleeAttack = GetComponentInChildren<MeleeAttack>();
 
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
                    _muzzleLight.Play();
                    StartCoroutine(Reload(0.3f));
                    _anim.SetBool("RifleAttack2", true);
                    _rangedAttack.AttackAction("Enemy", _rifleDamage);
                }
                else{
                _isTriggered= false;
                _muzzleLight.Stop();
                }
        }
        if (_weaponSwitch._weaponIndex == 0)
        {
            _anim.SetBool("IsRifleIdle", false);
            _anim.SetBool("SwordAttack2", false);
                if (_isTriggered && waitTime)
                {
                    waitTime = false;
                    
                    StartCoroutine(Reload(0.1f));
                    _anim.SetBool("SwordAttack2", true);
                    _meleeAttack.AttackAction("Enemy", _swordDamage);
                }
                _isTriggered= false;
        }

        }
        else{
            _anim.SetBool("IsDead", true);
            
            VirtualCameraMove();
        }
    }
    private void FixedUpdate() {
        
     if(!IsPlayerDead)
        {
       _mover.MovePlayer(_direction, _moveSpeed);
        }


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



    IEnumerator Reload(float interval)

    {
        yield return new WaitForSeconds(interval);
        waitTime=true;
    }

void SetPlayerStats()
    {
        GetComponent<Health>().SetHealth(_data.HP,_data.HP);
        _rifleDamage = _data.damage;
        _moveSpeed = _data.speed;
        Debug.Log(_swordDamage);
        Debug.Log(_rifleDamage);
    }


    void VirtualCameraMove()
    {
        

        _cinemachineVirtualCamera.Follow = null;
        _cinemachineVirtualCamera.LookAt = null;

        _cinemachineVirtualCamera.transform.position = Vector3.Lerp(_cinemachineVirtualCamera.transform.position,
            new Vector3(5, 10, 2), 1f * Time.deltaTime);

        _cinemachineVirtualCamera.transform.rotation = Quaternion.Lerp(_cinemachineVirtualCamera.transform.rotation,
            Quaternion.Euler(new Vector3(-6, 90, 0)), 1f * Time.deltaTime);
    }

}
}
