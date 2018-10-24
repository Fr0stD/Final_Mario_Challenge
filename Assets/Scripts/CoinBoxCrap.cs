using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBoxCrap : MonoBehaviour {

    public int numberOfCoins;
    private bool playerCheck;
    public float playerCheckWidth;
    public float playerCheckHeight;
    public Transform playerCheckHitbox;
    public LayerMask isPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       // playerCheck = Physics2D.OverlapBox(playerCheckHitbox.position, new Vector2(playerCheckWidth, playerCheckHeight), 0, isPlayer);
		
	}
}
