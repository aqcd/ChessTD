using UnityEngine;
using UnityEngine.UI;

class ShopManager : MonoBehaviour {
    public LayoutElement knightLayoutElement;
    public LayoutElement bishopLayoutElement;
    public LayoutElement rookLayoutElement;
    public LayoutElement queenLayoutElement;
    public LayoutElement blockLayoutElement;

    void Update() {
        if (Input.GetKeyDown("q")) {
            blockLayoutElement.gameObject.GetComponent<Button>().Select();
            setBlockTower();
        } else if (Input.GetKeyDown("1")) {
            knightLayoutElement.gameObject.GetComponent<Button>().Select();
            setKnightTower();
        } else if (Input.GetKeyDown("2")) {
            bishopLayoutElement.gameObject.GetComponent<Button>().Select();
            setBishopTower();
        } else if (Input.GetKeyDown("3")) {
            rookLayoutElement.gameObject.GetComponent<Button>().Select();
            setRookTower();
        } else if (Input.GetKeyDown("4")) {
            queenLayoutElement.gameObject.GetComponent<Button>().Select();
            setQueenTower();
        }
    }

    public void setTower(TowerEnum type) {
        BuildManager.instance.setTowerToBuild(type);
    }

    public void setKnightTower() {
        BuildManager.instance.setTowerToBuild(TowerEnum.KNIGHT);
    }
    public void setBishopTower() {
        BuildManager.instance.setTowerToBuild(TowerEnum.BISHOP);
    }
    public void setRookTower() {
        BuildManager.instance.setTowerToBuild(TowerEnum.ROOK);
    }
    public void setQueenTower() {
        BuildManager.instance.setTowerToBuild(TowerEnum.QUEEN);
    }
    public void setBlockTower() {
        BuildManager.instance.setTowerToBuild(TowerEnum.BLOCK);
    }
}