using UnityEngine;

public class PauseManager : MonoBehaviour {
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
            PauseUI.instance.toggle();
        }
    }
}
