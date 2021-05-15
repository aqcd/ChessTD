using UnityEngine;

public class TowerSellManager : MonoBehaviour {
    public static TowerSellManager instance;

    public float sellValueFactor;
    
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            sellTower();
        }
    }

    public void setSellCostText() {
        TowerSellUI.instance.setTowerSellText(getCurrentSellCost());
    }

    public int getCurrentSellCost() {
        GameObject tower = GameManager.activeNodeManager.currentTower;

        if (tower == null) {
            return -1;
        }

        TowerDetails towerDetailsComponent = tower.GetComponent<TowerDetails>();

        if (towerDetailsComponent == null) {
            return -1;
        }

        int towerBaseCost = TowerManager.instance.getBaseCostFromType(towerDetailsComponent.type);
        int currentLevel = towerDetailsComponent.level;
        return getSellCost(towerBaseCost, currentLevel);
    }

    public void sellTower() {
        if (GameManager.activeNodeManager == null) {
            return;
        }
        
        GameObject tower = GameManager.activeNodeManager.currentTower;

        if (tower == null) {
            return;
        }

        int sellPrice = getCurrentSellCost();

        if (sellPrice < 0) {
            return;
        }

        CurrencyManager.instance.currentCurrency += getCurrentSellCost();
        GameManager.activeNodeManager.removeTower();
        Destroy(tower);
    }

    private int getSellCost(int baseCost, int currentLevel) {
        return (int)(sellValueFactor * (float)baseCost * Mathf.Pow(2.0f, (float)(currentLevel - 1)));
    }
}