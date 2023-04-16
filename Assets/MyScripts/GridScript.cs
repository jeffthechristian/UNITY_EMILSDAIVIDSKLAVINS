using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public GameObject text;
    public string tagName;

    void Start() {
        text.SetActive(false);
    }

   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagName) {
            text.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == tagName) {
            text.SetActive(false);
        }
    }
}
