using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccerManager : MonoBehaviour {

    public GameObject ballPrefab;
    private GameObject ball;
    public GameObject player;

    private Vector3 playerPos;
    private Vector3 playerDirection;
    private Quaternion playerRotation;
    private float spawnDistance = 0.8f;

    private Vector3 spawnPos;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("r"))
        {
            /*
            Vector3 playerPos = player.transform.position;
            
            Vector3 playerDirection = player.transform.forward;
            
            Quaternion playerRotation = player.transform.rotation;
            
            Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
            
            ball = Instantiate(ballPrefab, spawnPos, playerRotation) as GameObject;
            */
            return;
        }



    }
}
