using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour {

    public float delay;
    public int scene;
    public GameObject obj;
    public Score score;
    public string level;

	// Update is called once per frame
	void Update () {
        if (delay > 3)
            OnTriggerEnter2D(obj.GetComponent<Collider2D>());
        else {
            delay -= Time.deltaTime;
            if (delay <= 0)
                SceneManager.LoadScene(scene);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Car") {
            PlayerPrefs.SetFloat(level, score.getScore());
            delay = 2;
            delay -= Time.deltaTime;
            if (delay <= 0) {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
