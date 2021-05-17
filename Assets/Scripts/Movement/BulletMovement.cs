using UnityEngine;

public class BulletMovement : MonoBehaviour {
    private Vector3 target;
    
    private float velocity;

    public GameObject impactEffect;
    public LayerMask bulletHitMask;

    public ShooterTypeEnum bulletType = ShooterTypeEnum.FRIENDLY;

    public void setTarget(Vector3 _target) {
        target = _target;
    }

    public void setVelocity(float _velocity) {
        velocity = _velocity;
    }

    public void setType(ShooterTypeEnum _type) {
        bulletType = _type;
    }

    void Update() {
        transform.Translate(target.normalized * velocity * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider collider) {
        if ((bulletHitMask.value & 1 << collider.gameObject.layer) != 0) {
            BulletUtil.deactivateBullet(gameObject);

            switch(bulletType) {
                case ShooterTypeEnum.FRIENDLY:
                    FriendlyBulletObjectPool.instance.returnPooledObject(gameObject);
                    break;
                case ShooterTypeEnum.HOSTILE:
                    EnemyBulletObjectPool.instance.returnPooledObject(gameObject);
                    break;
            }
            
            GameObject impactEffectParticleSystem;
            switch(collider.gameObject.layer) {
                case 6: //Player.
                    LivesManager.instance.decrementLivesWithInvul();
                    break;
                case 9: // Boundary.
                    break;
                case 10: // Indestructible.
                    impactEffectParticleSystem = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
                    Destroy(impactEffectParticleSystem, 1.0f);
                    break;
                default:
                    impactEffectParticleSystem = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
                    Destroy(impactEffectParticleSystem, 1.0f);
                    
                    BaseHealth collidedHealthComponent = collider.gameObject.GetComponent<BaseHealth>();
                    BulletDamage damageComponent = gameObject.GetComponent<BulletDamage>();
                    if (collidedHealthComponent != null && damageComponent != null) {
                        collidedHealthComponent.takeDamage(damageComponent.damage);
                    }
                    break;
            }
        }
    }
}
