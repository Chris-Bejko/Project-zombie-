using UnityEngine;

public class Bullet : MonoBehaviour, IDamageable
{
    [SerializeField]
    private Rigidbody2D rb;

    private int bulletHealth;
    [SerializeField]
    private float bulletForce;

    public void Die()
    {
        bulletHealth = 0;
        gameObject.SetActive(false);
    }

    public int GetHealth()
    {
        return bulletHealth;
    }

    public void TakeDamage(int damage)
    {
        bulletHealth -= damage;
        if (bulletHealth <= 0)
            Die();
    }

    private void OnEnable()
    {
        if (GameManager.Instance.GetCurrentState() != GameState.Playing)
            return;

        bulletHealth = 100;
        rb.AddForce(Vector2.right * bulletForce * GameManager.Instance.player.localScale.x, ForceMode2D.Impulse);
        Invoke("Die", 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            return;
        if (collision.TryGetComponent<IDamageable>(out var comp))
        {
            comp.TakeDamage(10);
        }
        Die();
    }
}
