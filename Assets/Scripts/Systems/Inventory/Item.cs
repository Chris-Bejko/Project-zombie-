using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemID itemID;

    [SerializeField]
    private int nextCheckpoint;

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += GameStateChanged;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= GameStateChanged;
    }
    private const string animParam = "Dissapear";
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        GameManager.Instance.PlayerInventory.AddItem(itemID);
        gameObject.SetActive(false);    
    }

    private void GameStateChanged(GameState state)
    {
        if (state == GameState.Started)
        {
            Debug.LogError(GameManager.Instance.Checkpoints.GetCheckpoint().GetCheckpointData().index);
            if (GameManager.Instance.Checkpoints.GetCheckpoint().GetCheckpointData().index >= nextCheckpoint)
                Destroy(gameObject);
        }
    }
}
