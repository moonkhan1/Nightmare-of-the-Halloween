using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Datas;
using Project.Controller;
using DG.Tweening;

public class RangeAttacks : MonoBehaviour
{
    [SerializeField] Camera _cameraTransform;
    [SerializeField] Bullet _bullet;
    [SerializeField] Transform FireFrom;
    
    bool waitTime = true;

    [SerializeField] AttackData _attackData;

        [SerializeField] Material mat;
    [SerializeField] Color defaultColor;
    [SerializeField] Color damageColor;
    public void AttackAction(string _tag, int damage)
    {
            Ray ray = _cameraTransform.ViewportPointToRay(Vector3.one / 2f);
            // if (Physics.Raycast(ray, out RaycastHit hit, 10f, _attackData.LayerMask))
            // {
            // Debug.DrawRay(FireFrom.position, transform.forward, Color.green,_attackData.LayerMask);
            //     Debug.Log("Ilk faza");
            //     if (hit.collider.TryGetComponent(out Health health) && hit.collider.tag == _tag)
            //     {
            //         Debug.Log("From rangeAttack");
            //         health.Damage(damage);
                     
            //     }
            // }
        


        var bullet = Instantiate(_bullet, FireFrom.position, FireFrom.rotation);
        
        // bullet.SetDirection(ray.direction);
    }
}
