using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {
    public Transform enemyPrefab;
    public Transform spawnLocation;

    private float maxCountdownTimer = 1.0f;//4.0f;
    private float countdown = 4.0f;
    private float intrawaveCountdown = 0.25f;
    private bool isSpawning = false;

    void Update() {
        if (!isSpawning) {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0.0f) {
            spawnWave();
            resetCountdown();
        }

        setCountdownText();
    }

    void spawnWave() {
        incrementWaveNumber();
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies() {
        isSpawning = true;

        var numEnemies = 1;// GameManager.currentWave;

        for(int i = 0; i < numEnemies; i++) {
            spawnEnemy();
            yield return new WaitForSeconds(intrawaveCountdown);
        }

        isSpawning = false;
    }

    void spawnEnemy() {
        Instantiate(enemyPrefab, spawnLocation.position, spawnLocation.rotation);
    }

    void setCountdownText() {
        if (isSpawning) {
            WavesUI.instance.setWavesText(GameManager.currentWave);
        } else {
            WavesUI.instance.setWavesComingText(GameManager.currentWave, countdown);
        }
    }

    void incrementWaveNumber() {
        GameManager.currentWave++;
        if (GameManager.currentWave % HostileTowerManager.interval == 0) {
            HostileTowerManager.instance.spawnHostileTower();
        }
    }

    void resetCountdown() {
        countdown = maxCountdownTimer;
    }
}
