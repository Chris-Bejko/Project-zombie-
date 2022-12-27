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
        if (HasItem(item))
            return;

        items.Add(item);
        ItemAdded?.Invoke(item);
    }

    public bool HasItem(ItemID item)
    {
        return items.Contains(item);
    }

    public List<ItemID> GetAllItems()
    {
        return items;
    }

    public void SetAllItems(List<ItemID> items)
    {
        this.items = items;
    }
}


public enum ItemID
{
    Key1,
    Key2,
    Key3, //...
    Key4,
    Key5,
    EndOfKeys,

    Lore1,
    Lore2,
    Lore3,
    Lore4,
    Lore5,

}