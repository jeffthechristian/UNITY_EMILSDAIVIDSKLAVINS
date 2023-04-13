using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFallScript : MonoBehaviour {
    public Animator car;
    public GameObject enemy;
    public GameObject sound;
    private bool shouldFall = false;
    private bool isFall = false; 

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && !isFall) {
            shouldFall = true;
        }
    }

    void Update() {
        if (shouldFall) {
            car.SetBool("isNear", true);
            isFall = true;
            StartCoroutine(DisappearEnemy());
            StartCoroutine(PlaySound());
        }
    }

    IEnumerator DisappearEnemy() {
        yield return new WaitForSeconds(2f);
        enemy.SetActive(false);
    }

    IEnumerator PlaySound() {
        yield return new WaitForSeconds(0.7f);
        sound.SetActive(true);
    }
}
