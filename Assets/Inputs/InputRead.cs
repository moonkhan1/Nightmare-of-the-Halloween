using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using CodeAcademyDers4.Move;
using CodeAcademyDers4.Scripts;

namespace CodeAcademyDers4.Inputs
{
public class InputRead : MonoBehaviour
{
    public Vector3 Direction {get; private set;}
    public Vector2 Rotation {get; private set;}
    public bool Shoot {get; private set;}


    public void Move(InputAction.CallbackContext context){
        Vector2 twoDdirection = context.ReadValue<Vector2>();
        Direction = new Vector3(twoDdirection.x, 0f, twoDdirection.y);
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        Rotation = context.ReadValue<Vector2>();
    }

    public void OnTrigger(InputAction.CallbackContext context)
    {
        Shoot = context.ReadValueAsButton();
    }

    

}

// public interface IInput
// {
//     Vector2 Direction{get;}
// }


}