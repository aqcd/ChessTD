using UnityEngine;

public class BuildManager : MonoBehaviour {
    public static BuildManager instance;
    public Tower knightTower;
    public Tower bishopTower;
    public Tower rookTower;
    public Tower queenTower;
    public Tower blockTower;

    private Tower towerToBuild;
    private TowerEnum towerToBuildType;
    
    public GameObject spawnEffect;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        towerToBuild = null;
    }

    private void populateCosts() {

    }

    public void setTowerToBuild(TowerEnum type) {
        towerToBuildType = type;

        switch(type) {
            case TowerEnum.KNIGHT:
                towerToBuild = knightTower;
                break;
            case TowerEnum.BISHOP:
                towerToBuild = bishopTower;
                break;
            case TowerEnum.ROOK:
                towerToBuild = rookTower;
                break;
            case TowerEnum.QUEEN:
                towerToBuild = queenTower;
                break;
            case TowerEnum.BLOCK:
                towerToBuild = blockTower;
                break;
            default:
                break;
        }
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
            CostManager.instance.updateCosts(towerToBuild, towerToBuildType);
        }
    }
}