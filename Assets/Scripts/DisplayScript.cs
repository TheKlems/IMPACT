using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScript : MonoBehaviour {

    void Start()
    {

        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        //Display.displays[2].Activate();
        //Debug.Log("displays connected: " + Display.displays.Length);
    }
}
