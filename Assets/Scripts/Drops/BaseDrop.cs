using UnityEngine;

public abstract class BaseDrop : MonoBehaviour {
    public float lifetime;

    protected float remainingLifetime;

    public float magnetRange;

    public float collectRange;

    protected Vector3 target;

    protected float interpolationFactor = 0.95f;

    protected bool isLockedOn = false;

    void Start() {
        remainingLifetime = lifetime;
    }

    void Update() {
        handleCollect();
        handleMovement();
    }

    void handleCollect() {
        if ((GameManager.playerPosition - transform.position).magnitude < collectRange) {
            onCollect();
        }
    }

    void handleMovement() {
        remainingLifetime -= Time.deltaTime;

        float magnetFactor = 1.0f;
        float distanceToPlayer = (GameManager.playerPosition - transform.position).magnitude;
        if (distanceToPlayer < magnetRange) {
            interpolationFactor = 2.0f;
            magnetFactor = magnetRange / distanceToPlayer;
            target = GameManager.playerPosition;
        }

        Vector3 dir = target - transform.position;
        transform.Translate(dir * interpolationFactor * Time.deltaTime * magnetFactor, Space.World);

        checkExpiry();
    }

    public abstract void checkExpiry();

    public abstract void onCollect();

    public void setTarget(Vector3 _target) {
        target = _target;
    }
}