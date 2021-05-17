using UnityEngine;

public class TowerUpgradeManager : MonoBehaviour {
    public static TowerUpgradeManager instance;
    
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            upgradeTower();
        }
    }

    public void setUpgradeCostText() {
        TowerUpgradeUI.instance.setTowerUpgradeText(getCurrentUpgradeCost());
    }

    public int getCurrentUpgradeCost() {
        GameObject tower = GameManager.activeNodeManager.currentTower;

        if (tower == null) {
            return -1;
        }

        TowerDetails towerDetailsComponent = tower.GetComponent<TowerDetails>();

        if (towerDetailsComponent == null) {
            return -1;
        }

        if (towerDetailsComponent.level >= TowerManager.instance.getMaxLevelFromType(towerDetailsComponent.type)) {
            return -1;
        }

        int towerBaseCost = TowerManager.instance.getBaseCostFromType(towerDetailsComponent.type);
        int currentLevel = towerDetailsComponent.level;
        return getUpgradeCost(towerBaseCost, currentLevel);
    }

    public bool canUpgradeTower() {
        int upgradeCost = getCurrentUpgradeCost();

        if (upgradeCost < 0) { return false; }
        return CurrencyManager.instance.currentCurrency >= upgradeCost;
    }

    public void upgradeTower() {
        if (GameManager.activeNodeManager == null) {
            return;
        }
        
        GameObject tower = GameManager.activeNodeManager.currentTower;

        if (tower == null) {
            return;
        }

        TowerDetails towerDetailsComponent = tower.GetComponent<TowerDetails>();

        if (towerDetailsComponent == null) {
            return;
        }

        int towerBaseCost = TowerManager.instance.getBaseCostFromType(towerDetailsComponent.type);
        int currentLevel = towerDetailsComponent.level;
        int upgradeCost = getUpgradeCost(towerBaseCost, currentLevel);

        if (CurrencyManager.instance.currentCurrency < upgradeCost) {
            return;
        }

        if (towerDetailsComponent.level >= TowerManager.instance.getMaxLevelFromType(towerDetailsComponent.type)) {
            return;
        }

        CurrencyManager.instance.currentCurrency -= upgradeCost;
        towerDetailsComponent.level++;
        handleUpgrade(tower);
    }

    public void handleUpgrade(GameObject tower) {
        BaseTowerHealth towerHealthComponent = tower.GetComponent<BaseTowerHealth>();
        BaseShoot towerShootComponent = tower.GetComponent<BaseShoot>();

        if (towerHealthComponent != null) {
            towerHealthComponent.multiplyHealth(2);
        }
        
        if (towerShootComponent != null) {
            towerShootComponent.damage *= 2;
        }

        setUIElements();
    }

    private void setUIElements() {
        setUpgradeCostText();
        TowerSellManager.instance.setSellCostText();
    }

    private int getUpgradeCost(int baseCost, int currentLevel) {
        return baseCost * (int)Mathf.Pow(2.0f, (float)currentLevel);
    }
}