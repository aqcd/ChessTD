using UnityEngine;

class EnemyDropManager : MonoBehaviour {
    public static EnemyDropManager instance;

    public float deviationRange;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    public void handleDrops(GameObject enemy) {
        EnemyDetails enemyDetailsComponent = enemy.GetComponent<EnemyDetails>();

        if (enemyDetailsComponent == null) {
            return;
        }

        int numCoins = Random.Range(enemyDetailsComponent.minCoinDrop, enemyDetailsComponent.maxCoinDrop);
        bool lifeDrop = Random.Range(0.0f, 1.0f) < enemyDetailsComponent.livesDropChance;

        Debug.Log(numCoins);

        for (int i = 0; i < numCoins; i++) {
            GameObject coin = CoinObjectPool.instance.getPooledObject();
            coin.transform.position = coin.transform.position + enemy.transform.position;

            BaseDrop baseDropComponent = coin.GetComponent<BaseDrop>();
            if (baseDropComponent != null) {
                baseDropComponent.setTarget(coin.transform.position + getRandomDeviation());
            }
        }

        if (lifeDrop) {
            GameObject life = LivesObjectPool.instance.getPooledObject();
            life.transform.position = life.transform.position + enemy.transform.position;

            BaseDrop baseDropComponent = life.GetComponent<BaseDrop>();
            if (baseDropComponent != null) {
                baseDropComponent.setTarget(life.transform.position + getRandomDeviation());
            }
        }
    }

    private Vector3 getRandomDeviation() {
        return new Vector3(Random.Range(0.0f, deviationRange), 0, Random.Range(0.0f, deviationRange));
    }
}