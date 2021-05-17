using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsUI : MonoBehaviour {
    public static InstructionsUI instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void backToMenu() {
        SceneManager.LoadScene(SceneNameConstants.menuSceneName);
    }
}