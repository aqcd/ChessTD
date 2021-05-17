using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {
    public static MenuUI instance;
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void start() {
        GameManager.reset();
        SceneManager.LoadScene(SceneNameConstants.levelSceneName);
        Time.timeScale = 1.0f;
    }

    public void instructions() {
        SceneManager.LoadScene(SceneNameConstants.instructionsSceneName);
    }

    public void quit() {
        Debug.Log("Exiting. Bye!");
        Application.Quit();
    }
}