using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DisplayHealth : MonoBehaviour
{
   [SerializeField]Image _healthImage;

    void Awake() 
    {
        _healthImage = GetComponent<Image>();
    }
    void HitTaken(int _health, int _maxHealth)
    {
        _healthImage.fillAmount = Convert.ToSingle(_health) / Convert.ToSingle(_maxHealth);
    }

    private void OnEnable() {
        Health _health = GetComponentInParent<Health>();
        _health.OnHitTaken += HitTaken;
    }


}
