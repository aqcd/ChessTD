using UnityEngine;

public class FriendlyBulletObjectPool : ObjectPool {
    public static FriendlyBulletObjectPool instance;

    protected new void Awake() {
        if (instance == null) {
            instance = this;
        }
        base.Awake();
    }
}