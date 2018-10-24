using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterGoombaController : MonoBehaviour {

    private Animator anim;

    public float speed;

    private bool facingRight = false;

    public LayerMask isGround;
    public LayerMask isPlayer;
    public Transform wallHitBox;
    public Transform playerHitBox;
    private bool wallHit;
    private bool playerHit;
    public float wallHitHeight;
    public float wallHitWidth;
    public float playerHitHeight;
    public float playerHitWidth;

    //audio
    private AudioSource source;
    public AudioClip deathClip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        //anim.SetBool("isDead", false);
        playerHit = false;
		
	}
	
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(speed * Time.deltaTime, 0, 0);  // walk code

        // Swap direction if hit wall
        wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);
        if (wallHit == true)
        {
            speed = speed * -1;
        }

        playerHit = Physics2D.OverlapBox(playerHitBox.position, new Vector2(playerHitWidth, playerHitHeight), 0, isPlayer);
        if (playerHit == true)
            Debug.Log("playerHit is " + playerHit);
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            Debug.Log("Got player");
        if (playerHit)
            Debug.Log("Got playerHit");

        if (collision.collider.tag == "Player" && playerHit == true)
        {
            //Audio stuf
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(deathClip);
            
            // Extra
            anim.SetBool("isDead", true);

            Debug.Log("Goobma dead");
            Destroy(gameObject, 0.25f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallHitBox.position, new Vector3(wallHitWidth, wallHitHeight, 1));

        // Extra
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(playerHitBox.position, new Vector3(playerHitWidth, playerHitHeight, 1));
    }
}
