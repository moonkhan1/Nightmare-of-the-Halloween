using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Random = System.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] float DestroyTime = 5f;
    string FuncName;
    // Start is called before the first frame update
    void Start()
    {
        // DestroyTime = Random.Range(1, 5);
        // System.Random rnd = new System.Random();
        // rnd.Next(1,5);
        //DestroyTime = Random.Range(1, 5);


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        Debug.Log(gameObject.name + "'e Tıkladık");
        //Destroy(gameObject);

        //Destroy(gameObject, DestroyTime);
        transform.GetChild(0).GetComponent<Renderer>().material.color = Color.yellow;
        ///Ornek2
        //CubeDestroy();



        // Invoke("TestLog", 2);




        //InvokeRepeating("TestLogRepeating", 2, 5);



        StartCoroutine(TestLogWithString("Deneme Courutine", 2));
    }
    ///Ornek2

    ///Bu örnek ile objeyi direkt destroy etmektense içerisinde göstereceğimiz efekt ve ek objeler için renderer ı kapatarak ana objeyi gizliyoruz.
    /// Destroya verdiğimiz süre ile bir kaç saniye sonra objeyi sahneden siliyoruz. Böylelikle içerisinde göstereceğimiz efekt ve objeler toplanınca gözükmüş oluyor.

    public void CubeDestroy()
    {
        GetComponent<Renderer>().enabled = false;
        Destroy(gameObject, 3f);
    }

    public void TestLog()
    {
        Debug.Log("Invoke Mesaj");
    }
    public void TestLogRepeating()
    {
        Debug.Log("InvokeRepeating Mesaj");
    }

    // public void TestLogWithString(string txt)
    // {

    // }

    IEnumerator TestLogWithString(string txt, float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime); // 2 saniye bekliyor
        ///işlemler devam ediyor
        Debug.Log(txt);

        yield return new WaitForSeconds(WaitTime);
        Debug.Log("Tekrar Bekledik");
        StopCoroutine(TestLogWithString(txt, WaitTime));
        //StopAllCoroutines();  Bütün coroutineleri durdurur;
    }
}
