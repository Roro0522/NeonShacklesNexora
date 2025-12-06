using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public int maxHealth = 2;
    private int currentHealth;

    private DestructibleObjectVisualEffects fx;

    void Start()
    {
        currentHealth = maxHealth;
        fx = GetComponent<DestructibleObjectVisualEffects>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (fx != null)
            fx.FlashWhite();

        if (currentHealth <= 0)
            BreakObject();
    }

    void BreakObject()
    {
        if (fx != null)
        {
            fx.PlayDestroyEffect();
            return; 
        }

        Destroy(gameObject);
    }
}

