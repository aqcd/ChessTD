using UnityEngine;

public class LivesManager : MonoBehaviour {
    public static LivesManager instance;

    public static int lives = 1;
    public int initialLives;

    public float invulPeriod;

    private float currentInvulPeriod;

    private bool isGameOver = false;
    
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        lives = initialLives;
        currentInvulPeriod = 0;
    }

    public void Update() {
        if (currentInvulPeriod > 0) {
            currentInvulPeriod -= Time.deltaTime;
        }
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

    public void decrementLivesWithInvul() {
        if (currentInvulPeriod > 0) {
            return;
        }
        decrementLives();
        currentInvulPeriod = invulPeriod;
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