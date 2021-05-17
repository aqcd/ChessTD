using UnityEngine;
using UnityEngine.UI;

public class WavesUI : MonoBehaviour {
    public static WavesUI instance;
    
    public Text wavesText;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void setWavesText(int wave) {
        wavesText.text = "  Wave " + wave;
    }

    public void setWavesComingText(int wave, float countdown) {
        wavesText.text = wave == 0 ? "  [F] to start" : "  Wave " + (wave + 1) + " in " + Mathf.Floor(countdown).ToString();
    }
}