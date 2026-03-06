using UnityEngine;
public class EnemyAttack : MonoBehaviour
{
    public float attackSpeed = 10f;
    public float attackChance = 0.001f;
    private bool isAttacking = false;
    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null)
        {
            Destroy(gameObject);
            return;
        }

        if (!isAttacking && Random.value < attackChance)
        {
            isAttacking = true;
        }

        if (isAttacking)
        {
            Vector3 direction = Vector3.back; // <-- direzione fissa in avanti, non verso il player
            transform.position += direction * attackSpeed * Time.deltaTime;
        }

        if (transform.position.z < -20f) // <-- limite fisso invece di usare player.position
        {
            Destroy(gameObject);
        }
    }
}