using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //transform.up = player.transform.up; //Rotate camera with car
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref velocity, 0.5f); //Move camera with car
    }
}
