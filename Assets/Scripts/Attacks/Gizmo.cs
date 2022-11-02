using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    [SerializeField] float _radius = 1f;
    void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

     private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position,_radius);
    }
}
