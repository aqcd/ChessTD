using UnityEngine;

public class EnemyPrefabs : MonoBehaviour {
    public static EnemyPrefabs instance;

    public GameObject enemyPawnPrefab;
    public GameObject enemyKnightPrefab;
    public GameObject enemyBishopPrefab;
    public GameObject enemyRookPrefab;
    public GameObject enemyQueenPrefab;
    public GameObject enemyKingPrefab;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public GameObject getEnemyPrefabFromType(EnemyEnum type) {
        switch(type) {
            case EnemyEnum.PAWN:
                return enemyPawnPrefab;
            case EnemyEnum.KNIGHT:
                return enemyKnightPrefab;
            case EnemyEnum.BISHOP:
                return enemyBishopPrefab;
            case EnemyEnum.ROOK:
                return enemyRookPrefab;
            case EnemyEnum.QUEEN:
                return enemyQueenPrefab;
            case EnemyEnum.KING:
                return enemyKingPrefab;
            default:
                return enemyPawnPrefab;
        }
    }
}