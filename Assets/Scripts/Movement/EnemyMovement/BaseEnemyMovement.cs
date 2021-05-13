using UnityEngine;

public class BaseEnemyMovement : MonoBehaviour {
    public float velocity = 8.0f;

    private Transform target;
    private int waypointIndex = 0;
    private float waypointDetectionSensitivity = 0.2f;

    void Start() {
        target = WaypointManager.waypoints[0];
    }

    void Update() {
        doMovement();
        checkWaypointReached();
    }

    void doMovement() {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * velocity * Time.deltaTime, Space.World);
    }

    void checkWaypointReached() {
        if (Vector3.Distance(target.position, transform.position) <= waypointDetectionSensitivity) {
            setNextWaypoint();
        }
    }

    void setNextWaypoint() {
        waypointIndex++;

        if (!checkExitReached()) {
            target = WaypointManager.waypoints[waypointIndex];
        }
    }

    bool checkExitReached() {
        if (waypointIndex > WaypointManager.waypoints.Length - 1) {
            Destroy(gameObject);
            LivesManager.instance.decrementLives();
            return true;
        }
        return false;
    }
}
