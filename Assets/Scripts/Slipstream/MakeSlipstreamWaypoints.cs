﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSlipstreamWaypoints : MonoBehaviour {
    public float spawnTime;
    private float spawnTimer;
    public Transform waypointObject;
    public GameObject playerObject;


    void Start() {
        spawnTimer = spawnTime;
    }

    void Update() {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0) {
            SpawnWaypoint();
        }
    }

    private void SpawnWaypoint() {
        spawnTimer = spawnTime;
        Transform newWaypoint = Instantiate(waypointObject, playerObject.transform.position, playerObject.transform.rotation) as Transform;
        UpdateFollowerWaypoints(newWaypoint);
    }

    private void UpdateFollowerWaypoints(Transform newWaypoint) {
        GameObject[] followers = GameObject.FindGameObjectsWithTag("Follower");
        FollowSlipstream followSlipstream;
        for(int i = 0; i < followers.Length; i++) {
            followSlipstream = followers[i].GetComponent<FollowSlipstream>();
            followSlipstream.AddWaypoint(newWaypoint);
        }
    }
}
