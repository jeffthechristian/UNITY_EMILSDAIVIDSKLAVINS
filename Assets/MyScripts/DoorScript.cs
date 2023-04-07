using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject closeText;
    public GameObject lockedText;
    public string requiredKey;

    public enum DoorState {Closed, Open};
    public enum DoorLock {Locked, Unlocked};
    public enum Reach {In, NotIn};
    public DoorState doorState = DoorState.Closed;
    public DoorLock doorLock = DoorLock.Locked;
    public Reach inReach = Reach.NotIn;

    void Start()
    {
        openText.SetActive(false);
        closeText.SetActive(false);
        lockedText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            if (doorState == DoorState.Closed)
            {
                if (KeyScript.HasKey(requiredKey))
                {
                    inReach = Reach.In;
                    openText.SetActive(true);
                }
                else
                {
                    inReach = Reach.In;
                    lockedText.SetActive(true);
                }
            }
            else if (doorState == DoorState.Open)
            {
                inReach = Reach.In;
                closeText.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = Reach.NotIn;
            openText.SetActive(false);
            closeText.SetActive(false);
            lockedText.SetActive(false);
        }
    }

    void Update()
    {
        if (KeyScript.HasKey(requiredKey)) {
            doorLock = DoorLock.Unlocked;
        }

            if (inReach == Reach.In && doorLock == DoorLock.Unlocked && doorState == DoorState.Closed && Input.GetButtonDown("Interact")) {
                door.SetBool("OpenDoor", true);
                door.SetBool("CloseDoor", false);
                doorState = DoorState.Open;
            }

        else if (inReach == Reach.In && doorState == DoorState.Open && Input.GetButtonDown("Interact")) {
            door.SetBool("OpenDoor", false);
            door.SetBool("CloseDoor", true);
            doorState = DoorState.Closed;
        }
    }
}
