using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float newX = transform.position.x + 2.0f;
        this.transform.position.Set(
            newX,
            transform.position.y,
            transform.position.z
            );
	}
}
