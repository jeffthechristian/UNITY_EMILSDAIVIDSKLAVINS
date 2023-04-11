using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScript : MonoBehaviour {
    public enum Difficulty  {Easy, Average, Hard};
    public static Difficulty difficulty = Difficulty.Average;

    public static float playerHealth;
    public static float enemyWalkSpeed, enemyChaseSpeed;

    void Start() {
        switch (difficulty) {
            case Difficulty.Easy:
                // code for Easy difficulty
                playerHealth = 6f;
                enemyWalkSpeed = 3f;
                enemyChaseSpeed = 5.5f;
                break;

            case Difficulty.Average:
                // code for Average difficulty
                playerHealth = 3f;
                enemyWalkSpeed = 3f;
                enemyChaseSpeed = 5.8f;
                break;

            case Difficulty.Hard:
                // code for Hard difficulty
                playerHealth = 1f;
                enemyWalkSpeed = 3f;
                enemyChaseSpeed = 6.2f;
                break;

            default:
                Debug.LogError("Unknown difficulty level: " + difficulty);
                break;
        }
    }
}
