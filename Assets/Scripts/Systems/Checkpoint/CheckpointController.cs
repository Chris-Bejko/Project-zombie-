using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    public List<Checkpoint> checkpoints = new List<Checkpoint>();

    private Checkpoint currentCheckpoint;

    private void Awake()
    {
        currentCheckpoint = checkpoints[0];
    }

    public Checkpoint GetCheckpoint(int index)
    {
        return checkpoints[index];
    }
    public Checkpoint GetCheckpoint()
    {
        return currentCheckpoint;
    }

    public void SetCheckpoint(CheckpointData data)
    {
        checkpoints[data.index].SetCheckpointData(data);
        currentCheckpoint = checkpoints[data.index];
    }



}
[System.Serializable]
public class CheckpointData
{
    public bool hasAlreadyBeenSaved;
    public int index;
    public float x;
    public float y;
    public float z;
    public int PlayerHealth;

}
