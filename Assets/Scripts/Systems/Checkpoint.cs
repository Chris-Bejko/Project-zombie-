using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    CheckpointData checkPointData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.Checkpoints.SetCheckpoint(checkPointData);
    }

    public CheckpointData GetCheckpointData()
    {
        return checkPointData;
    }


}

