using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] GameObject SphereObject;
    Vector3 Position;

    [SerializeField] GameObject Bullet;
    [SerializeField] Transform FireTransform;
    // Start is called before the first frame update
    void Start()
    {
        // Position = new Vector3(Random.Range(0, 30)
        //                        , 0
        //                        , Random.Range(0, 30));
        // Debug.Log(Position);
        //Instantiate(SphereObject,Position,Quaternion.Euler(0,0,0));
    }


    private void OnMouseDown()
    {
    /// Obje oluşturmaya yarıyor. Bizden Pozisyon ve Rotasyon bilgisi istiyor.
    /// Verdiğimiz bilgiye göre orada objenin clonunu oluşturuyor.
        Instantiate(Bullet, FireTransform.position, Quaternion.Euler(0, 0, 0));
    }

}
