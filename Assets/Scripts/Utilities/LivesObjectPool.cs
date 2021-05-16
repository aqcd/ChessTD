using UnityEngine;

public class LivesObjectPool : ObjectPool {
    public static LivesObjectPool instance;

    protected new void Awake() {
        if (instance == null) {
            instance = this;
        }
        base.Awake();
    }
}