using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradeUI : MonoBehaviour {
    public static TowerUpgradeUI instance;
    
    public Text towerUpgradeText;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void setTowerUpgradeText(int currency) {
        if (currency < 0) {
            towerUpgradeText.text = "-";
        } else {
            towerUpgradeText.text = currency.ToString();
        }
    }
}