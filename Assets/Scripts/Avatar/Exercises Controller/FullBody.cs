using UnityEngine;
using Kinect = Windows.Kinect;

public class FullBody : MonoBehaviour
{
    private AvatarController _AvatarController;
    //private ResetJointRotation _ResetJointRotation;
    //private BoneConstraints _BoneConstraints;

    private int boneIndex;

    /// <summary>
    /// Apply the required rotations on the joints for the exercise "FullBody"
    /// </summary>
    /// <returns>Void</returns>
    public void ApplyRotation(Kinect.Body body, Transform[] _JointRig)
    {
        _AvatarController = GetComponent<AvatarController>();
        //_ResetJointRotation = GetComponent<ResetJointRotation>();
        //_BoneConstraints = GetComponent<BoneConstraints>();

        int RigIndex = 0;
        if (!_AvatarController.Mirrored)
        {
            for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
            {
                if (_AvatarController._JointReference.ContainsKey(RigIndex))
                {
                    boneIndex = RigIndex + _AvatarController._JointReference[RigIndex];

                    Quaternion newRotation = _AvatarController.JointOrientation(body, jt);
                    newRotation *= _AvatarController._EulerOrientations[boneIndex];

                    //Quaternion localRot = Quaternion.Inverse(_JointRig[parent].rotation) * newRotation;
                    //newRotation = _BoneConstraints.limitBone(_JointRig[boneIndex].rotation, newRotation, localRot, boneIndex, _AvatarController.Mirrored); //Clamp the bone rotation

                    _AvatarController.SetSmoothFactor(boneIndex, newRotation, _JointRig);
                    //_ResetJointRotation.ResetRotation(_JointRig, boneIndex);
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
                    boneIndex = RigIndex + _AvatarController._JointReferenceModeMirrored[RigIndex];

                    Quaternion newRotation;
                    if (boneIndex == 0 || boneIndex == 1 || boneIndex == 2 || boneIndex == 20)
                    {
                        newRotation = _AvatarController.JointOrientation(body, jt);
                    }
                    else
                    {
                        newRotation = _AvatarController.JointOrientationMirrored(body, jt);
                    }
                    newRotation *= _AvatarController._EulerOrientations[boneIndex];

                    //Quaternion localRot = Quaternion.Inverse(_JointRig[parent].rotation) * newRotation;
                    //newRotation = _BoneConstraints.limitBone(_JointRig[boneIndex].rotation, newRotation, localRot, boneIndex, _AvatarController.Mirrored); //Clamp the bone rotation

                    _AvatarController.SetSmoothFactor(boneIndex, newRotation, _JointRig);
                    //_ResetJointRotation.ResetRotation(_JointRig, boneIndex);
                }

                RigIndex++;
            }
        }
        return;
    }
}
