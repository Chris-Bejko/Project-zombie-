using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemID itemID;

    private const string animParam = "Dissapear";
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        GameManager.Instance.PlayerInventory.AddItem(itemID);
        gameObject.SetActive(false);    
    }



}
