using UnityEngine;

public abstract class BaseHealth : MonoBehaviour {
    public int maxHealth;

    private int currentHealth;

    void Start() {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
        checkDeath();
    }

    void checkDeath() {
        if (currentHealth <= 0) {
            triggerDeath();
        }
    }

    public abstract void triggerDeath();
}