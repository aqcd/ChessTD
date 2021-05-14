using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {
    public static LivesUI instance;

    public Text livesText;
    
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void setLivesText(string text) {
        livesText.text = text;
    }
}