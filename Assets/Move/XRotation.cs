using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Inputs;
using Project.Controller;

namespace Project.Move
{
public class XRotation : MonoBehaviour
{
    PlayerController _player;

    public XRotation(PlayerController player)
    {
        _player = player;
    }

    public void RotationAction(float direction, float speed)
    {
        _player.transform.Rotate(Vector3.up * direction * speed * Time.deltaTime);
    }
}
}
