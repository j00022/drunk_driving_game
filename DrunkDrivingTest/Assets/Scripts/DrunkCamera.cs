using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkCamera : MonoBehaviour {

    private float xorigin, yorigin;
    public GameObject player;

    // Use this for initialization
    void Start() {
        xorigin = player.transform.position.x - 1;
        yorigin = player.transform.position.y - 0.5f;
    }

    // Update is called once per frame
    void Update() {
        xorigin = player.transform.position.x - 1;
        yorigin = player.transform.position.y - 0.5f;
        transform.position = new Vector3(Mathf.PingPong(Time.time, 2f) + xorigin, Mathf.PingPong(Time.time, 1.4f) + yorigin, -10);
    }

}