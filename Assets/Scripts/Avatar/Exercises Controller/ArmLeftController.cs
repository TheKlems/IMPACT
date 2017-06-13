using UnityEngine;
using Kinect = Windows.Kinect;

public class ArmLeftController : MonoBehaviour {

    private AvatarController _AvatarController;

    /// <summary>
    /// Apply the required rotations on the joints for the exercise "ArmLeft"
    /// </summary>
    /// <returns>Void</returns>
    public void ArmLeft(Kinect.Body body, Transform[] _JointRig)
    {
        _AvatarController = GetComponent<AvatarController>();

        int RigIndex = 0;
        for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
        {
            if (RigIndex == 0 || RigIndex == 1 || RigIndex == 20)
            {
                Quaternion newRotation = _AvatarController.JointOrientation(body, jt);
                newRotation *= _AvatarController._EulerOrientations[RigIndex];
                _AvatarController.SetSmoothFactor(RigIndex, newRotation, _JointRig, _AvatarController._JointReference[RigIndex]);
            }
            if (RigIndex == 5 || RigIndex == 6 || RigIndex == 7)
            {
                Quaternion newRotation = _AvatarController.JointOrientation(body, jt);
                newRotation *= _AvatarController._EulerOrientations[RigIndex];
                _AvatarController.SetSmoothFactor(RigIndex, newRotation, _JointRig, _AvatarController._JointReference[RigIndex]);
                Quaternion newRotationMirrored = _AvatarController.JointOrientationMirrored(body, jt);
                newRotationMirrored *= _AvatarController._EulerOrientationsModeMirrored[RigIndex];
                _AvatarController.SetSmoothFactor(RigIndex, newRotationMirrored, _JointRig, _AvatarController._JointReferenceModeMirrored[RigIndex]);
            }

            RigIndex++;
        }
        return;
    }
}
