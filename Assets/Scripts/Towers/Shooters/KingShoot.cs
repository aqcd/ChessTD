using UnityEngine;

public class KingShoot : BaseShoot {
    private Vector3[] kingTargetArray = new Vector3[8] { 
        new Vector3(1.0f, 0.0f, 0.0f), 
        new Vector3(-1.0f, 0.0f, 0.0f), 
        new Vector3(0.0f, 0.0f, 1.0f),
        new Vector3(0.0f, 0.0f, -1.0f),
        new Vector3(1.0f, 0.0f, 1.0f), 
        new Vector3(-1.0f, 0.0f, 1.0f), 
        new Vector3(-1.0f, 0.0f, -1.0f),
        new Vector3(1.0f, 0.0f, -1.0f)
    };

    public override Vector3[] targetArray { 
        get {
            return kingTargetArray;
        }
    }

    public override float velocity {
        get {
            return 2.0f;
        }
    }

    public override float fireRate {
        get {
            return 1.0f;
        }
    }
}
