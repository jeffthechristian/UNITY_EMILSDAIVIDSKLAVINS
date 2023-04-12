using UnityEngine;
using UnityEngine.UI;

public class GraphicSettings : MonoBehaviour
{
    public Button lowButton;
    public Button mediumButton;
    public Button highButton;

    public Text currentGraphics;

    private void Start()
    {
        // Add listeners to the buttons
        lowButton.onClick.AddListener(SetLowQuality);
        mediumButton.onClick.AddListener(SetMediumQuality);
        highButton.onClick.AddListener(SetHighQuality);
        
        currentGraphics.text = "CURRENT GRAPHICS: HIGH"; 
        highButton.interactable = false;
        
        // Set the initial state of the buttons
        int currentQualityLevel = QualitySettings.GetQualityLevel();
        switch (currentQualityLevel)
        {
            case 0:
                lowButton.interactable = false;
                break;
            case 1:
                mediumButton.interactable = false;
                break;
            case 2:
                highButton.interactable = false;
                break;
        }
    }

    public void SetLowQuality()
    {
        QualitySettings.SetQualityLevel(3);
        lowButton.interactable = false;
        mediumButton.interactable = true;
        highButton.interactable = true;
        currentGraphics.text = "CURRENT GRAPHICS: LOW"; 
        Debug.Log("LOW");
    }

    public void SetMediumQuality()
    {
        QualitySettings.SetQualityLevel(4);
        lowButton.interactable = true;
        mediumButton.interactable = false;
        highButton.interactable = true;
        currentGraphics.text = "CURRENT GRAPHICS: MEDIUM";
        Debug.Log("MEDIUM");
    }

    public void SetHighQuality()
    {
        QualitySettings.SetQualityLevel(5);
        lowButton.interactable = true;
        mediumButton.interactable = true;
        highButton.interactable = false;
        currentGraphics.text = "CURRENT GRAPHICS: HIGH";
        Debug.Log("HIGH");
    }
}
