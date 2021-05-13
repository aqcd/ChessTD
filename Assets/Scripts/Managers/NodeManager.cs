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
            GameManager.activeNodeManager = this;
        } else {
            rendererComponent.material = initialMaterial;
        }
    }

    public void buildTower() {
        if (currentTower == null) {
            BuildManager.instance.buildTowerOnNode(this);
        }
    }

    public void setTower(GameObject tower) {
        currentTower = tower;
        GameManager.emptyNodes.Remove(this);
    }
}
