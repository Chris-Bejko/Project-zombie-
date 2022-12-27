using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    CheckpointData checkPointData;

    bool hasAlreadySaved;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (hasAlreadySaved)
            return;

        hasAlreadySaved = true;
        checkPointData.x = transform.position.x;
        checkPointData.y = transform.position.y;
        checkPointData.z = transform.position.z;
        if(checkPointData.index != 0)
            checkPointData.PlayerHealth = GameManager.Instance.player.GetComponent<Player>().GetHealth();
        GameManager.Instance.Checkpoints.SetCheckpoint(checkPointData);
        SaveSystem.Save();
    }

    public CheckpointData GetCheckpointData()
    {
        return checkPointData;
    }

    public void SetCheckpointData(CheckpointData data)
    {
        checkPointData = data;
    }


}

