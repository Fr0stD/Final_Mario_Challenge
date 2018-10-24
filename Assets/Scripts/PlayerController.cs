using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private bool facingRight = true;

    public float speed;
    public float jumpforce;

    private Animator anim;

    //ground check
    private bool isOnGround;
    private bool CoinCheck;
    public float CoinCheckWidth;
    public float CoinCheckHeight;
    public Transform CoinCheckHitBox;
    public LayerMask isCoinBox;
    private bool firstCoinBoxTouch;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;

    // private float jumpTimeCounter;
    //public float jumpTime;
    //private bool isJumping;

    //audio stuff
    private AudioSource source;
    public AudioClip jumpClip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (Input.GetKey("escape"))
            Application.Quit();

    }


    void Awake()
    {

        source = GetComponent<AudioSource>();

    }

    /*float vol = Random.Range(volLowRange, volHighRange);
    AudioSource.PlayOneShot(jumpClip);*/

    //private void Update()
    //{

   // }


    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        Debug.Log(moveHorizontal);

        if (moveHorizontal  != 0 && isOnGround)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isJumping", false);
        }
        else if (moveHorizontal == 0 && isOnGround)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isJumping", true);
        }
        
        
        //Vector2 movement = new Vector2(moveHorizontal, 0);

        // rb2d.AddForce(movement * speed);

rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        //Debug.Log(isOnGround);

        CoinCheck = Physics2D.OverlapBox(CoinCheckHitBox.position, new Vector2(CoinCheckWidth, CoinCheckHeight), 0, isCoinBox);
        if (firstCoinBoxTouch == false && CoinCheck == true)
        {
            //Debug.Log("I'm tired");

            firstCoinBoxTouch = true;

        }
        else if (CoinCheck == false)
        {
            firstCoinBoxTouch = false;
        }

        //stuff I added to flip my character
        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }
}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("CoinBox"))
        {
            other.gameObject.SetActive(false);
        }

    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
      //  float vol = Random.Range(volLowRange, volHighRange);
        //source.PlayOneShot(jumpClip);

        if (collision.collider.tag == "Ground" && isOnGround)
        {


            if (Input.GetKey(KeyCode.UpArrow))
            {
                // rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                rb2d.velocity = Vector2.up * jumpforce;


                // Audio stuff
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(jumpClip);


            }
        }

        //beginning of code to destroy player when touching Goomba
        if (collision.collider.tag == "Goomba" && isOnGround)
        {
            Destroy(gameObject);
        }
    }

}

