using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConeController : MonoBehaviour {

    private float _score;
    public Text scoreText;
    public Score getScore;
    private bool _touched;
    public SpriteRenderer spriteRenderer;
    public Sprite darker;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Car" && _touched == false) {
            _touched = true;
            getScore.coneHit();
            _score = getScore.getScore();
            scoreText.text = "Score: " + _score.ToString("000");
            spriteRenderer.sprite = darker;
        }
    }
	// Use this for initialization
	void Start () {
        _touched = false;
	}
}
