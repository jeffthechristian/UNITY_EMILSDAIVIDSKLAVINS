using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperScript : MonoBehaviour
{
    public GameObject interactText;
    public GameObject clue;
    public GameObject nextClue;
    private bool inReach;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = true;
            interactText.SetActive(true);
            clue.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Reach"))
        {
            interactText.SetActive(false);
            clue.SetActive(false);
            inReach = false;
        }
    }

        void Update()
    {
        if (inReach && Input.GetButtonDown("Interact")) {
            interactText.SetActive(false);
            clue.SetActive(false);
            nextClue.SetActive(true);
            QuestLogScript.cluesCount++;
            Destroy(gameObject);
        }
    }
}