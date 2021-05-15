using UnityEngine;

public class BuildManager : MonoBehaviour {
    public static BuildManager instance;

    private Tower towerToBuild;
    
    public GameObject spawnEffect;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        towerToBuild = null;
    }

    public void setTowerToBuild(TowerEnum type) {
        towerToBuild = TowerManager.instance.getTowerFromType(type);
    }

    public Tower getTowerToBuild() {
        return towerToBuild;
    }

    public bool canBuildOnNode(NodeManager node) {
        if (towerToBuild == null) {
            return false;
        }

        return towerToBuild.getCost() <= CurrencyManager.instance.currentCurrency;
    }

    public void buildTowerOnNode(NodeManager node) {
        if (towerToBuild == null) {
            return;
        }
        
        int towerCost = towerToBuild.getCost();

        if (CurrencyManager.instance.decreaseCurrency(towerCost)) {
            GameObject towerPrefab = towerToBuild.towerPrefab;
            Transform towerTransform = towerPrefab.transform;
            Transform nodeTransform = node.transform;
            Vector3 spawnPosition = nodeTransform.position + towerTransform.position;
            Quaternion spawnRotation = nodeTransform.rotation * towerTransform.rotation;
            GameObject tower = (GameObject) Instantiate(towerPrefab, spawnPosition, spawnRotation);
            GameObject spawnEffectParticleSystem = (GameObject) Instantiate(spawnEffect, spawnPosition, spawnRotation);
            Destroy(spawnEffectParticleSystem, 1.0f);
            node.setTower(tower);
            CostManager.instance.updateCosts(towerToBuild);
        }
    }
}