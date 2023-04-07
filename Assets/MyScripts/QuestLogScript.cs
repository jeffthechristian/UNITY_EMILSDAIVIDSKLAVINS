using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuestLogScript : MonoBehaviour {
    
    public List<string> stringList = new List<string>();
    public GameObject text;

    void Start() {
        stringList.Add("- Investigate the area");

        // Remove the specified string from the list
        //string stringToRemove = "World";
        //stringList.Remove(stringToRemove);
    }

    void Update() {
        

        string concatenatedString = string.Join("\n", stringList.ToArray());
        text.GetComponent<Text>().text = concatenatedString;
    }
}
