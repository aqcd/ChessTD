using UnityEngine;

class CurrencyManager : MonoBehaviour {
    public static CurrencyManager instance;
    public int initialCurrency;
    public int passiveIncome;
    public int currentCurrency = 0;

    private float cooldown = 1.0f;
    private float countdown = 1.0f;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        currentCurrency = initialCurrency;
        countdown = cooldown;
    }

    void Update() {
        handlePassiveIncome();
        setCurrencyText();
    }

    void handlePassiveIncome() {
        if (GameManager.currentWave > 0) {
            countdown -= Time.deltaTime;
            if (countdown <= 0.0f) {
                countdown += cooldown;
                currentCurrency += passiveIncome;
            }
        }
    }

    public bool decreaseCurrency(int amountToDecrease) {
        if (currentCurrency >= amountToDecrease) {
            currentCurrency -= amountToDecrease;
            return true;
        }

        return false;
    }

    void setCurrencyText() {
        CurrencyUI.instance.setCurrencyText(currentCurrency);
    }
}