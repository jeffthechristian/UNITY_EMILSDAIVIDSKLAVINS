using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraderQuest : MonoBehaviour {
    public GameObject questText;
    public GameObject traderText;
    public GameObject questFinishedText;
    public GameObject barnKey;
    public string tagName;
    public static bool crossDestroyed = false;
    public static bool traderQuestInProgress = false;
    public static bool traderQuestFinished = false;
    public bool inReach = false;

    void Start() {
        questText.SetActive(false);
        barnKey.SetActive(false);
    }

   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagName && !crossDestroyed && !traderQuestFinished) {
            questText.SetActive(true);
            inReach = true;
        }

        if (other.gameObject.tag == tagName && crossDestroyed && !traderQuestFinished) {
            questFinishedText.SetActive(true);
            inReach = true;
        }

        if (other.gameObject.tag == tagName && crossDestroyed && traderQuestFinished) {
            traderText.SetActive(true);
            inReach = true;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == tagName) {
            questText.SetActive(false);
            traderText.SetActive(false);
            questFinishedText.SetActive(false);
            inReach = false;
        }
    }

    void Update() {
        if (inReach && !crossDestroyed && Input.GetButtonDown("Interact")) {
            traderQuestInProgress = true;
            questText.SetActive(false);
        }

        if (inReach && crossDestroyed && Input.GetButtonDown("Interact")) {
            traderQuestFinished = true;
            questFinishedText.SetActive(false);
            barnKey.SetActive(true);
        }
    }
}

