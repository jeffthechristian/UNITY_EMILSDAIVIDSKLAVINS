using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public static Dictionary<string, bool> keys = new Dictionary<string, bool>();

    public string keyId;

    void Start()
    {
        keys[keyId] = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            keys[keyId] = true;
            gameObject.SetActive(false);
        }
    }

    public static bool HasKey(string keyId)
    {
        if (keys.ContainsKey(keyId))
        {
            return keys[keyId];
        }
        else
        {
            return false;
        }
    }
}
