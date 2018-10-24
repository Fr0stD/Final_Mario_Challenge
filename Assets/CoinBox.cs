using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour {

    private AudioSource source;
    public AudioClip coinBox;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

	// Use this for initialization
	void Start () {
		
	}

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(coinBox);
            Destroy(gameObject);
        }
    }
}
