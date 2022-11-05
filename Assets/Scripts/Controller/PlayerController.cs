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

    [SerializeField] float _moveSpeed;
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
        // Debug.Log(_damage);
        // Body = gameObject;
        // ColorizeBodyPart(Body, BodyColor);
        // Eye = transform.GetChild(0).gameObject;
        // ColorizeBodyPart(Eye, EyeColor);
        // LeftArm = transform.GetChild(1).gameObject;
        // ColorizeBodyPart(LeftArm, LeftAramColor);
        // RightArm = transform.GetChild(2).gameObject;
        // ColorizeBodyPart(RightArm, RightArmColor);


        _Enemy = GameObject.FindGameObjectWithTag("Enemy");

        
    }

   
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(gameObject.transform.position, _Enemy.transform.position));


        // Debug.Log(_input.Direction);
        // if (Vector3.Distance(gameObject.transform.position,_Enemy.transform.position) <=5)
        // {
        //     Debug.Log("Fire");
        // }

        // transform.LookAt(_Enemy.transform.position);

        // if (_playerHealth == _playerHealth -= )
        // {
            
        // }
        

        if (_input.Shoot)
        {
            _isTriggered = true;
        }
        _direction = _input.Direction;
        _yRotation.RotationAction(_input.Rotation.y, _turnSpeed);
        _xRotation.RotationAction(_input.Rotation.x, _turnSpeed);

        // if (emptyObject.enemyList.Count == 0)
        // {
        //     Destroy(this);
        // }
    }

    void FixedUpdate() 
    {
        _mover.MovePlayer(_direction, _moveSpeed);

        if (_isTriggered && waitTime == true)
        {
            StartCoroutine(SpawnAndKillBullet());
            waitTime = false;
            StartCoroutine(Reload());

            
        }
        _isTriggered= false;
    }

    // void OnMouseDown() {
    //     Instantiate(Bullet, FireFrom.position, Quaternion.Euler(0, 0, 0));
    // }

     void ColorizeBodyPart(GameObject go, Color c)
    {
        go.GetComponent<Renderer>().material.color = c;
    }

    // void OnCollisionEnter(Collision collision) {
    //     if (collision.gameObject.CompareTag("Enemy"))
    //     {
    //         Destroy(gameObject);
    //     }
    // }

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
