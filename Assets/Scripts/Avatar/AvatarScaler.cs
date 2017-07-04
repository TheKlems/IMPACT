using UnityEngine;
using Kinect = Windows.Kinect;

public class AvatarScaler : MonoBehaviour {

    public float patientHeightInMeter = 1.85f;

    private float scaleFactor;

    //[Range(1f, 2f)]
    //public float membersLength = 1f;
    public float membersLength { get; set; }

    //[Range(1f, 2f)]
    //public float membersThickness = 1f;
    public float membersThickness { get; set; }

    void Start()
    {
        membersLength = 1f;
        membersThickness = 1f;
    }

    private Transform shoulderLeft;
    private Transform shoulderRigth;
    private Transform legLeft;
    private Transform legRight;

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
    /// Scale test
    /// </summary>
    /// <returns>Void</returns>
    public void ScaleAvatar(GameObject bodyObject)
    {
        scaleFactor = (13.8f / 1.77f) * patientHeightInMeter;
        bodyObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

        return;
    }
}
