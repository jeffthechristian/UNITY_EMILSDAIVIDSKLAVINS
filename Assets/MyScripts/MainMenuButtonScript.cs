 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour {

    private void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void Quit() {
        Application.Quit();
    }
}