using System.Collections;
using System.Collections.Generic;
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
