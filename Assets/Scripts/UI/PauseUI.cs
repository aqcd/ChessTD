using UnityEngine;

public class PauseUI : MonoBehaviour {
    public static PauseUI instance;

    public GameObject pauseUIObject;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void toggle() {
        if (GameManager.isGameActive) {
            pause();
        } else {
            resume();
        }
        GameManager.isGameActive = !GameManager.isGameActive;
    }

    public void pause() {
        pauseUIObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void resume() {
        Time.timeScale = 1.0f;
        pauseUIObject.SetActive(false);
    }
}