using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChangeStateButton : MonoBehaviour
{
    public GameState StateToChangeTo;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(() => GameManager.Instance.ChangeState(StateToChangeTo));
        Debug.LogError("Added Listener");
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
