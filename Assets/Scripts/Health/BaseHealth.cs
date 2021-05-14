using UnityEngine;
using UnityEngine.UI;

public abstract class BaseHealth : MonoBehaviour {
    public int maxHealth;

    private int currentHealth;

    public Image healthBar;

    void Start() {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
        checkDeath();
        Debug.Log((float)currentHealth / (float)maxHealth);
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    void checkDeath() {
        if (currentHealth <= 0) {
            triggerDeath();
        }
    }

    public abstract void triggerDeath();
}