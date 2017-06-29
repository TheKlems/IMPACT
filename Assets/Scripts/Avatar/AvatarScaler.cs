using UnityEngine;
using Kinect = Windows.Kinect;

public class AvatarScaler : MonoBehaviour {


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

    /// <summary>
    /// Scale the length and thickness of the avatar
    /// </summary>
    /// <returns>Void</returns>
    public void Scale(GameObject bodyObject, Transform[] _JointRig)
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
}
