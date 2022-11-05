using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Move;
using Project.Inputs;
using UnityEngine.InputSystem;
using Project.Datas;

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

    [SerializeField] float _moveSpeed = 5f;
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

    bool _isTriggered;
    bool waitTime = true;
    public int _damage { get;private set; }
    [SerializeField] Data _data;
    Animator _anim;

    // public Controller _controller;

    public Transform CameraTransform => _cameraTransform;
    

    private void Awake() {
        _damage =5;
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
 
    }

   
    // Update is called once per frame
    void Update()
    {
  
        

        if (_input.Shoot)
        {
            _isTriggered = true;
        }
        _direction = _input.Direction;
        _yRotation.RotationAction(_input.Rotation.y, _turnSpeed);
        _xRotation.RotationAction(_input.Rotation.x, _turnSpeed);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _anim.SetTrigger("RifleAttack");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _anim.SetTrigger("SwordAttack");
        }

        
    }
    private void FixedUpdate() {
        
     _mover.MovePlayer(_direction, _moveSpeed);

        if (_isTriggered && waitTime == true)
        {
            StartCoroutine(SpawnAndKillBullet());
            waitTime = false;
            StartCoroutine(Reload());

            
        }
        _isTriggered= false;


    }
    void LateUpdate() {
        Debug.Log(_direction.magnitude);
        if (_anim.GetFloat("moveSpeed") == _direction.magnitude) return;
        
        else
            _anim.SetFloat("moveSpeed",  _direction.magnitude, 0.1f, Time.deltaTime);
    }


       IEnumerator SpawnAndKillBullet()
    {
        
        GameObject _bullet = Instantiate(Bullet, FireFrom.position, transform.rotation);
        
        yield return new WaitForSeconds(4f);
        Destroy(_bullet);
    }

    IEnumerator Reload()

    {
        yield return new WaitForSeconds(2.5f);
        waitTime=true;
    }

void SetPlayerStats()
    {
        GetComponent<Health>().SetHealth(_data.HP,_data.HP);
        _damage = _data.damage;
        _moveSpeed = _data.speed;
    }

}
}
