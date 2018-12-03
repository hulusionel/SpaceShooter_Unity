using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour {

    public GameObject Asteroid;
    public Vector3 randomPos;//pozisyon aldık
    public float baslangicBekleme;
    public float olusturmaBekleme;
    public float donguBekleme;
    int score;
    public Text txt;
    public Text oyunBitti;
    public Text txtRestart;
    bool gameOverControl =false;
    bool restartControl = false;



	void Start ()
    {
        score = 0;
        txt.text = "score=" + score;
        StartCoroutine(olustur());

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)&&restartControl)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    IEnumerator olustur()
    {
        yield return new WaitForSeconds(baslangicBekleme);//oyun başlayınnca iki saniye bekle
        while(true)
        { 
            for(int i=0;i<10; i++)
            {
                //yukarda 'randompos' değişkeninde aldığımız değerler ile aşağıda yeni bir vektör oluşturduk girdiğimiz değerler arasında random bir değer üretecek
                Vector3 vec3 = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                //unity de oluşmasını istediğimiz alan içinde x ve z değerlerini buraya işledik
                Instantiate(Asteroid, vec3, Quaternion.identity);
                yield return new WaitForSeconds(olusturmaBekleme);//her asteroid arası bekleme
            }
            if (gameOverControl)
            {
                txtRestart.text = "press 'R' to restart.";
                restartControl = true;
                break;
            }
            yield return new WaitForSeconds(donguBekleme);
           
        }
    }
    public void ScoreArtır(int gelen)
    {
        score += gelen;
        txt.text = "score=" + score;
    }

    public void GameOver()
    {
        gameOverControl = true;
        oyunBitti.text = "GAME OVER";
    }

}
