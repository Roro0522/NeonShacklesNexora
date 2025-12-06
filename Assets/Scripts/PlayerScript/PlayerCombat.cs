using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Input")]
    public KeyCode attackKey = KeyCode.J;  

    [Header("Attack Settings")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 1;
    public LayerMask enemyLayers;
    public float attackDuration = 0.3f;    

    private Animator anim;
    private bool isAttacking = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleAttack();
    }

    void HandleAttack()
    {
        if (Input.GetKeyDown(attackKey) && !isAttacking)
        {
            Attack();
        }
    }

    void Attack()
    {
        isAttacking = true;

        if (anim != null)
            anim.SetBool("isAttacking", true);

        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange,
            enemyLayers
        );

        foreach (Collider2D hit in hits)
        {
            EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
            if (enemy != null)
                enemy.TakeDamage(attackDamage);

            DestructibleObject destructible = hit.GetComponent<DestructibleObject>();
            if (destructible != null)
                destructible.TakeDamage(attackDamage);
        }

        Debug.Log("Objects hit: " + hits.Length);

        StartCoroutine(EndAttack());
    }

    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(attackDuration);

        isAttacking = false;

        if (anim != null)
            anim.SetBool("isAttacking", false);
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


