using UnityEngine;

public class NodeManager : MonoBehaviour {
    public Material activeInvalidMaterial;
    public Material activeValidMaterial;

    private Material initialMaterial;
    private Renderer rendererComponent;

    public GameObject currentTower = null;

    void Start() {
        rendererComponent = GetComponent<Renderer>();
        initialMaterial = rendererComponent.material;
        GameManager.emptyNodes.Add(this);
    }

    void Update() {
        checkActiveNode();
    }

    void checkActiveNode() {
        var nodePosition = transform.position;

        if (Mathf.Abs(nodePosition.x - GameManager.playerPosition.x) < GameConstants.gridSize / 2 && 
            Mathf.Abs(nodePosition.z - GameManager.playerPosition.z) < GameConstants.gridSize / 2) {
            rendererComponent.material = BuildManager.instance.canBuildOnNode(this) ? activeValidMaterial : activeInvalidMaterial;
            GameManager.setActiveNodeManager(this);
        } else {
            rendererComponent.material = initialMaterial;
            if (GameManager.activeNodeManager == this) {
                GameManager.removeActiveNodeManager();
            }
        }
    }

    public void buildTower() {
        if (currentTower == null) {
            BuildManager.instance.buildTowerOnNode(this);
            GameManager.updateSelectedTower();
        }
    }

    public void setTower(GameObject tower) {
        currentTower = tower;
        TowerDetails towerDetailsComponent = currentTower.GetComponent<TowerDetails>();
        if (towerDetailsComponent != null) {
            towerDetailsComponent.node = this;
        }
        GameManager.emptyNodes.Remove(this);
    }

    public void removeTower() {
        currentTower = null;
        GameManager.emptyNodes.Add(this);
        GameManager.updateSelectedTower();
    }

    public bool hasTower() {
        return currentTower != null;
    }

    public bool isTowerFriendly() {
        if (currentTower == null) {
            return false;
        }

        BaseShoot shootComponent = currentTower.GetComponent<BaseShoot>();

        if (shootComponent == null) {
            return false;
        }

        return shootComponent.shooterType == ShooterTypeEnum.FRIENDLY;
    }
}
