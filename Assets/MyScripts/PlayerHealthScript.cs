using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour {
    public float cooldown = 2f;
    private float currentHealth;
    public GameObject deathText;
    public Text healthText;
    private bool canTakeDamage = true;

    void Start() {
        deathText.SetActive(false);
        healthText.text = "HEALTH: " + currentHealth + "HP";
        currentHealth = DifficultyScript.playerHealth;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("EnemyAttack") && canTakeDamage) {
            Debug.Log("Current health" + currentHealth);
            currentHealth--;
            canTakeDamage = false;
            StartCoroutine(Cooldown());
        }
    }

    void Update() {
        if (currentHealth <= 0f) {
            Time.timeScale = 0f;
            deathText.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log(currentHealth);
        }
        healthText.text = "HEALTH: " + currentHealth + "HP";
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(cooldown);
        canTakeDamage = true;
    }
}