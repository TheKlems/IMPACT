using UnityEngine;
using Kinect = Windows.Kinect;

public class AvatarScaler : MonoBehaviour {

    private int frame = 1;
    private float totalAfter100frames = 0;
    private float averageDistanceKneeAnkle = 0;

    /// <summary>
    /// Scale the avatar body like our real body.
    /// </summary>
    /// <returns>Void</returns>
    public void Scale(Kinect.Body body, GameObject bodyObject, Transform[] _JointRig)
    {
        if (frame <= 100)
        {
            //distance between Head and Ankle (virtual avatar)
            float dist_JointRig = Vector3.Distance(_JointRig[13].position, _JointRig[3].position);

            Kinect.Joint HeadJoint = body.Joints[Kinect.JointType.Head];
            Kinect.Joint AnkleLeftJoint = body.Joints[Kinect.JointType.AnkleLeft];
            Vector3 HeadPosition = new Vector3(HeadJoint.Position.X, HeadJoint.Position.Y, HeadJoint.Position.Z);
            Vector3 AnkleLeftPosition = new Vector3(AnkleLeftJoint.Position.X, AnkleLeftJoint.Position.Y, AnkleLeftJoint.Position.Z);

            //distance between Head and Ankle (our body, Kinect)
            float distHeadAnkle = Vector3.Distance(HeadPosition, AnkleLeftPosition);

            totalAfter100frames += distHeadAnkle;

            if (frame == 100)
            {
                averageDistanceKneeAnkle = totalAfter100frames / frame;

                float scaleFactor = averageDistanceKneeAnkle / dist_JointRig;

                //scale the body
                bodyObject.transform.localScale = new Vector3(bodyObject.transform.localScale.x * scaleFactor, bodyObject.transform.localScale.y * scaleFactor, bodyObject.transform.localScale.z * scaleFactor);
            }
            frame += 1;
        }
        return;
    }
}
