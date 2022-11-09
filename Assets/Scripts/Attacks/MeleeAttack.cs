using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Datas;
using Project.Controller;
using DG.Tweening;

namespace Project.Attacks
{
public class MeleeAttack : MonoBehaviour
{
    [SerializeField] Transform _transformAttackPoint;
    [SerializeField] AttackData _attackData;
    [SerializeField] Material mat;
    [SerializeField] Color defaultColor;
    [SerializeField] Color damageColor;
    
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
                    if (collider.tag == "Enemy")
                    {
                        var seq = DOTween.Sequence();
                        seq.Append(mat.DOColor(damageColor, "_BaseColor", 0.2f)).Join(transform.DOShakeScale(0.1f, 1));
                        seq.Append(mat.DOColor(defaultColor, "_BaseColor", 0.2f));

                    }

                    
                }
            }
        }
   

    


}
}