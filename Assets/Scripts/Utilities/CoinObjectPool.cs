using UnityEngine;

public class CoinObjectPool : ObjectPool {
    public static CoinObjectPool instance;

    protected new void Awake() {
        if (instance == null) {
            instance = this;
        }
        base.Awake();
    }
}