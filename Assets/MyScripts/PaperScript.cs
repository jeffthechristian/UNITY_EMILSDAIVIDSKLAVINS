using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperScript : MonoBehaviour
{
    public GameObject interactText;
    private bool inReach;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = true;
            interactText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Reach"))
        {
            interactText.SetActive(false);
            inReach = false;
        }
    }

        void Update()
    {
        if (inReach && Input.GetButtonDown("Interact")) {
            interactText.SetActive(false);
            QuestLogScript.cluesCount++;
            Destroy(gameObject);
        }
    }
}