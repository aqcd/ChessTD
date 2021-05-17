using UnityEngine;

public class CoinDrop : BaseDrop {

    public override void checkExpiry() {
        if (remainingLifetime <= 0) {
            returnObjectToPool();
        }
    }

    public override void onCollect() {
        CurrencyManager.instance.currentCurrency++;
        returnObjectToPool();
    }

    private void returnObjectToPool() {
        remainingLifetime = lifetime;
        CoinObjectPool.instance.returnPooledObject(gameObject);
    }
}