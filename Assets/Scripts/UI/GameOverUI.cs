using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {
    public static GameOverUI instance;

    public GameObject gameOverUIObject;

    public Text gameOverText;

    public string menuSceneName = "MainMenu";

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void endGameAtWave(int wave) {
        setWaveCount(wave);
        displayGameOver();
    }

    private void setWaveCount(int wave) {
        gameOverText.text = "You survived to wave " + wave + ".";
    }

    private void displayGameOver() {
        gameOverUIObject.SetActive(true);
    }

    public void retry() {
        GameManager.reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void menu() {
        SceneManager.LoadScene(SceneNameConstants.menuSceneName);
    }
}