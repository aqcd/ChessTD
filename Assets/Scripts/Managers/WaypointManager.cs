using UnityEngine;

public class WaypointManager : MonoBehaviour {
    public static Transform[] waypoints;

    void Start() {

    }

    void Awake() {
        initialiseWaypoints();
    }

    void initialiseWaypoints() {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++) {
            waypoints[i] = transform.GetChild(i);
        }
    }
}
