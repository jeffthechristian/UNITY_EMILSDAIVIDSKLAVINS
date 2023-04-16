using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFallScript : MonoBehaviour {
    public Animator cross;
    public bool inReach;
    private bool isFall = false; 
    public GameObject interactText;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Reach" && !isFall) {
            interactText.SetActive(true);
            inReach = true;
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
            cross.SetBool("isFall", true);
            isFall = true;
            TraderQuest.crossDestroyed = true;
        }
    }
}
