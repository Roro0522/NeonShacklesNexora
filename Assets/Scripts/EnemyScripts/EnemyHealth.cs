using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 2;
    private int currentHealth;

    private EnemyVisualEffects fx;

    void Start()
    {
        currentHealth = maxHealth;
        fx = GetComponent<EnemyVisualEffects>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (fx != null)
            fx.FlashWhite();

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        if (fx != null)
        {
            fx.PlayDeathEffect();
            return; 
        }

        Destroy(gameObject);
    }
}



