using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeAcademyDers4.Inputs;
using CodeAcademyDers4.Scripts;


namespace CodeAcademyDers4.Move
{

public class YRotation : MonoBehaviour
{
    Transform _transform;
    float _rotationLimit;

    public YRotation(PlayerController _player)
    {
        _transform = _player.CameraTransform;
    }

    public void RotationAction(float direction, float speed)
    {
        direction *= speed * Time.deltaTime;
        _rotationLimit = Mathf.Clamp(_rotationLimit - direction, -30f, 30f);
        _transform.localRotation = Quaternion.Euler(_rotationLimit, 0f, 0f);
    }
}
}