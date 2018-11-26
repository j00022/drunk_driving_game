using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour {
    public void LoadMenu() {
        SceneManager.LoadScene(1);
    }
    public void LoadCredits() {
        SceneManager.LoadScene(3);
    }
    public void LoadControls() {
        SceneManager.LoadScene(2);
    }
    public void LoadLv1Splash() {
        PlayerPrefs.DeleteKey("1");
        SceneManager.LoadScene(4);
    }
    public void LoadLv1() {
        SceneManager.LoadScene(5);
    }
    public void LoadLv2Splash() {
        PlayerPrefs.DeleteKey("2");
        SceneManager.LoadScene(6);
    }
    public void LoadLv2() {
        SceneManager.LoadScene(7);
    }
    public void LoadFin() {
        SceneManager.LoadScene(8);
    }
}
