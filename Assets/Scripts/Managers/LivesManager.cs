using UnityEngine;

public class LivesManager : MonoBehaviour {
    public static LivesManager instance;

    public static int lives = 1;
    public int initialLives;

    private bool isGameOver = false;
    
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        lives = initialLives;
    }

    public void incrementLives() {
        lives++;
        updateUI();
    }

    public void decrementLives() {
        lives--;
        checkGameOver();
        DamageUI.instance.damageTaken();
        updateUI();
    }

    private void updateUI() {
        LivesUI.instance.setLivesText("  Lives: " + lives);
    }

    private void checkGameOver() {
        if (lives <= 0 && !isGameOver) {
            isGameOver = true;
            GameOverUI.instance.endGameAtWave(GameManager.currentWave);
        }
    }
}