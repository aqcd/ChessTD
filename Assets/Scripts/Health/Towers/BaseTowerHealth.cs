using UnityEngine;

public class BaseTowerHealth : BaseHealth {
    public GameObject towerDeathEffect;

    public override void triggerDeath() {
        GameObject towerDeathEffectParticleSystem = (GameObject) Instantiate(towerDeathEffect, transform.position, transform.rotation);
        Destroy(towerDeathEffectParticleSystem, 1.0f);

        TowerDetails towerDetailsComponent = gameObject.GetComponent<TowerDetails>();
        
        if (towerDetailsComponent != null) {
            towerDetailsComponent.node.removeTower();
        }
        Destroy(gameObject);
    }
}