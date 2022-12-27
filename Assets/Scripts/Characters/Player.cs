using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public float horizontal, vertical;

    [SerializeField]
    private int currentPlatform;

    public Animator animator;

    public Rigidbody2D rb;

    public float groundCheckRadius, moveSpeed, jumpForce;

    public Transform groundCheck;

    public LayerMask groundLayer;

    public float lastDirection;

    public Transform firePoint;

    public float fireRate;

    [SerializeField]
    private int Health;
    
    public int maxHealth;


    private void OnEnable()
    {
        GameManager.OnGameStateChanged += GameStateChanged;    
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= GameStateChanged;
    }

    private void Awake()
    {
    }

    private void GameStateChanged(GameState state)
    {
        if(state == GameState.Started)
        {
            Debug.LogError(GameManager.Instance.Checkpoints.GetCheckpoint().GetCheckpointData().index);
            var checkpoint = GameManager.Instance.Checkpoints.GetCheckpoint().GetCheckpointData();
            transform.position = new Vector3(checkpoint.x, checkpoint.y, checkpoint.z);
            Health = checkpoint.PlayerHealth;

        }
    }
    public void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        Animate();
    }

    private void Animate()
    {
        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        if (horizontal != 0)
            transform.localScale = new Vector3(Mathf.Sign(horizontal), transform.localScale.y, transform.localScale.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    }

    public void ChangePlatform(int newPlatform)
    {
        currentPlatform = newPlatform;
    }

    public int GetPlatform()
    {
        return currentPlatform;
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
