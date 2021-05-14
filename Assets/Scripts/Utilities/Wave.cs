using System.Collections.Generic;

[System.Serializable]
public class Wave {
    public int numPawns;
    public int numKnights;
    public int numBishops;
    public int numRooks;
    public int numQueens;
    public int numKings;

    public List<EnemyEnum> list = null;

    public Wave(int _numPawns, int _numKnights, int _numBishops, int _numRooks, int _numQueens, int _numKings) {
        numPawns = _numPawns;
        numKnights = _numKnights;
        numBishops = _numBishops;
        numRooks = _numRooks;
        numQueens = _numQueens;
        numKings = _numKings;
    }

    public List<EnemyEnum> getAsList() {
        if (list == null) {
            initialiseList();
        }

        return list;
    }

    private void initialiseList() {
        list = new List<EnemyEnum>();

        for (int i = 0; i < numPawns; i++) { list.Add(EnemyEnum.PAWN); }
        for (int i = 0; i < numKnights; i++) { list.Add(EnemyEnum.KNIGHT); }
        for (int i = 0; i < numBishops; i++) { list.Add(EnemyEnum.BISHOP); }
        for (int i = 0; i < numRooks; i++) { list.Add(EnemyEnum.ROOK); }
        for (int i = 0; i < numQueens; i++) { list.Add(EnemyEnum.QUEEN); }
        for (int i = 0; i < numKings; i++) { list.Add(EnemyEnum.KING); }
    }
}