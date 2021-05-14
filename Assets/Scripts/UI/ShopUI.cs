using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour {
    public static ShopUI instance;

    public Text knightCost;
    public Text bishopCost;
    public Text rookCost;
    public Text queenCost;
    public Text blockCost;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void setKnightCostText(int cost) {
        knightCost.text = cost.ToString();
    }

    public void setBishopCostText(int cost) {
        bishopCost.text = cost.ToString();
    }

    public void setRookCostText(int cost) {
        rookCost.text = cost.ToString();
    }

    public void setQueenCostText(int cost) {
        queenCost.text = cost.ToString();
    }

    public void setBlockCostText(int cost) {
        blockCost.text = cost.ToString();
    }
}