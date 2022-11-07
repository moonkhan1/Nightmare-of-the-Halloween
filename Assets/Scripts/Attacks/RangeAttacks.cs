using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Datas;
using Project.Controller;
public class RangeAttacks : MonoBehaviour
{
    [SerializeField] Camera _cameraTransform;
    [SerializeField] Bullet _bullet;
    [SerializeField] Transform FireFrom;
    bool waitTime = true;

    [SerializeField] AttackData _attackData;
    public void AttackAction(string _tag, int damage)
    {
            Ray ray = _cameraTransform.ViewportPointToRay(Vector3.one / 2f);

            if (Physics.Raycast(ray, out RaycastHit hit, _attackData.FloatValue, _attackData.LayerMask))
            {
                
                if (hit.collider.GetComponent<Health>() != null && hit.collider.tag == _tag)
                {
                    Debug.Log(hit.collider.name);
                    hit.collider.GetComponent<Health>().Damage(damage);
                }
            }
        


        var bullet = Instantiate(_bullet, FireFrom.position, FireFrom.rotation);
        bullet.SetDirection(ray.direction);
    }
}
