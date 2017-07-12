using System;
using UnityEngine;
using UnityEngine.UI;
using Kinect = Windows.Kinect;

public class AvatarScaler : MonoBehaviour {

    //public float patientHeightInMeter = 1.85f;

    public string patientHeightInMeter{ get; set; }
    private float patientHeightFloat;
    private float scaleFactor;
    public Text heigthInput;
    public GameObject testObject;
    private Color grayText = new Color(0.2F, 0.2F, 0.2F, 1F);

    //[Range(1f, 2f)]
    //public float membersLength = 1f;
    public float membersLength { get; set; }

    //[Range(1f, 2f)]
    //public float membersThickness = 1f;
    public float membersThickness { get; set; }

    private Transform shoulderLeft;
    private Transform shoulderRigth;
    private Transform legLeft;
    private Transform legRight;

    void Start()
    {
        membersLength = 1f;
        membersThickness = 1f;
        patientHeightFloat = 1.85f;
    }

    /// <summary>
    /// Scale the length and thickness of the avatar
    /// </summary>
    /// <returns>Void</returns>
    public void Scale(Transform[] _JointRig)
    {
        shoulderLeft = _JointRig[4];
        shoulderRigth = _JointRig[8];
        legLeft = _JointRig[12];
        legRight = _JointRig[16];

        shoulderLeft.localScale = new Vector3(membersLength, membersThickness, membersThickness);
        shoulderRigth.localScale = new Vector3(membersLength, membersThickness, membersThickness);

        legLeft.localScale = new Vector3(membersThickness, membersLength, membersThickness);
        legRight.localScale = new Vector3(membersThickness, membersLength, membersThickness);
        return;
    }

    /// <summary>
    /// Get the height of the patient from the input field in the menu and check if the input is correct
    /// </summary>
    /// <returns>Void</returns>
    public void getHeightInput(string sInput)
    {
        if (float.TryParse(sInput, out patientHeightFloat))
        {
            patientHeightFloat = float.Parse(sInput);
            heigthInput.color = grayText;
        }
        else
        {
            patientHeightFloat = 1.85f;
            heigthInput.color = Color.red;
        }
    }

    /// <summary>
    /// Scale test
    /// </summary>
    /// <returns>Void</returns>
    public void ScaleAvatar(GameObject bodyObject)
    {
            scaleFactor = (13.8f / 1.77f) * patientHeightFloat;
            testObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        return;
    }

}
