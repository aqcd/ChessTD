using UnityEngine;

class HostileTowerManager : MonoBehaviour {
    public static HostileTowerManager instance;
    public static int interval = 2;
    public Tower hostileKnightTower;
    public Tower hostileBishopTower;
    public Tower hostileRookTower;
    public Tower hostileQueenTower;

    private float difficulty = 0.0f;
    
    public GameObject spawnEffect;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void spawnHostileTower() {
        difficulty = Mathf.Min(difficulty + 1, 16);
        if (GameManager.emptyNodes.Count < 1) {
            return;
        }

        NodeManager node = null;
        do {
            node = (NodeManager) GameManager.emptyNodes[Random.Range(0, GameManager.emptyNodes.Count)];
        } while (node == GameManager.activeNodeManager);
        spawnHostileTowerOnNode(node);
    }

    private void spawnHostileTowerOnNode(NodeManager node) {
        if (node == null) {
            return;
        }

        Tower towerToSpawn = getTower();
        GameObject towerPrefab = towerToSpawn.towerPrefab;
        Transform towerTransform = towerPrefab.transform;
        Transform nodeTransform = node.transform;
        Vector3 spawnPosition = nodeTransform.position + towerTransform.position;
        Quaternion spawnRotation = nodeTransform.rotation * towerTransform.rotation;
        GameObject tower = (GameObject) Instantiate(towerPrefab, spawnPosition, spawnRotation);
        GameObject spawnEffectParticleSystem = (GameObject) Instantiate(spawnEffect, spawnPosition, spawnRotation);
        Destroy(spawnEffectParticleSystem, 1.0f);
        node.setTower(tower);
    }

    private Tower getTower() {
        if (Random.Range(0.0f, 16.0f) <= difficulty) {
            return hostileQueenTower;
        }
        if (Random.Range(0.0f, 16.0f) <= difficulty) {
            return hostileRookTower;
        }

        return Random.Range(0, 2) == 0 ? hostileBishopTower : hostileKnightTower;
    }
}