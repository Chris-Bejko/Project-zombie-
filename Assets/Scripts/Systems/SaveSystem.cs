using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public static class SaveSystem
{
    static SaveData data;

    private const string kInv = "Inventory";
    private const string kCheck = "Checkpoint";
    public static void Save()
    {
        var checkpoint = GameManager.Instance.Checkpoints.GetCheckpoint().GetCheckpointData();
        
        var inventory = GameManager.Instance.PlayerInventory.GetAllItems();

        PlayerPrefs.SetString(kInv, JsonConvert.SerializeObject(inventory));
        PlayerPrefs.SetString(kCheck, JsonConvert.SerializeObject(checkpoint));
        Debug.LogError("Data Saved");
    }

    public static SaveData Load()
    {
        var data = new SaveData();
        if (PlayerPrefs.GetInt("HasPlayed") == 0)
        {
            data.Inventory = new();
            data.CheckpointData = GameManager.Instance.Checkpoints.GetCheckpoint(0).GetCheckpointData();
            PlayerPrefs.SetInt("HasPlayed", 1);            
            Save();
        }
        else
        {
            var inventory = JsonConvert.DeserializeObject<List<ItemID>>(PlayerPrefs.GetString(kInv));
            GameManager.Instance.PlayerInventory.SetAllItems(inventory);
            var checkpoint = JsonConvert.DeserializeObject<CheckpointData>(PlayerPrefs.GetString(kCheck));
            GameManager.Instance.Checkpoints.SetCheckpoint(checkpoint);
            data.Inventory = inventory;
            data.CheckpointData = checkpoint;
        }

        return data;
    }
}


[System.Serializable]
public class SaveData
{
    public List<ItemID> Inventory { get; set; }
    public CheckpointData CheckpointData { get; set; }
}