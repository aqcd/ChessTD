using UnityEngine;

public class PlayerBuild : MonoBehaviour {
    void Update() {
        if (Input.GetKeyDown("space")) {
            handleBuild();
        }
    }

    void handleBuild() {
        if (GameManager.activeNodeManager == null) {
            return;
        }
        
        GameManager.activeNodeManager.buildTower();
    }
}
