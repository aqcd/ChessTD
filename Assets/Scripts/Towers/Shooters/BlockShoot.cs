using UnityEngine;

public class BlockShoot : BaseShoot {
    private Vector3[] blockTargetArray = new Vector3[0] { };

    public override Vector3[] targetArray { 
        get {
            return blockTargetArray;
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
