using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<IDamageable>();
            player.TakeDamage(100);
        }else if (collision.CompareTag("Enemy"))
        {
            var enemy = collision.GetComponent<IDamageable>();
            enemy.TakeDamage(5);
        }
    }
}
