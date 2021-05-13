using UnityEngine;

public class BaseEnemyHealth : BaseHealth {
    public GameObject enemyDeathEffect;

    public override void triggerDeath() {
        GameObject enemyDeathEffectParticleSystem = (GameObject) Instantiate(enemyDeathEffect, transform.position, transform.rotation);
        Destroy(enemyDeathEffectParticleSystem, 1.0f);
        Destroy(gameObject);
    }
}