using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Project.Datas
{
[CreateAssetMenu(fileName = "Data", menuName = "Stats/Data", order = 1)]
public class Data : ScriptableObject 
{
    public int HP;
    public int damage;
    public float speed;
}
}