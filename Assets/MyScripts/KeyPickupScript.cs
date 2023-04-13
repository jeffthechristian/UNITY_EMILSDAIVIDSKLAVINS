using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickupScript : MonoBehaviour
{
    public string keyName;
    public GameObject interactText;
    private bool inReach;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Reach")) {
            inReach = true;
            interactText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Reach")) {
            interactText.SetActive(false);
            inReach = false;
        }
    }

        void Update() {
        if (inReach && Input.GetButtonDown("Interact")) {
            KeyScript.keys[keyName] = true;
            interactText.SetActive(false);
            Destroy(gameObject);
        }
    }
}
