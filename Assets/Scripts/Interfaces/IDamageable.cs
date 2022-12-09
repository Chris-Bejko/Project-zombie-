using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{

    public void TakeDamage(int damage);

    public int GetHealth();

    public void Die();
}
