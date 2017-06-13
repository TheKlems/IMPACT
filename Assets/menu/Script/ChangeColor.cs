using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    private GameObject ColorPickerToUse;
	private Renderer[] Renderer;
    private ColorPickerUnityUI skinColor;

    void Start()
    {
        ColorPickerToUse = GameObject.FindWithTag("ColorPicker");
    }

	void Update () {

        Renderer = GetComponentsInChildren<Renderer>();
        skinColor = ColorPickerToUse.GetComponent<ColorPickerUnityUI>();
        foreach (var r in Renderer)
        {
            r.material.color = skinColor.value;
            //Debug.Log(r.material.color.ToString());            

        }
    }
}
