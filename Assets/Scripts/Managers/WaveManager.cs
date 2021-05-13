using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {
    public Transform enemyPrefab;
    public Transform spawnLocation;

    private float maxCountdownTimer = 4.0f;
    private float countdown = 4.0f;
    private float intrawaveCountdown = 0.25f;
    private int waveNumber = 0;
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

        var numEnemies = waveNumber;

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
            WavesUI.instance.setWavesText(waveNumber);
        } else {
            WavesUI.instance.setWavesComingText(waveNumber, countdown);
        }
    }

    void incrementWaveNumber() {
        waveNumber++;
        if (waveNumber % HostileTowerManager.interval == 0) {
            HostileTowerManager.instance.spawnHostileTower();
        }
    }

    void resetCountdown() {
        countdown = maxCountdownTimer;
    }
}
