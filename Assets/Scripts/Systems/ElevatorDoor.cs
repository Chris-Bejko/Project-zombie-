using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    ItemID keyNeeded;

    public Transform inPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (GameManager.Instance.PlayerInventory.HasItem(keyNeeded))
        {
            StartCoroutine(StartAnimation());
        }
    }

    private IEnumerator StartAnimation()
    {
        animator.SetTrigger("Open");
        GameManager.Instance.ChangeState(GameState.Cutscene);
        yield return new WaitForSeconds(6.5f); ///Lifting animation duration
        var pos = transform.position;
        GameManager.Instance.ChangeState(GameState.Playing);
        animator.StopPlayback();
        animator.enabled = false;
        transform.position = pos;
    }
}
