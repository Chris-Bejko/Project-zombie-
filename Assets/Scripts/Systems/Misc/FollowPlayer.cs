using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Vector3 offset;
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, GameManager.Instance.GetCurrentState() == GameState.Cutscene ? player.position.y + offset.y : transform.position.y , player.position.z + offset.z);  
    }
}
