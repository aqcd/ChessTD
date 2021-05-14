using UnityEngine;

abstract public class BaseShoot : MonoBehaviour {
    abstract public Vector3[] targetArray { get; }
    abstract public float velocity { get; }
    abstract public float fireRate { get; }
    private float fireCountdown = 1.0f;

    private float bulletHeight = 1.0f;

    public int damage;

    public GameObject bulletPrefab;

    public ShooterTypeEnum shooterType = ShooterTypeEnum.FRIENDLY;
    
    void Update() {
        fireCountdown -= Time.deltaTime;

        if (fireCountdown <= 0.0f) {
            shoot();
            fireCountdown = 1.0f / fireRate;
        }
    }

    void shoot() {
        for (int i = 0; i < targetArray.Length; i++) {
            Vector3 launchOrigin = new Vector3(transform.position.x, bulletHeight, transform.position.z) 
                                                + targetArray[i].normalized * GameConstants.gridSize / 2;
            
            GameObject bullet = shooterType == ShooterTypeEnum.FRIENDLY ? FriendlyBulletObjectPool.instance.getPooledObject()
                                                                        : EnemyBulletObjectPool.instance.getPooledObject();
            
            if (bullet != null) {
                bullet.transform.position = launchOrigin;
                bullet.transform.rotation = transform.rotation;
            } else {
                bullet = (GameObject) Instantiate(bulletPrefab.gameObject, launchOrigin, transform.rotation);
            }
            BulletUtil.activateBullet(bullet);
            
            BulletMovement bulletMovementComponent = bullet.GetComponent<BulletMovement>();
            if  (bulletMovementComponent != null) {
                bulletMovementComponent.setTarget(targetArray[i]);
                bulletMovementComponent.setVelocity(velocity);
                bulletMovementComponent.setType(shooterType);
            }

            BulletDamage bulletDamageComponent = bullet.GetComponent<BulletDamage>();
            if  (bulletDamageComponent != null) {
                bulletDamageComponent.setDamage(damage);
            }
        }
    }
}
