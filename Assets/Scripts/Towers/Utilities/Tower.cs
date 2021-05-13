using UnityEngine;

[System.Serializable]
public class Tower {
    public GameObject towerPrefab;
    public int baseCost;
    public int costIncrement = 0;

    public int getCost() {
        return baseCost + costIncrement;
    }
}