using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    [HideInInspector] // sadece inspector'de g�z�kmesin ama buraya da ula�abilmek istedi�imiz i�in
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
        //rigodbody pozisyonu tekrar g�ncellenecek
        myBody.velocity = new Vector2 (speed, myBody.velocity.y);
    }
}
