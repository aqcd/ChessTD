using UnityEngine;

public class PlayerBuild : MonoBehaviour {
    void Update() {
        if (Input.GetKeyDown("space")) {
            handleBuild();
        }
    }

    void handleBuild() {
        GameManager.activeNodeManager.buildTower();
    }
}
