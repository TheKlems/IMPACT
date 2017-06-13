using UnityEngine;
using Kinect = Windows.Kinect;

public class ChangeExercise : MonoBehaviour {

    private AvatarController _AvatarController;
    private AvatarController.ExercisesEnum LastExercise;
    private FullBodyController _FullBodyController;
    private LegLeftController _LegLeftController;
    private LegRightController _LegRightController;
    private ArmLeftController _ArmLeftController;
    private ArmRightController _ArmRightController;

    void Start()
    {
        _AvatarController = GetComponent<AvatarController>();
        _FullBodyController = GetComponent<FullBodyController>();
        _LegLeftController = GetComponent<LegLeftController>();
        _LegRightController = GetComponent<LegRightController>();
        _ArmLeftController = GetComponent<ArmLeftController>();
        _ArmRightController = GetComponent<ArmRightController>();
    }

    /// <summary>
    /// Apply required modifications when we change of exercise.
    /// </summary>
    /// <returns>Void</returns>
    public void Change(Kinect.Body body, Transform[] _JointRig)
    {
        if (_AvatarController.Exercises == AvatarController.ExercisesEnum.FullBody)
        {
            if (LastExercise != _AvatarController.Exercises)
            {
                _AvatarController.LegLeft = true;
                _AvatarController.LegRight = true;
                _AvatarController.ArmLeft = true;
                _AvatarController.ArmRight = true;
            }
            _FullBodyController.FullBody(body, _JointRig);
        }
        else if (_AvatarController.Exercises == AvatarController.ExercisesEnum.LegLeft)
        {
            if (LastExercise != _AvatarController.Exercises)
            {
                _AvatarController.LegLeft = true;
                _AvatarController.LegRight = true;
                _AvatarController.ArmLeft = false;
                _AvatarController.ArmRight = false;
            }
            _LegLeftController.LegLeft(body, _JointRig);
        }
        else if (_AvatarController.Exercises == AvatarController.ExercisesEnum.LegRight)
        {
            if (LastExercise != _AvatarController.Exercises)
            {
                _AvatarController.LegLeft = true;
                _AvatarController.LegRight = true;
                _AvatarController.ArmLeft = false;
                _AvatarController.ArmRight = false;
            }
            _LegRightController.LegRight(body, _JointRig);
        }
        else if (_AvatarController.Exercises == AvatarController.ExercisesEnum.ArmLeft)
        {
            if (LastExercise != _AvatarController.Exercises)
            {
                _AvatarController.LegLeft = false;
                _AvatarController.LegRight = false;
                _AvatarController.ArmLeft = true;
                _AvatarController.ArmRight = true;
            }
            _ArmLeftController.ArmLeft(body, _JointRig);
        }
        else if (_AvatarController.Exercises == AvatarController.ExercisesEnum.ArmRight)
        {
            if (LastExercise != _AvatarController.Exercises)
            {
                _AvatarController.LegLeft = false;
                _AvatarController.LegRight = false;
                _AvatarController.ArmLeft = true;
                _AvatarController.ArmRight = true;
            }
            _ArmRightController.ArmRight(body, _JointRig);
        }

        LastExercise = _AvatarController.Exercises;
        return;
    }

    /// <summary>
    /// Show or Hide Members 
    /// </summary>
    /// <returns>Void</returns>
    public void ShowOrHideMember(GameObject bodyObject)
    {

        if (_AvatarController.ArmLeft)
        {
            bodyObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            bodyObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (_AvatarController.ArmRight)
        {
            bodyObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            bodyObject.transform.GetChild(2).gameObject.SetActive(false);
        }
        if (_AvatarController.LegLeft)
        {
            bodyObject.transform.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            bodyObject.transform.GetChild(3).gameObject.SetActive(false);
        }
        if (_AvatarController.LegRight)
        {
            bodyObject.transform.GetChild(4).gameObject.SetActive(true);
        }
        else
        {
            bodyObject.transform.GetChild(4).gameObject.SetActive(false);
        }

        return;
    }
}
