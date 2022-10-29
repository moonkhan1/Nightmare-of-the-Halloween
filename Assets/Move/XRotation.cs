using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeAcademyDers4.Inputs;
using CodeAcademyDers4.Scripts;

namespace CodeAcademyDers4.Move
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
