using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThingsScript : MonoBehaviour
{
    public GameObject interactText;
    public Animator moveAnimation;
    public string interactTag;
    private bool inReach;
    public enum ObjectState {Closed, Open};
    public ObjectState objectState = ObjectState.Closed;    

    void Start()
    {
        interactText.SetActive(false);
        inReach = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == interactTag) {
            interactText.SetActive(true);
            inReach = true;
            Debug.Log("Entered trigger zone");
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == interactTag) {
            interactText.SetActive(false);
            inReach = false;
            Debug.Log("Went outside of trigger zone");
        }
    }
    
    void Update()
    {
        if (inReach && objectState == ObjectState.Closed && Input.GetButtonDown("Interact")) {
            moveAnimation.SetBool("isOpen", true);
            moveAnimation.SetBool("isClosed", false);
            Debug.Log("Opening way");

            Invoke("SwitchObjectState", 1f);
        }

        if (inReach && objectState == ObjectState.Open && Input.GetButtonDown("Interact")) {
            moveAnimation.SetBool("isOpen", false);
            moveAnimation.SetBool("isClosed", true);
            Debug.Log("Closing way");

            Invoke("SwitchObjectState", 1f);
        }
    }

    void SwitchObjectState() {
        if (objectState == ObjectState.Closed) {
            objectState = ObjectState.Open;
        } else {
            objectState = ObjectState.Closed;
        }
    }
}
