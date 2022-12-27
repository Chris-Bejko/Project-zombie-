using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public static class SaveSystem
{

    private const string kInv = "Inventory";
    private const string kCheck = "Checkpoint";
    public static void Save()
    {
        ///health and more data will be saved on checkpoint system
        var checkpoint = GameManager.Instance.Checkpoints.GetCheckpoint().GetCheckpointData();
        
        var inventory = GameManager.Instance.PlayerInventory.GetAllItems();

        PlayerPrefs.SetString(kInv, JsonConvert.SerializeObject(inventory));
        PlayerPrefs.SetString(kCheck, JsonConvert.SerializeObject(checkpoint));
    }

    public static void Load()
    {
        var inventory = JsonConvert.DeserializeObject<List<ItemID>>(PlayerPrefs.GetString(kInv));
        GameManager.Instance.PlayerInventory.SetAllItems(inventory);

        var checkpoint = JsonConvert.DeserializeObject<CheckpointData>(PlayerPrefs.GetString(kCheck));
        GameManager.Instance.Checkpoints.SetCheckpoint(checkpoint);
    }
}
