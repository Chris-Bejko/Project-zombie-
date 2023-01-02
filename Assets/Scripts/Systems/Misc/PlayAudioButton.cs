using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayAudioButton : MonoBehaviour
{
    public AudioManager.AudioType Clip;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(() => GameManager.Instance.AudioManager.PlayAudio(Clip));   
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
