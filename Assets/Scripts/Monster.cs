using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    [HideInInspector] // sadece inspector'de gözükmesin ama buraya da ulaşabilmek istediğimiz için
    public float speed;

    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rigodbody pozisyonu tekrar güncellenecek
        myBody.velocity = new Vector2 (speed, myBody.velocity.y);
    }
}
