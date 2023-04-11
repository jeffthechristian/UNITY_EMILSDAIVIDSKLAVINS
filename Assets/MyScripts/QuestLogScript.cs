using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuestLogScript : MonoBehaviour {
    
    public List<string> stringList = new List<string>();
    public List<string> foundCluesList = new List<string>();
    public GameObject text;
    public GameObject text2;
    public static int cluesCount;
    private int oldCluesCount;

    void Start() {
        stringList.Add("- Investigate the area");
        oldCluesCount = cluesCount;

        // Remove the specified string from the list
        //string stringToRemove = "World";
        //stringList.Remove(stringToRemove);
    }

    void Update() {
        if (Input.GetKey(KeyCode.Tab))
        {
            // Enable the game objects
            text.SetActive(true);
            text2.SetActive(true);
        }
        else
        {
            // Disable the game objects
            text.SetActive(false);
            text2.SetActive(false);
        }

        if (oldCluesCount < cluesCount) {
            bool foundCluesString = false;

            // Search for the "Clues found" string in the list
            for (int i = 0; i < stringList.Count; i++) {
                if (stringList[i].StartsWith("- Clues found:")) {
                    // Update the existing string
                    stringList[i] = "- Clues found: " + cluesCount + "/10";
                    foundCluesString = true;

                    // If the count is 10, remove the string from the list and add it to the foundCluesList
                    if (cluesCount == 10) {
                        foundCluesList.Add(stringList[i]);
                        stringList.RemoveAt(i);
                    }

                    break;
                }
            }

            // If the "Clues found" string wasn't found, add it to the list
            if (!foundCluesString) {
                stringList.Add("- Clues found: " + cluesCount + "/10");
            }

            // Update the old clues count
            oldCluesCount = cluesCount;
        }

        string concatenatedString = string.Join("\n", stringList.ToArray());
        text.GetComponent<Text>().text = concatenatedString;

        string concatenatedString2 = string.Join("\n", foundCluesList.ToArray());
        text2.GetComponent<Text>().text = concatenatedString2;
    }
}