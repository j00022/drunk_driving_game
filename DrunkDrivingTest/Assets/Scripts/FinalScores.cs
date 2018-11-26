using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScores : MonoBehaviour {

    public Text sober, drunk;

	// Use this for initialization
	void Start () {
        sober.text = PlayerPrefs.GetFloat("1").ToString();
        drunk.text = PlayerPrefs.GetFloat("2").ToString();
    }
}
