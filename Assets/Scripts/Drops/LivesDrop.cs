using UnityEngine;

public class LivesDrop : BaseDrop {

    public override void checkExpiry() {
        if (remainingLifetime <= 0) {
            LivesObjectPool.instance.returnPooledObject(gameObject);
        }
    }

    public override void onCollect() {
        LivesManager.instance.incrementLives();
        LivesObjectPool.instance.returnPooledObject(gameObject);
    }
}