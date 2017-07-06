using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    private GameObject ColorPickerToUse;
	private Renderer[] Renderer;
    private ColorPickerUnityUI skinColor;

    private Renderer rArmRight;
    private Renderer rArmLeft;
    private Renderer rLegRight;
    private Renderer rLegLeft;

    void Start()
    {
        ColorPickerToUse = GameObject.FindWithTag("ColorPicker");
        //Renderer = GetComponentsInChildren<Renderer>();
        skinColor = ColorPickerToUse.GetComponent<ColorPickerUnityUI>();

        var Renderer = this.transform.gameObject.GetComponentsInChildren<Renderer>();
        foreach (var child in Renderer)
        {
            if (child.name.Equals("ArmRight"))
            {
                rArmRight = child;
            }
            if (child.name.Equals("ArmLeft"))
            {
                rArmLeft = child;
            }
            if (child.name.Equals("LegLeft"))
            {
                rLegLeft = child;
            }
            if (child.name.Equals("LegRight"))
            {
                rLegRight = child;
            }
        }
    }

	void Update () {
        /*
        foreach (var child in Renderer)
        {
            child.material.color = skinColor.value;
            //Debug.Log(r.material.color.ToString());            
        }
        */

        rArmRight.material.color = skinColor.value;
        rArmLeft.material.color = skinColor.value;
        rLegRight.material.color = skinColor.value;
        rLegLeft.material.color = skinColor.value;
    }
}
