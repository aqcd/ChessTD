using UnityEngine;

public class TutorialManager : MonoBehaviour {
    /*
        0: WASD to move.
        1: If enemy reaches king, lose 1 life.
        2: Hotkey/Click to select shop item. Space to buy. Be careful to dodge friendly bullets as well.
        3: Z/X to upgrade/sell.
        4: Hostile towers.
        5: F to start game.
    */
    public GameObject[] popups;
    public GameObject shopMenu;
    private int popupIndex = 0;
    public float maxTimer;
    private float timer;

    void Start() {
        popupIndex = 0;
        timer = maxTimer;
    }

    void Update() {
        if (!GameManager.hasCompletedTutorial) {
            handlePopupTransitions();
        }
    }

    private void handlePopupTransitions() {
        switch(popupIndex) {
            case 0:
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) {
                    transition();
                }
                break;
            case 1:
                timer -= Time.deltaTime;
                if (timer <= 0) {
                    timer = maxTimer;
                    transition();
                }
                break;
            case 2:
                if (GameManager.activeNodeManager != null && GameManager.activeNodeManager.hasTower()) {
                    transition();
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X)) {
                    transition();
                }
                break;
            case 4:
                timer -= Time.deltaTime;
                if (timer <= 0) {
                    timer = maxTimer;
                    transition();
                }
                break;
            case 5:
                if (Input.GetKeyDown(KeyCode.F)) {
                    transition();
                    GameManager.hasCompletedTutorial = true;
                }
                break;
            default:
                break;
        }
    }

    private void transition() {
        popupIndex++;
        if ((popupIndex - 1) >= 0) {
            popups[popupIndex - 1].SetActive(false);
        }
        if (!(popupIndex >= popups.Length)) {
            popups[popupIndex].SetActive(true);
        }
    }
}