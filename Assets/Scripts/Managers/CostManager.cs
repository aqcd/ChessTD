using UnityEngine;

class CostManager : MonoBehaviour {
    public static CostManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void updateCosts(Tower tower, TowerEnum type) {
        int increment = 0;
        switch(type) {
            case TowerEnum.BLOCK:
                increment = 2;
                break;
            default:
                increment = 5;
                break;
        }
        tower.costIncrement += increment;
        
        updateUI();
    }

    private void updateUI() {
        ShopUI.instance.setKnightCostText(BuildManager.instance.knightTower.getCost());
        ShopUI.instance.setBishopCostText(BuildManager.instance.bishopTower.getCost());
        ShopUI.instance.setRookCostText(BuildManager.instance.rookTower.getCost());
        ShopUI.instance.setQueenCostText(BuildManager.instance.queenTower.getCost());
        ShopUI.instance.setBlockCostText(BuildManager.instance.blockTower.getCost());
    }
}