using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;
    public Vector3 cameraOffset;

    void Update()
    {
        Vector3 pos = player.transform.position;
        pos += cameraOffset;
        transform.position = pos;
        transform.LookAt(player.transform);
    }
}
