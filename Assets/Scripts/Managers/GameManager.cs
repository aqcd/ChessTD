using System.Collections;
using UnityEngine;

class GameManager {
    public static Vector3 playerPosition = new Vector3();
    public static NodeManager activeNodeManager = null;
    public static GameObject selectedTower = null;
    public static ArrayList emptyNodes = new ArrayList();

    public static int currentWave = 0;

    public static bool isGameActive = true;

    public static void setActiveNodeManager(NodeManager nodeManager) {
        activeNodeManager = nodeManager;
        selectedTower = activeNodeManager.currentTower;
        NodeUIManager.instance.setActiveNode(nodeManager);
    }

    public static void removeActiveNodeManager() {
        activeNodeManager = null;
        selectedTower = null;
        NodeUIManager.instance.removeActiveNode();
    }

    public static void updateSelectedTower() {
        selectedTower = activeNodeManager.currentTower;
        NodeUIManager.instance.updateNode();
    }

    public static void reset() {
        activeNodeManager = null;
        emptyNodes = new ArrayList();
        currentWave = 0;
    }
}