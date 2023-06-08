 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 using UnityEngine.UI;

public class MainMenuButtonScript : MonoBehaviour {
    public GameObject mainMenuBlock, optionBlock, infoBlock;

    public Text currentDifficulty;

    private void Start() {
        PlayerMovement.canMove = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        optionBlock.SetActive(false);
        infoBlock.SetActive(false);
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

    public void Info() {
        mainMenuBlock.SetActive(false);
        infoBlock.SetActive(true);
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
        infoBlock.SetActive(false);
        Debug.Log("back");
    }

    public void Update() {
        if (DifficultyScript.difficulty == DifficultyScript.Difficulty.Easy) {
            currentDifficulty.text = "CURRENT DIFFICULTY: EASY";
        }
        if (DifficultyScript.difficulty == DifficultyScript.Difficulty.Average) {
            currentDifficulty.text = "CURRENT DIFFICULTY: AVERAGE";            
        }
        if (DifficultyScript.difficulty == DifficultyScript.Difficulty.Hard) {
            currentDifficulty.text = "CURRENT DIFFICULTY: HARD";            
        }
        Time.timeScale = 1f;
    }
}