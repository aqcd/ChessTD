using UnityEngine;

public class NodeUIManager : MonoBehaviour {
    public static NodeUIManager instance;

    public NodeManager activeNode = null;

    public GameObject nodeUI;

    public Vector3 basePosition;
    
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        basePosition = nodeUI.transform.position;
        nodeUI.SetActive(false);
    }

    public void setActiveNode(NodeManager node) {
        bool nodeChanged = activeNode != node;
        activeNode = node;
        if (nodeChanged) {
            updateNode();
        }
    }

    public void removeActiveNode() {
        activeNode = null;
        deactivateUI();
    }

    public void updateNode() {
        nodeUI.transform.position = basePosition + activeNode.transform.position;
        if (activeNode.hasTower() && activeNode.isTowerFriendly()) {
            activateUI();
            setUIElements();
        } else {
            deactivateUI();
        }
    }

    private void setUIElements() {
        setUpgradeCostText();
        setSellCostText();
    }

    private void setUpgradeCostText() {
        TowerUpgradeManager.instance.setUpgradeCostText();
    }

    private void setSellCostText() {
        TowerSellManager.instance.setSellCostText();
    }

    private void activateUI() {
        nodeUI.SetActive(true);
    }

    private void deactivateUI() {
        nodeUI.SetActive(false);
    }
}