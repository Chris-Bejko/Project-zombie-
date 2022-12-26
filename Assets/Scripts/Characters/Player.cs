using System.Collections;
using System.Collections.Generic;
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


    private void Awake()
    {
        Health = maxHealth;
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
