using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Araba : MonoBehaviour
{
    float horizontal;
    Rigidbody2D rigid;

    [SerializeField]
    float arac_hiz;

    [SerializeField]
    private Text puantext;

    [SerializeField]
    private GameObject kamera;

    Vector3 toplam, fark;

    int puan;

    void Start()
    {
        puan = 0;
        rigid = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        Arabailerleme();
        puantext.text ="Puan :"+ puan.ToString();




		toplam = kamera.transform.position + fark;
		kamera.transform.position = new Vector3(kamera.transform.position.x, kamera.transform.position.y, kamera.transform.position.z); ;
	}
    
    void Arabailerleme()
	{
        horizontal = Input.GetAxis("Horizontal");
        rigid.AddForce(new Vector3(horizontal * arac_hiz, 0, 0));
    }


	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Coin")
		{
			puan += 10;
   		}
		Debug.Log(puan);
		Destroy(collision.gameObject);
	}
}
