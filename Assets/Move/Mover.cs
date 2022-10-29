using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeAcademyDers4.Scripts;

namespace CodeAcademyDers4.Move
{
public class Mover : MonoBehaviour
{
    CharacterController _charControl;
    float _moveSpeed;

    public Mover(PlayerController _player)
    {
        _charControl = _player.GetComponent<CharacterController>();
    }

    public void MovePlayer(Vector3 direction, float moveSpeed)
    {

        if (direction == Vector3.zero)
        {
            return;
        }
        else
        {
        Vector3 position = _charControl.transform.TransformDirection(direction);
        Vector3 movement = position * moveSpeed * Time.fixedDeltaTime;

        _charControl.Move(movement);
        }
    }
}
}