using UnityEngine;

[System.Serializable]
public class Tower {
    public TowerEnum type;
    public GameObject towerPrefab;
    public int baseCost;
    public int costIncrement = 0;

    public int maxLevel;

    public int getBaseCost() {
        return baseCost;
    }

    public int getCost() {
        return baseCost + costIncrement;
    }

    public int getMaxLevel() {
        return maxLevel;
    }
}