using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {
    public static TowerManager instance;
    public Tower[] towers;

    private Dictionary<TowerEnum, Tower> towerDictionary = new Dictionary<TowerEnum, Tower>();

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public Tower getTowerFromType(TowerEnum type) {
        populateDictionaryIfEmpty();
        
        return towerDictionary[type];
    }

    public int getMaxLevelFromType(TowerEnum type) {
        populateDictionaryIfEmpty();
        
        return towerDictionary[type].getMaxLevel();
    }

    public int getBaseCostFromType(TowerEnum type) {
        populateDictionaryIfEmpty();
        
        return towerDictionary[type].getBaseCost();
    }

    public int getCostFromType(TowerEnum type) {
        populateDictionaryIfEmpty();
        
        return towerDictionary[type].getCost();
    }

    private void populateDictionaryIfEmpty() {
        if (towerDictionary.Count == 0) {
            for (int i = 0; i < towers.Length; i++) {
                towerDictionary.Add(towers[i].type, towers[i]);
            }
        }
    }
}