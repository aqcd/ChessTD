using UnityEngine;

public class LivesDrop : BaseDrop {

    public override void checkExpiry() {
        if (remainingLifetime <= 0) {
            returnObjectToPool();
        }
    }

    public override void onCollect() {
        LivesManager.instance.incrementLives();
        returnObjectToPool();
    }

    private void returnObjectToPool() {
        remainingLifetime = lifetime;
        LivesObjectPool.instance.returnPooledObject(gameObject);
    }
}