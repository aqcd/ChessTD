using UnityEngine;

public class CoinDrop : BaseDrop {

    public override void checkExpiry() {
        if (remainingLifetime <= 0) {
            CoinObjectPool.instance.returnPooledObject(gameObject);
        }
    }

    public override void onCollect() {
        CurrencyManager.instance.currentCurrency++;
        CoinObjectPool.instance.returnPooledObject(gameObject);
    }
}