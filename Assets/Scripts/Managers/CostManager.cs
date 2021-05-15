using UnityEngine;

class CostManager : MonoBehaviour {
    public static CostManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void updateCosts(Tower tower) {
        int increment = 0;
        switch(tower.type) {
            case TowerEnum.BLOCK:
                increment = 2;
                break;
            default:
                increment = 5;
                break;
        }
        tower.costIncrement += increment;
        
        updateUIForType(tower.type);
    }

    private void updateUIForType(TowerEnum type) {
        ShopUI.instance.setCost(type, TowerManager.instance.getCostFromType(type));
    }
}