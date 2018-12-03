using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemaslaYokOl : MonoBehaviour
{
    public GameObject patlama;
    public GameObject userPatlama;

    GameObject OyunKontrol;
    OyunKontrol kontrol;


     void Start()
    {
        OyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol");        
        kontrol = OyunKontrol.GetComponent<OyunKontrol>();
        //obje her yok olduğunda score tablomuz artacak bunun için oyun kontrol sınıfında ateş ettiğimizde oluşan değerleri almamız lazım
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag!="sinir")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(patlama,transform.position,transform.rotation);
            kontrol.ScoreArtır(10);//başka bir sınıfın fonksiyonuna eriştik
        }
        if(col.tag=="Player")
        {
            Instantiate(userPatlama, col.transform.position, col.transform.rotation);
            kontrol.GameOver();
        }

    }

}
