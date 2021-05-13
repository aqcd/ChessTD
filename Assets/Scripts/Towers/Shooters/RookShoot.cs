using UnityEngine;

public class RookShoot : BaseShoot {
    private Vector3[] rookTargetArray = new Vector3[4] { 
        new Vector3(1.0f, 0.0f, 0.0f), 
        new Vector3(-1.0f, 0.0f, 0.0f), 
        new Vector3(0.0f, 0.0f, 1.0f),
        new Vector3(0.0f, 0.0f, -1.0f)
    };

    public override Vector3[] targetArray { 
        get {
            return rookTargetArray;
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
