using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Vector3 offset;
    public Transform player;
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, transform.position.y, player.position.z + offset.z);  
    }
}
