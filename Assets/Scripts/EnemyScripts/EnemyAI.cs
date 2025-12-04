using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 2f;
    public Transform leftPoint;
    public Transform rightPoint;

    [Header("Chase Settings")]
    public float chaseRange = 5f;

    [Header("Hover Effect")]
    public float hoverHeight = 0.25f;
    public float hoverSpeed = 2f;

    private Transform player;
    private float baseY;
    private bool movingRight = true;
    private bool isDead = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        baseY = transform.position.y;
    }

    void Update()
    {
        if (isDead) return;  

        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= chaseRange)
            ChasePlayer();
        else
            Patrol();

        Hover(); 
    }

    void Patrol()
    {
        if (movingRight)
        {
            transform.position = new Vector2(
                Mathf.MoveTowards(transform.position.x, rightPoint.position.x, speed * Time.deltaTime),
                transform.position.y
            );

            if (Mathf.Abs(transform.position.x - rightPoint.position.x) < 0.1f)
                movingRight = false;

            FaceDirection(true);
        }
        else
        {
            transform.position = new Vector2(
                Mathf.MoveTowards(transform.position.x, leftPoint.position.x, speed * Time.deltaTime),
                transform.position.y
            );

            if (Mathf.Abs(transform.position.x - leftPoint.position.x) < 0.1f)
                movingRight = true;

            FaceDirection(false);
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            new Vector2(player.position.x, transform.position.y),
            speed * Time.deltaTime
        );

        FaceDirection(player.position.x > transform.position.x);
    }

    void Hover()
    {
        float hoverY = baseY + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;

        transform.position = new Vector3(
            transform.position.x,
            hoverY,
            transform.position.z
        );
    }

    void FaceDirection(bool right)
    {
        transform.localScale = right ? 
            new Vector3(3, 3, 3) : 
            new Vector3(-3, 3, 3);
    }

    public void KillEnemy()  
    {
        isDead = true;
    }
}



