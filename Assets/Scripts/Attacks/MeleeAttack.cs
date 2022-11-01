using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Datas;

namespace Project.Attacks
{
public class MeleeAttack : MonoBehaviour
{
    [SerializeField] Transform _transformAttackPoint;
    [SerializeField] AttackData _attackData;
  
    
     [SerializeField] float _radius = 1f;
    [SerializeField] bool _canAttack;
    float _currentTime = 0f;
private void FixedUpdate() {
    _currentTime += Time.fixedDeltaTime;
    _canAttack = _currentTime > _attackData.AttackMaxDelay;
    if (_canAttack)
    {
    AttackAction();
        
    _currentTime = 0f;
    }


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
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position,_radius);
    }

    


}
}