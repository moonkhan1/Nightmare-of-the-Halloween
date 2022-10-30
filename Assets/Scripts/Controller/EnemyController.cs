using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Datas;
namespace Project.Controller{
public class EnemyController : MonoBehaviour
{
    GameObject Body;
    [SerializeField] Color BodyColor;

    GameObject Eye;
    [SerializeField] Color EyeColor;

    GameObject LeftArm;
    [SerializeField] Color LeftAramColor;

    GameObject RightArm;
    [SerializeField] Color RightArmColor;

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


    private void Awake() {

    }
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");   
        _playerDamage = _Player.GetComponent<PlayerController>()._damage;     
        
        SetEnemyStats();
        
        Body = gameObject;
        ColorizeBodyPart(Body, BodyColor);
        Eye = transform.GetChild(0).gameObject;
        ColorizeBodyPart(Eye, EyeColor);
        LeftArm = transform.GetChild(1).gameObject;
        ColorizeBodyPart(LeftArm, LeftAramColor);
        RightArm = transform.GetChild(2).gameObject;
        ColorizeBodyPart(RightArm, RightArmColor);
    }

    
    void Update()
    {
        transform.LookAt(_Player.transform.position);


        // new Vector3(0,0,1);

        //Debug.Log(Vector3.Distance(transform.position,_Player.transform.position));

        if (Vector3.Distance(transform.position, _Player.transform.position) <= 3)
            return;

        transform.position += transform.forward * Speed * Time.deltaTime;

    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            
            this.GetComponent<Health>().Damage(_playerDamage);
            Debug.Log("collision and damage");
            
            Debug.Log(_playerDamage);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<Health>() != null)
            {
                collision.gameObject.GetComponent<Health>().Damage(_enemyDamage);
            }
        }
    }

    void SetEnemyStats()
    {
        GetComponent<Health>().SetHealth(_data.HP,_data.HP);
        _enemyDamage = _data.damage;
        _enemySpeed = _data.speed;
    }
    void ColorizeBodyPart(GameObject go, Color c)
    {
        go.GetComponent<Renderer>().material.color = c;
    }


}
}