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
  

    [SerializeField] bool _canAttack;
    float _currentTime = 0f;

 private void Start() {
    
 }
 private void Update() {
    _currentTime += Time.deltaTime;
    _canAttack = _currentTime > _attackData.AttackMaxDelay;
    if (!_canAttack) 
    {
        return;
        
    }
    else{
        AttackAction();
    }
    _currentTime = 0f;
   
 }
     public void AttackAction()
        {
            Vector3 attackPoint = _transformAttackPoint.position;
            Collider[] colliders = Physics.OverlapSphere(attackPoint, _attackData.FloatValue, _attackData.LayerMask);

            foreach (Collider collider in colliders)
            {
                Debug.Log(collider.gameObject.name);
                if (collider.gameObject.GetComponent<Health>() != null && collider.tag == "Player")
                {   
                     
                    collider.GetComponent<Health>().Damage(_attackData.Damage);

                    
                }
            }
        }
   

    


}
}