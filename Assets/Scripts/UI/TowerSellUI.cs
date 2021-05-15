using UnityEngine;
using UnityEngine.UI;

public class TowerSellUI : MonoBehaviour {
    public static TowerSellUI instance;
    
    public Text towerSellText;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void setTowerSellText(int currency) {
        if (currency < 0) {
            towerSellText.text = "-";
        } else {
            towerSellText.text = currency.ToString();
        }
    }
}