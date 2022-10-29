using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeAcademyDers4.Scripts{
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


    // Start is called before the first frame update
    void Start()
    {
        Body = gameObject;
        ColorizeBodyPart(Body, BodyColor);
        Eye = transform.GetChild(0).gameObject;
        ColorizeBodyPart(Eye, EyeColor);
        LeftArm = transform.GetChild(1).gameObject;
        ColorizeBodyPart(LeftArm, LeftAramColor);
        RightArm = transform.GetChild(2).gameObject;
        ColorizeBodyPart(RightArm, RightArmColor);
        _Player = GameObject.FindGameObjectWithTag("Player");
    }

    void ColorizeBodyPart(GameObject go, Color c)
    {
        go.GetComponent<Renderer>().material.color = c;
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
            Destroy(gameObject);
        }
    }


}
}