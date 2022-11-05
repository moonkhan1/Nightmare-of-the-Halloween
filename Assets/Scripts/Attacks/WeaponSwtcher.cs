using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Project.Attacks
{

   
public class WeaponSwtcher : MonoBehaviour
{
     [SerializeField] int _weaponIndex = 0;
    void Start()
    {
        SwitchWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int _previousWeaponIndex = _weaponIndex;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (_weaponIndex >= transform.childCount - 1)
            {
                _weaponIndex = 0;
            }
            else
                _weaponIndex++;
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (_weaponIndex <= 0)
            {
                _weaponIndex = transform.childCount - 1;
            }
            else
                _weaponIndex--;
        }

        if (_previousWeaponIndex != _weaponIndex)
        {
            SwitchWeapon();
        }
    }

    public void SwitchWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == _weaponIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }

    }
}
}