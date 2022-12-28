using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    ItemID keyNeeded;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (GameManager.Instance.PlayerInventory.HasItem(keyNeeded))
        {
            Debug.LogError("Press e to use key");
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(StartAnimation());
            }
        }
        else
        {
            Debug.LogError("You need key to open");
        }
    }

    private IEnumerator StartAnimation()
    {
        animator.SetTrigger("Open");
        GameManager.Instance.ChangeState(GameState.Cutscene);
        yield return new WaitForSeconds(6.7f); ///Lifting animation duration
        var pos = transform.position;
        GameManager.Instance.ChangeState(GameState.Playing);
        animator.StopPlayback();
        animator.enabled = false;
        transform.position = pos;
    }
}
