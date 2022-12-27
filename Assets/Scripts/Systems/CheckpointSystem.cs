using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    public List<Checkpoint> checkpoints = new List<Checkpoint>();

    private Checkpoint currentCheckpoint;

    public Checkpoint GetCheckpoint()
    {
        return currentCheckpoint;
    }

    public void SetCheckpoint(CheckpointData data)
    {
        this.currentCheckpoint = checkpoints[data.index];
    }



}
[System.Serializable]
public class CheckpointData
{
    public int index;
    public Transform Position;
    public float PlayerHealth;
    public int Platform;
}
