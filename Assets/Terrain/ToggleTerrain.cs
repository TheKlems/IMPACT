using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTerrain : MonoBehaviour {

    //  Hide the terrain if OvrVision is ON, otherwise, it shows it
    public AvatarController controller;
    public GameObject terrain;
    public GameObject windZone;

	// Update is called once per frame
	void Update () {

            if (controller.Ovrvision)
            {
                terrain.gameObject.SetActive(false);
                windZone.gameObject.SetActive(false);
            }
            else
            {
                terrain.gameObject.SetActive(true);
                windZone.gameObject.SetActive(true);
            }
        
    }
}
