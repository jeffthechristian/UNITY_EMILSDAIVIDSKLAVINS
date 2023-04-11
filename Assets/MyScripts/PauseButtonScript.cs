 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;

public class PauseButtonScript : MonoBehaviour {

    public GameObject pauseText;

    public void MainMenu() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

        QuestLogScript.cluesCount = 0;
        KeyScript.keys.Clear();
    }

    public void Resume() {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseText.SetActive(false);
    }

    public void Quit() {
        Application.Quit();
    }
}