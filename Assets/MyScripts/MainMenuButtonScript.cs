 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour {
    public GameObject mainMenuBlock, optionBlock;


    private void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        optionBlock.SetActive(false);
        mainMenuBlock.SetActive(true);
        Debug.Log("Start");
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        Debug.Log("StartGame");
    }

    public void Quit() {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Options() {
        optionBlock.SetActive(true);
        mainMenuBlock.SetActive(false);
        Debug.Log("options");
    }

    public void EasyDifficulty() {
        DifficultyScript.difficulty = DifficultyScript.Difficulty.Easy;
        Debug.Log("easy");
    }

    public void AverageDifficulty() {
        DifficultyScript.difficulty = DifficultyScript.Difficulty.Average;
        Debug.Log("avg");
    }

    public void HardDifficulty() {
        DifficultyScript.difficulty = DifficultyScript.Difficulty.Hard;
        Debug.Log("hard");
    }

    public void GoBack() {
        mainMenuBlock.SetActive(true);
        optionBlock.SetActive(false);
        Debug.Log("back");
    }

    public void Update() {
        Time.timeScale = 1f;
    }
}