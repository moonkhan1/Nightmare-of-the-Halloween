using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Datas;
using Project.Controller;

namespace Project.Attacks
{
public class MeleeAttack : MonoBehaviour
{
    [SerializeField] Transform _transformAttackPoint;
    [SerializeField] AttackData _attackData;
    
 private void Start() {

    
 }
 private void Update() {
    
   
 }
     public void AttackAction(string _tag, int damage)
        {
            Vector3 attackPoint = _transformAttackPoint.position;
            Collider[] colliders = Physics.OverlapSphere(attackPoint, _attackData.FloatValue, _attackData.LayerMask);

            foreach (Collider collider in colliders)
            {
                Debug.Log(collider.gameObject.name);
                if (collider.gameObject.GetComponent<Health>() != null && collider.tag == _tag)
                {   
                     
                    collider.GetComponent<Health>().Damage(damage);

                    
                }
            }
        }
   

    


}
}