using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccerManager : MonoBehaviour {

    public GameObject ballPrefab;
    GameObject ball;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("r"))
        {
            ball = Instantiate(ballPrefab) as GameObject;
        }

    }
}
