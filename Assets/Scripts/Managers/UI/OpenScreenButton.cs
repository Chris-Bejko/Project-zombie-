using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenScreenButton : MonoBehaviour
{
    public UIScreenID screenToOpen;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(() => GameManager.Instance.UIManager.OpenScreen(screenToOpen));
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
