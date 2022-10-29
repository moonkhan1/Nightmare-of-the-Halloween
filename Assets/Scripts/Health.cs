using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    private int _maxHealth = 100;


    public event System.Action<int,int> OnHitTaken;
    void Update()
    {
        
        
    }
    
    public void SetHealth(int MaxHealth, int health)
    {
        this._maxHealth = MaxHealth;
        this._health = health;
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            Debug.Log("No");
        }
        this._health -= amount;
        OnHitTaken?.Invoke(_health, _maxHealth);
        
        if(_health <= 0)
        {
            Destroy(gameObject);
        }

    }

    // public void Heal(int amount)
    // {
    //     if(amount > 0)
    //     {
    //         if (health + amount > _maxHealth)
    //         {
    //             this.health = _maxHealth;
    //         }
    //         else
    //         {
    //             this.health += amount;
    //         }
    //     }
    // }
}
