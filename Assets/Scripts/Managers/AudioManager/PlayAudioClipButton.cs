using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayAudioClipButton : MonoBehaviour
{
    public AudioManager.AudioType ClipToPlay;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(() => GameManager.Instance.AudioManager.PlayAudio(ClipToPlay));
    }
}
