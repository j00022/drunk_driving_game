using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlocker : MonoBehaviour {

    private bool _touched;
    public GameObject blockade;

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Car" && _touched == false) {
            _touched = true;
            Destroy(blockade);
        }
    }
    // Use this for initialization
    void Start() {
        _touched = false;
    }
}