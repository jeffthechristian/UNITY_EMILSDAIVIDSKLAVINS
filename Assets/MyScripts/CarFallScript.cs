using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFallScript : MonoBehaviour
{
    public Animator car;
    private bool shouldFall = false;
    private bool isFall = false;

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isFall)
        {
            shouldFall = true;
        }
    }

    void Update() {
        if (shouldFall) {
             car.SetBool("isNear", true);
             isFall = true;
        }
    }
}
