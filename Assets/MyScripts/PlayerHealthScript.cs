using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{
    public int maxHealth = 10;
    public float cooldown = 2f;

    public GameObject deathText;
    public Text healthText;

    private int currentHealth;
    private bool canTakeDamage = true;

    void Start()
    {
        currentHealth = maxHealth;
        deathText.SetActive(false);
        healthText.text = "HEALTH: " + maxHealth + "HP";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyAttack") && canTakeDamage)
        {
            Debug.Log("Current health" + currentHealth);
            currentHealth--;
            canTakeDamage = false;
            StartCoroutine(Cooldown());
        }
    }

    void Update() {
        if (currentHealth <= 0) {
            Time.timeScale = 0f;
            deathText.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        healthText.text = "HEALTH: " + currentHealth + "HP";
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canTakeDamage = true;
    }
}