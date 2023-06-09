using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private bool inReach;
    public GameObject interactText;
    public GameObject soundEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach")) {
            inReach = true;
            interactText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)  {
        if (other.CompareTag("Reach")) {
            interactText.SetActive(false);
            inReach = false;
        }
    }

    void Update() {
        if (inReach && Input.GetButtonDown("Interact")) {
            interactText.SetActive(false);
            PlayerHealthScript.coinCount += 100;
            soundEffect.SetActive(true);
            Destroy(gameObject);
        }
    }
}
