using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWave : MonoBehaviour {

    private Transform player;

    void Start()
    {
        player = GameObject.Find("Wave").transform;
    }

    void Update()
    {
        float currentaxis = player.position.x;
        Vector3 playerpos = new Vector3(currentaxis, 0.0f);
        playerpos.z = transform.position.z;
        transform.position = playerpos;
    }
}
