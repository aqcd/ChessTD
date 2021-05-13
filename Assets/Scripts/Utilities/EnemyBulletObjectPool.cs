using UnityEngine;

public class EnemyBulletObjectPool : ObjectPool {
    public static EnemyBulletObjectPool instance;

    protected new void Awake() {
        if (instance == null) {
            instance = this;
        }
        base.Awake();
    }
}