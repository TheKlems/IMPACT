using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneConstraints : MonoBehaviour {
    [Range(-360f, 360f)]
    public float xAngleMin;

    [Range(-360f, 360f)]
    public float xAngleMax;

    [Range(-360f, 360f)]
    public float yAngleMin;

    [Range(-360f, 360f)]
    public float yAngleMax;

    [Range(-360f, 360f)]
    public float zAngleMin;

    [Range(-360f, 360f)]
    public float zAngleMax;

    //{ xAngleMin, xAngleMax, yAngleMin, yAngleMax, zAngleMin, zAngleMax}

    //int[minX, maxX, minY, maxY, minZ, maxZ] --> clamping system for the bone constraints
    private Dictionary<string, float[]> _boneConstraints = new Dictionary<string, float[]>()
    {
        //Spine and head
        {"SpineBase", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"SpineMid", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"Neck", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"Head", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"SpineShoulder", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        
        //Left arm
        {"ShoulderLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"ElbowLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"WristLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"HandLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"HandTipLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"ThumbLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},

        //Right arm 
        {"ShoulderRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"ElbowRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}}, 
        {"WristRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"HandRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"HandTipRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"ThumbRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},

        //Left leg
        {"HipLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"KneeLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"AnkleLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"FootLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},

        //Right leg
        {"HipRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"KneeRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"AnkleRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}}, //{ -360f, 360f, 200f, -156f, -44f, -4f}
        {"FootRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}}
    };

    //int[minX, maxX, minY, maxY, minZ, maxZ] --> clamping system for the bone constraints
    private Dictionary<string, float[]> _boneConstraintsMirrored = new Dictionary<string, float[]>()
    {
        //Spine and head
        {"SpineBase", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"SpineMid", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"Neck", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"Head", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"SpineShoulder", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        
        //Left arm
        {"ShoulderLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"ElbowLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"WristLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"HandLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"HandTipLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"ThumbLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},

        //Right arm --> DONE
        {"ShoulderRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"ElbowRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"WristRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"HandRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"HandTipRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"ThumbRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},

        //Left leg
        {"HipLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"KneeLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"AnkleLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}}, //{ -360f, 360f, 116f, 147f, -13f, 9f}
        {"FootLeft", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},

        //Right leg
        {"HipRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"KneeRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}},
        {"AnkleRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}}, //{ -360f, 360f, 200f, -151f, -47f, -8f}
        {"FootRight", new float[] { -360f, 360f, -360f, 360f, -360f, 360f}}
    };

    void Update()
    {
        //_boneConstraints["AnkleLeft"] = new float[] { xAngleMin, xAngleMax, yAngleMin, yAngleMax, zAngleMin, zAngleMax};
        //_boneConstraints["AnkleLeft"] = new float[] { xAngleMin, xAngleMax, yAngleMin, yAngleMax, zAngleMin, zAngleMax };
    }

    /// <summary>
    /// Clamp the specified bone rotation to avoid bone dislocations
    /// </summary>
    /// <returns>Void</returns>
    public Quaternion clampBone(Quaternion currentRotation, string boneName, bool mirrored)
    {
        
        Vector3 eulerRotation = new Vector3(0f, 0f, 0f);

        float rotationX = currentRotation.eulerAngles.x;
        float rotationY = currentRotation.eulerAngles.y;
        float rotationZ = currentRotation.eulerAngles.z;

        if (mirrored)
        {
            eulerRotation.x = Mathf.Clamp(rotationX, _boneConstraintsMirrored[boneName][0], _boneConstraintsMirrored[boneName][1]);
            eulerRotation.y = Mathf.Clamp(rotationY, _boneConstraintsMirrored[boneName][2], _boneConstraintsMirrored[boneName][3]);
            eulerRotation.z = Mathf.Clamp(rotationZ, _boneConstraintsMirrored[boneName][4], _boneConstraintsMirrored[boneName][5]);
        }
        else
        {
            eulerRotation.x = Mathf.Clamp(rotationX, _boneConstraints[boneName][0], _boneConstraints[boneName][1]);
            eulerRotation.y = Mathf.Clamp(rotationY, _boneConstraints[boneName][2], _boneConstraints[boneName][3]);
            eulerRotation.z = Mathf.Clamp(rotationZ, _boneConstraints[boneName][4], _boneConstraints[boneName][5]);
        }

        Quaternion clampedRotation = Quaternion.Euler(eulerRotation);
        return clampedRotation;
    }
}
