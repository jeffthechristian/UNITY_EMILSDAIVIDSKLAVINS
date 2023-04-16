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
        stringList.Add("- Follow the bottles that your wife left behind");
        oldCluesCount = cluesCount;
    }

    void Update() {
        if (Input.GetKey(KeyCode.Tab))
        {
            text.SetActive(true);
            text2.SetActive(true);
        }
        else
        {
            text.SetActive(false);
            text2.SetActive(false);
        }

        if (1 == cluesCount && stringList.Contains("- Follow the bottles that your wife left behind")) {
            stringList.RemoveAt(0);
            foundCluesList.Add("- Follow the bottles that your wife left behind");
        }

        if (oldCluesCount < cluesCount) {
            bool foundCluesString = false;

            // Search for the "Clues found" string in the list
            for (int i = 0; i < stringList.Count; i++) {
                if (stringList[i].StartsWith("- Clues found:")) {
                    // Update the existing string
                    stringList[i] = "- Clues found: " + cluesCount + "/10 \n" + "     - " + GetNextString();
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
                stringList.Add("- Clues found: " + cluesCount + "/10 \n" + "     - " + GetNextString());
            }

            // Update the old clues count
            oldCluesCount = cluesCount;
        }

        if (TraderQuest.traderQuestInProgress && !stringList.Contains("- Destroy the alien cross to get the key to the barn")) {
            stringList.Add("- Destroy the alien cross to get the key to the barn");
        }

        if (TraderQuest.traderQuestFinished) {
            for (int j = 0; j <stringList.Count; j++) {
                if (stringList[j].StartsWith("- Destroy the alien cross to get the key to the barn") && !foundCluesList.Contains("- Destroy the alien cross to get the key to the barn")) {
                    foundCluesList.Add(stringList[j]);  
                }

                if (stringList[j].StartsWith("- Destroy the alien cross to get the key to the barn")) {
                    stringList.RemoveAt(j);
                }
                
            }
        }

        string concatenatedString = string.Join("\n", stringList.ToArray());
        text.GetComponent<Text>().text = concatenatedString;

        string concatenatedString2 = string.Join("\n", foundCluesList.ToArray());
        text2.GetComponent<Text>().text = concatenatedString2;
    }

    string[] sequenceStrings = {
        "I'm not the way you came before, \n       But you'll find your next stop with this lore. \n       Past the cabin to the right you'll go, \n       And then walk straight, don't be slow. \n       Keep your pace until you see, \n       A greenhouse, where you'll soon be.", 
        "To reach the church, you must retrace, \n       The steps you took to reach this place. \n       Back the way you came, without a fuss, \n       But don't take the path that caused your initial rush. \n       Instead, look for a new path and you will see, \n       The way to the church, as plain as can be. \n       Keep walking straight, and don't you stray, \n       Until the sound of the bell leads the way.", 
        "To find your way, just turn around, \n       And follow the path you first found. \n       Keep walking until you see, \n       A muddy car, where you should be. \n       From there, take a right and walk on, \n       Until you see a hill, not long gone. \n       Red flowers bloom at the top, \n       Climb up the hill, don't make it stop.", 
        "To find your way, go back to the car, \n       And turn left, it won't be far. \n       Then take a right and follow the track, \n       Don't look back, don't turn back. \n       At the end of the path, you'll see, \n       A guard house, where you'll need to be.", 
        "Behind the guard house, there lies a way, \n       Through the woods, you'll need to stray. \n       Keep walking straight, without delay, \n       Until a hill with blue flowers comes your way. \n       Climb up that hill, and don't you tire, \n       A radio tower awaits, higher and higher.",
        "From the hill with the radio tower so tall, \n       Back to the greenhouse, you'll need to recall. \n       Nearby, a two-story brick house awaits, \n       Follow the path, and don't hesitate. \n       It won't be long until you see it clear, \n       And inside the house, the answer may appear.",
        "Between the barn and greenhouse, there's a way, \n       Through the woods, you'll need to stray. \n       Keep walking straight, don't you fret, \n       Until a hill with purple flowers, you'll get. \n       Climb up that hill, and don't you lag, \n       A cross awaits you, like an old tag.",
        "From the hill with the cross so high, \n       Turn back and to the barn nearby. \n       No need to wander, no need to roam, \n       Just head towards the barn and you're home.",
        "You've come so far, through woods and fields, \n       The final destination, your victory yields. \n       From the path that led you to the kiosk old, \n       Take the right path, be brave and bold. \n       Through the woods and up the hill, \n       Keep climbing, with strong will. \n       Until you reach a clearing bright, \n       And there behold a wonderful sight. \n       A pond so clear, a sight to see, \n       The final destination, where you'll be.",
        "I sense a shadow lurking near, unsure of where to go from here, \n       Into the woods I wander lost, consumed by all my inner fears. \n\n       I hope you'll find me ere too long, before this darkness claims me strong, \n       My birthday surprise a foolish game, has brought us both to suffer pain. \n\n       I pray my selfishness you'll forgive, and in your heart I'll ever live, \n       But if I fall and can't be saved, please promise me you'll not deprave. \n\n       For in my heart I hold you dear, and in your arms I've naught to fear, \n       So find me soon and end this plight, and let us chase away this night."};
    int currentStringIndex = 0;

    string GetNextString() {
        string nextString = sequenceStrings[currentStringIndex];
        currentStringIndex++;
        if (currentStringIndex >= sequenceStrings.Length) {
            currentStringIndex = 0;
        }
        return nextString;
    }
}