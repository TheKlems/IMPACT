using UnityEngine;
using Kinect = Windows.Kinect;

public class FullBodyController : MonoBehaviour {

    private AvatarController _AvatarController;
    private BoneConstraints _BoneConstraints;

    /// <summary>
    /// Apply the required rotations on the joints for the exercise "FullBody"
    /// </summary>
    /// <returns>Void</returns>
    public void FullBody(Kinect.Body body, Transform[] _JointRig)
    {
        _AvatarController = GetComponent<AvatarController>();
        _BoneConstraints = GetComponent<BoneConstraints>();

        int RigIndex = 0;
        if (!_AvatarController.Mirrored)
        {
            for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
            {
                if (_AvatarController._JointReference.ContainsKey(RigIndex))
                {
                    Quaternion newRotation = _AvatarController.JointOrientation(body, jt);
                    newRotation *= _AvatarController._EulerOrientations[RigIndex];
                    newRotation = _BoneConstraints.clampBone(newRotation, jt.ToString(), _AvatarController.Mirrored); //Clamp the bone rotation
                    _AvatarController.SetSmoothFactor(RigIndex, newRotation, _JointRig, _AvatarController._JointReference[RigIndex]);
                }

                RigIndex++;
            }
        }
        else
        {
            for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
            {
                if (_AvatarController._JointReference.ContainsKey(RigIndex))
                {
                    Quaternion newRotation;
                    if (RigIndex == 1 || RigIndex == 2 || RigIndex == 20)
                    {
                        newRotation = _AvatarController.JointOrientation(body, jt);
                    }
                    else
                    {
                        newRotation = _AvatarController.JointOrientationMirrored(body, jt);
                    }
                    newRotation *= _AvatarController._EulerOrientationsModeMirrored[RigIndex];
                    newRotation = _BoneConstraints.clampBone(newRotation, jt.ToString(), _AvatarController.Mirrored); //Clamp the bone rotation
                    _AvatarController.SetSmoothFactor(RigIndex, newRotation, _JointRig, _AvatarController._JointReferenceModeMirrored[RigIndex]);
                }

                RigIndex++;
            }
        }
        return;
    }
}
