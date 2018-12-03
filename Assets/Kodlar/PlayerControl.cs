using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
     Rigidbody fizik;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec3;
    public float minX,maxX,minZ,maxZ;
    public float egim;
    float atesZamani=0;
    public float atesGecenSuresi;
    public float KarakterHız;
    public GameObject kursun;
    public Transform kursunCikisYeri;
    AudioSource audio;

	void Start ()
    {
        fizik = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
	}
    private void Update()
    {
       if(Input.GetButton("Fire1") && Time.time>atesZamani)
        {          
            atesZamani = Time.time + atesGecenSuresi; //basılı tutunca surekli ates etmeyi engeller belli sürelerde ates eder
            Instantiate(kursun, kursunCikisYeri.position, Quaternion.identity);
            audio.Play();
        }
    }

    void FixedUpdate ()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec3 = new Vector3(horizontal, 0, vertical);
        fizik.velocity = vec3*KarakterHız;
        fizik.position = new Vector3
            (
            Mathf.Clamp(fizik.position.x, minX, maxX),
            0.0f,
            Mathf.Clamp(fizik.position.z, minZ, maxZ)


            );
        fizik.rotation = Quaternion.Euler(0, 0, fizik.velocity.x * (-egim));
	}


}
