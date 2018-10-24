using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;

    private Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        offset = transform.position - player.transform.position;	
        /*float tmpX = player.transform.position.x;
        float tmpY = player.transform.position.y;
        float tmpZ = player.transform.position.z;
        this.transform.position.Set(tmpX, tmpY, tmpZ);*/
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        //transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);	
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        //transform.position = new Vector3(player.po);
    }
}
