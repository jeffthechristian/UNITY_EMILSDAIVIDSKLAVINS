using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public GameObject text;

    void Start() {
        text.SetActive(false);
    }

   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            text.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Player") {
            text.SetActive(false);
        }
    }
}
