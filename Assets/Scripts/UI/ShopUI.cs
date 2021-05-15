using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour {
    public static ShopUI instance;

    public TowerCost[] towerCosts;

    private Dictionary<TowerEnum, Text> towerCostDictionary = new Dictionary<TowerEnum, Text>();

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void setCost(TowerEnum type, int cost) {
        if (towerCostDictionary.Count == 0) {
            populateDictionary();
        }
        towerCostDictionary[type].text = cost.ToString();
    }

    private void populateDictionary() {
        for (int i = 0; i < towerCosts.Length; i++) {
            towerCostDictionary.Add(towerCosts[i].type, towerCosts[i].costText);
        }
    }
}