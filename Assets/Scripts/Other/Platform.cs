using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class Platform : MonoBehaviour
{

    public int platform;

    private void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.layer = LayerMask.NameToLayer("Platform");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        collision.GetComponent<Player>().ChangePlatform(platform);
    }
}
