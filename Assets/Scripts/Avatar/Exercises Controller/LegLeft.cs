using UnityEngine;
using Kinect = Windows.Kinect;

public class LegLeft : MonoBehaviour {

    private AvatarController _AvatarController;

    private int boneIndex;
    private int boneIndexMirrored;

    /// <summary>
    /// Apply the required rotations on the joints for the exercise "LegLeft"
    /// </summary>
    /// <returns>Void</returns>
    public void ApplyRotation(Kinect.Body body, Transform[] _JointRig)
    {
        _AvatarController = GetComponent<AvatarController>();

        int RigIndex = 0;
        for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
        {
            if (RigIndex == 0 || RigIndex == 1 || boneIndex == 2 || RigIndex == 20)
            {
                boneIndex = RigIndex + _AvatarController._JointReference[RigIndex];
                Quaternion newRotation = _AvatarController.JointOrientation(body, jt);
                newRotation *= _AvatarController._EulerOrientations[boneIndex];
                _AvatarController.SetSmoothFactor(boneIndex, newRotation, _JointRig);
            }
            if (RigIndex == 13 || RigIndex == 14)
            {
                boneIndex = RigIndex + _AvatarController._JointReference[RigIndex];
                boneIndexMirrored = RigIndex + _AvatarController._JointReferenceModeMirrored[RigIndex];
                Quaternion newRotation = _AvatarController.JointOrientation(body, jt);
                newRotation *= _AvatarController._EulerOrientations[boneIndex];
                _AvatarController.SetSmoothFactor(boneIndex, newRotation, _JointRig);
                Quaternion newRotationMirrored = _AvatarController.JointOrientationMirrored(body, jt);
                newRotationMirrored *= _AvatarController._EulerOrientations[boneIndexMirrored];
                _AvatarController.SetSmoothFactor(boneIndexMirrored, newRotationMirrored, _JointRig);
            }

            RigIndex++;
        }
        return;
    }
}
