using UnityEngine;
using UnityEngine.UI;

public abstract class BaseHealth : MonoBehaviour {
    public int maxHealth;

    private int currentHealth;

    public Image healthBar;

    void Start() {
        currentHealth = maxHealth;
    }

    public void multiplyHealth(int multiplier) {
        maxHealth *= multiplier;
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
        checkDeath();
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    private void checkDeath() {
        if (currentHealth <= 0) {
            triggerDeath();
        }
    }

    public abstract void triggerDeath();
}