using UnityEngine;
using UnityEngine.UI;

public class CurrencyUI : MonoBehaviour {
    public static CurrencyUI instance;

    public Text currencyText;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void setCurrencyText(int currency) {
        currencyText.text = "  Coins: " + currency;
    }
}