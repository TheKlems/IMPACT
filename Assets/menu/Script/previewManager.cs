using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class previewManager : MonoBehaviour {

    public AvatarController controller;
    public GameObject noOvr;
    public GameObject OvrPreview;
	
	// Update is called once per frame
	void Update () {
		if (controller.Ovrvision)
        {
            noOvr.SetActive(false);
            OvrPreview.SetActive(true);
        }
        else
        {
            noOvr.SetActive(true);
            OvrPreview.SetActive(false);
        }
	}
}
