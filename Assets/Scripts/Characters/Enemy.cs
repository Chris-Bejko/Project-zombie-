using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public Animator animator;

    public Rigidbody2D rb;

    public float desiredDistance;

    public Player Target;

    public int Platform;

    public float moveSpeed;

    public bool hasSeenPlayerOnce;

    private int Health;

    public float combatRate;

    public float initiateForce;

    public Transform attackPoint;

    public float attackRange;

    public int damage;

    public int maxHealth;

    public LayerMask PlayerLayer;

    public int nextCheckpoint;

    public Transform initPoint;

    public float minDistance;

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += GameStateChanged;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= GameStateChanged;
    }


    private void GameStateChanged(GameState state)
    {
        if (state == GameState.Started)
        {
            transform.position = initPoint.position;
            Health = maxHealth;
            if (GameManager.Instance.Checkpoints.GetCheckpoint().GetCheckpointData().index >= nextCheckpoint)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);
        }
    }
    public void Awake()
    {
        Health = maxHealth;
    }
    public void Update()
    {
        Animate();
    }


    public void Animate()
    {

    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public int GetHealth()
    {
        return Health;
    }
}
