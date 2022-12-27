using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    public List<Checkpoint> checkpoints = new List<Checkpoint>();

    private Checkpoint currentCheckpoint;

    private void Awake()
    {
        currentCheckpoint = checkpoints[0];
        GameManager.OnGameStateChanged += GameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameStateChanged;
    }

    public void GameStateChanged(GameState state)
    {
        if (state == GameState.Started)
        {
            for(int i = 0; i < currentCheckpoint.GetCheckpointData().index; i++)
            {
                checkpoints[i].gameObject.SetActive(false);
            }
        }
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
    //public bool hasAlreadyBeenSaved;
    public int index;
    public float x;
    public float y;
    public float z;
    public int PlayerHealth;

}
