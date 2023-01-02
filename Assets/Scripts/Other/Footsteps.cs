using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    AudioSource source;

    AudioManager.AudioType type;


    [SerializeField]
    Transform origin;
    [SerializeField]
    float radius;
    [SerializeField]
    LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        source = GameManager.Instance.AudioManager.GetSource(AudioManager.SourceType.Footsteps);
    }

    // Update is called once per frame
    void Update()
    {
        var isMoving = Input.GetAxis("Horizontal") != 0;

        type = GetAudioType();
        if (isMoving && !source.isPlaying)
        {
            GameManager.Instance.AudioManager.PlayAudio(type);
        }
        if (!isMoving && source.isPlaying)
        {
            GameManager.Instance.AudioManager.StopAudio(type);
        }
    }

    private AudioManager.AudioType GetAudioType()
    {
        var coll = Physics2D.OverlapCircle(origin.position, radius, layerMask);
        if (coll == null)
            return AudioManager.AudioType.None;

        if (coll.gameObject.layer == LayerMask.NameToLayer("Ground")) 
            return AudioManager.AudioType.GravelFootsteps;
        if (coll.gameObject.layer == LayerMask.NameToLayer("WoodGround"))
            return AudioManager.AudioType.WoodFootsteps;

        return AudioManager.AudioType.None;

    }
}
