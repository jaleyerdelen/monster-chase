using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   //private olmas�n� istedi�imiz ama yine de unity panelden eri�ebilmek istedi�imiz de�i�kenleri kullanabilmek i�in SerializedField kullan�r�z.
    //Hem di�er class'lar eri�eyemeyecek hem de rahat�a kullanabilece�iz
    [SerializeField] 
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    [SerializeField]
    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
       
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();

    }
    private void FixedUpdate()
    {
        //PlayerJump(); Burada jump i�lemim tam �al��m�yordu. Update'de her frame �a�r�l�yor ve input control ve movement i�in kullan�l�yor
        //FixedUpdate ise collisions, trigger gibi i�lemlerde kullan�l�yor.
    }
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

    }

    void AnimatePlayer() 
    {
        //we are going to the right side
        if (movementX > 0)
        {
        anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;

        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);

        }
    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {   
            isGrounded = false;
            myBody.AddForce(new Vector2 (0f, jumpForce), ForceMode2D.Impulse);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    //trigger'� check'lersek karaktere �arpmadan devam ediyor
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }


}
