using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemID> items = new();

    public static event Action<ItemID> ItemAdded;

    public void AddItem(ItemID item)
    {
        items.Add(item);
        ItemAdded?.Invoke(item);
    }

    public bool HasItem(ItemID item)
    {
        return items.Contains(item);
    }
}


public enum ItemID
{
    Key1,
    Key2,
    Key3, //...
    Key4,
    Key5,
    Lore1,
    Lore2,
    Lore3,
    Lore4,
    Lore5,

}