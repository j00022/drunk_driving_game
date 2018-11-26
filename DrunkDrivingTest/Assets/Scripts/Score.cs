using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public float _score;
    public float getScore() {
        return _score;
    }
    public void coneHit() {
        _score--;
    }

	// Use this for initialization
	void Start () {
        _score = 100;
	}
}
