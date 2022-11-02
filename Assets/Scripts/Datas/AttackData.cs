using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Datas
{
    
    [CreateAssetMenu(fileName = "AttackData",menuName = "Stats/Attack", order = 1)]

public class AttackData : ScriptableObject
{
        [SerializeField] int _damage = 3;
        [SerializeField] float _floatValue = 1f;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] float _attackMaxDelay = 1f;

        public int Damage => _damage;
        public float FloatValue => _floatValue;
        public LayerMask LayerMask => _layerMask;
        public float AttackMaxDelay => _attackMaxDelay;
}
}