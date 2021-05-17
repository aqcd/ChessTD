using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
    public Transform spawnLocation;

    public float maxCountdownTimer;
    private float countdown;
    public float intrawaveCountdown;
    private bool isSpawning = false;

    private List<Wave> waves;
    private int numDistinctWaves = 24;

    public bool started = false;

    void Start() {
        initialiseWaves();
    }

    void Update() {
        setCountdownText();

        if (Input.GetKeyDown(KeyCode.F) && !started) {
            countdown = 0.0f;
            started = true;
        }

        if (!started) {
            return;
        }


        if (!isSpawning) {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0.0f) {
            spawnWave();
            resetCountdown();
        }
    }

    void initialiseWaves() {
        waves = new List<Wave>();
        for (int i = 0; i < numDistinctWaves; i++) {
            waves.Add(new Wave(
                Mathf.Min(8, 4 + i % 4),
                Mathf.Min(2, 0 + i / 4),
                Mathf.Min(2, 0 + i / 4),
                Mathf.Min(2, 0 + i / 8),
                Mathf.Min(1, 0 + i / 12),
                Mathf.Min(1, 0 + i / 12)
            ));
        }
    }

    void spawnWave() {
        incrementWaveNumber();
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies() {
        isSpawning = true;

        List<EnemyEnum> waveArray = waves[GameManager.currentWave % 24].getAsList();
        int healthMultiplier = 2 * (GameManager.currentWave / numDistinctWaves) + 1;
        EnemyPrefabs enemyPrefabsInstance = EnemyPrefabs.instance;

        for(int i = 0; i < waveArray.Count; i++) {
            GameObject enemy = (GameObject) Instantiate(enemyPrefabsInstance.getEnemyPrefabFromType(waveArray[i]), spawnLocation.position, spawnLocation.rotation);
            
            BaseHealth healthComponent = enemy.GetComponent<BaseHealth>();
            if (healthComponent != null && healthMultiplier > 1) {
                healthComponent.multiplyHealth(healthMultiplier);
            }

            yield return new WaitForSeconds(intrawaveCountdown);
        }

        isSpawning = false;
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
        if (GameManager.currentWave % HostileTowerManager.instance.interval == 0) {
            HostileTowerManager.instance.spawnHostileTower();
        }
    }

    void resetCountdown() {
        countdown = maxCountdownTimer;
    }
}
