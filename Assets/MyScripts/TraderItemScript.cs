using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderItemScript : MonoBehaviour {
    public GameObject canAfford;
    public GameObject cantAfford;
    public string keyName;
    public int price;
    private bool inReach;
    public GameObject soundEffect;

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Reach") && PlayerHealthScript.coinCount >= price) {
            inReach = true;
            canAfford.SetActive(true);
        } else {
            cantAfford.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)  {
            canAfford.SetActive(false);
            cantAfford.SetActive(false);
            inReach = false;
    }

    void Update() {
        if (inReach && Input.GetButtonDown("Interact") && PlayerHealthScript.coinCount >= price && PlayerHealthScript.currentHealth < 5) {
            canAfford.SetActive(false);
            KeyScript.keys[keyName] = true;
            PlayerHealthScript.coinCount -= price;
            PlayerHealthScript.currentHealth +=1;
            soundEffect.SetActive(true);
            Destroy(gameObject);
        }
    }
}
