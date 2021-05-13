using UnityEngine;

public class KnightShoot : BaseShoot {
    private Vector3[] knightTargetArray = new Vector3[8] { 
        new Vector3(1.0f, 0.0f, 2.0f), 
        new Vector3(-1.0f, 0.0f, 2.0f), 
        new Vector3(-1.0f, 0.0f, -2.0f),
        new Vector3(1.0f, 0.0f, -2.0f), 
        new Vector3(2.0f, 0.0f, 1.0f), 
        new Vector3(-2.0f, 0.0f, 1.0f), 
        new Vector3(-2.0f, 0.0f, -1.0f),
        new Vector3(2.0f, 0.0f, -1.0f)
    };

    public override Vector3[] targetArray { 
        get {
            return knightTargetArray;
        }
    }

    public override float velocity {
        get {
            return 2.0f;
        }
    }

    public override float fireRate {
        get {
            return 0.5f;
        }
    }
}
