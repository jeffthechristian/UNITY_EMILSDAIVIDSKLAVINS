using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurchGhostScript : MonoBehaviour
{
    public GameObject ghost;
    public GameObject shh;
    public GameObject whisper;
    public GameObject disappearEffect;
    private bool isSpooky;
    private bool isScary;

    void Start()
    {
        ghost.SetActive(false);
        shh.SetActive(false);
        disappearEffect.SetActive(false);
        whisper.SetActive(true);
        isSpooky = false;
        isScary = false;
    }

    void Update()
    {
        if (QuestLogScript.cluesCount == 3 && !isScary)
        {
            ghost.SetActive(true);
            isSpooky = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (isSpooky)
        {
            isScary = true;
            ghost.SetActive(false);
            shh.SetActive(true);
            whisper.SetActive(false);
            disappearEffect.SetActive(true);
        }
    }
}
