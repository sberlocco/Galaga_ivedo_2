using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackSpeed = 10f;
    public float attackChance = 0.001f;

    private bool isAttacking = false;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isAttacking && Random.value < attackChance)
        {
            isAttacking = true;
        }

        if (isAttacking)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * attackSpeed * Time.deltaTime;
        }

        if (transform.position.z < player.position.z - 10f)
        {
            Destroy(gameObject);
        }
    }
}