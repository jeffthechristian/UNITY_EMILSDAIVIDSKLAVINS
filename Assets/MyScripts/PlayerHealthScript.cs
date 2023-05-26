using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour {
    public float cooldown = 2f;
    public static float currentHealth;
    public RawImage damageEffectImage;
    public AudioClip damageAudio;
    public GameObject deathAudio;
    private AudioSource audioSource;
    public GameObject deathText;
    public Text healthText;
    private bool canTakeDamage = true;

    public Text coinText;
    public static int coinCount;  

    void Start() {
        deathText.SetActive(false);
        healthText.text = "HEALTH: " + currentHealth + "HP";
        currentHealth = DifficultyScript.playerHealth;
        damageEffectImage.color = Color.clear;
        damageEffectImage.enabled = true;
        audioSource = GetComponent<AudioSource>();
        deathAudio.SetActive(false);
    }

    void OnTriggerStay(Collider other) {
        if (other.CompareTag("EnemyAttack") && canTakeDamage) {
            Debug.Log("Current health" + currentHealth);
            currentHealth--;
            canTakeDamage = false;
            StartCoroutine(Cooldown());
            StartCoroutine(ShowDamageEffect());
            audioSource.PlayOneShot(damageAudio);
        }
    }

    void Update() {
        if (currentHealth <= 0f) {
            deathAudio.SetActive(true);
            Time.timeScale = 0f;
            deathText.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log(currentHealth);
        }
        healthText.text = "HEALTH: " + currentHealth + "HP";
        coinText.text = "MONEY: " + coinCount;

        if (Time.timeScale == 0f) {
            damageEffectImage.enabled = false;
        } else {
            damageEffectImage.enabled = true;
        }
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(cooldown);
        canTakeDamage = true;
    }

    IEnumerator ShowDamageEffect() {
        if (currentHealth > 0f) {
            damageEffectImage.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            damageEffectImage.color = Color.clear;
        }
    }
}
