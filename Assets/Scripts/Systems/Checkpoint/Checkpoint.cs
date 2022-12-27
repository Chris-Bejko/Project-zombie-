using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    CheckpointData checkPointData;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        //if (checkPointData.hasAlreadyBeenSaved)
          //  return;

        //checkPointData.hasAlreadyBeenSaved = true;
        checkPointData.x = transform.position.x;
        checkPointData.y = transform.position.y;
        checkPointData.z = transform.position.z;
        checkPointData.PlayerHealth = GameManager.Instance.player.GetComponent<Player>().GetHealth();
        GameManager.Instance.Checkpoints.SetCheckpoint(checkPointData);
        SaveSystem.Save();
        gameObject.SetActive(false);
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

