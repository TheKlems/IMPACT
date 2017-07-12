using UnityEngine;
using UnityEngine.UI;
using Kinect = Windows.Kinect;

public class ChangeModality : MonoBehaviour {

    private AvatarController _AvatarController;
    private AvatarController.ModalityEnum LastModality;
    private DropdownInput _DropdownInput;
    
    private FullBody _FullBody;
    private LegLeft _LegLeft;
    private LegRight _LegRight;
    private ArmLeft _ArmLeft;
    private ArmRight _ArmRight;

    public Toggle ArmLeft;
    public Toggle ArmRight;
    public Toggle LegLeft;
    public Toggle LegRight;

    private int selectedModality = 0;

    void Start()
    {
        _AvatarController = GetComponent<AvatarController>();
        _DropdownInput = GetComponent<DropdownInput>();

        _FullBody = GetComponent<FullBody>();
        _LegLeft = GetComponent<LegLeft>();
        _LegRight = GetComponent<LegRight>();
        _ArmLeft = GetComponent<ArmLeft>();
        _ArmRight = GetComponent<ArmRight>();

    }

    /// <summary>
    /// Apply the required rotations to the bones according to the selected modality.
    /// </summary>
    /// <returns>Void</returns>
    public void ApplyModality(Kinect.Body body, Transform[] _JointRig)
    {
        selectedModality = _DropdownInput.selectedInput;

        switch (selectedModality)
        {
            case 0: //Fullbody
                if (LastModality != _AvatarController.Modality)
                {
                    _AvatarController.LegLeft = true;
                    _AvatarController.LegRight = true;
                    _AvatarController.ArmLeft = true;
                    _AvatarController.ArmRight = true;

                    // check or uncheck the checkboxes according to the modality
                    ArmLeft.isOn = true;
                    ArmRight.isOn = true;
                    LegLeft.isOn = true;
                    LegRight.isOn = true;
                }
              
                _FullBody.ApplyRotation(body, _JointRig);

                break;

            case 1: // Left leg
                if (LastModality != _AvatarController.Modality)
                {
                    _AvatarController.LegLeft = true;
                    _AvatarController.LegRight = true;
                    _AvatarController.ArmLeft = false;
                    _AvatarController.ArmRight = false;

                    // check or uncheck the checkboxes according to the modality
                    ArmLeft.isOn = false;
                    ArmRight.isOn = false;
                    LegLeft.isOn = true;
                    LegRight.isOn = true;

                }

                _LegLeft.ApplyRotation(body, _JointRig);

                break;

            case 2: // Right leg
                if (LastModality != _AvatarController.Modality)
                {
                    _AvatarController.LegLeft = true;
                    _AvatarController.LegRight = true;
                    _AvatarController.ArmLeft = false;
                    _AvatarController.ArmRight = false;

                    // check or uncheck the checkboxes according to the modality
                    ArmLeft.isOn = false;
                    ArmRight.isOn = false;
                    LegLeft.isOn = true;
                    LegRight.isOn = true;
                }
                _LegRight.ApplyRotation(body, _JointRig);

                break;

            case 3: // Left arm
                if (LastModality != _AvatarController.Modality)
                {
                    _AvatarController.LegLeft = false;
                    _AvatarController.LegRight = false;
                    _AvatarController.ArmLeft = true;
                    _AvatarController.ArmRight = true;

                    // check or uncheck the checkboxes according to the modality
                    ArmLeft.isOn = true;
                    ArmRight.isOn = true;
                    LegLeft.isOn = false;
                    LegRight.isOn = false;
                }

                _ArmLeft.ApplyRotation(body, _JointRig);

                break;

            case 4: // Right arm
                if (LastModality != _AvatarController.Modality)
                {
                    _AvatarController.LegLeft = false;
                    _AvatarController.LegRight = false;
                    _AvatarController.ArmLeft = true;
                    _AvatarController.ArmRight = true;

                    // check or uncheck the checkboxes according to the modality
                    ArmLeft.isOn = true;
                    ArmRight.isOn = true;
                    LegLeft.isOn = false;
                    LegRight.isOn = false;
                }

                _ArmRight.ApplyRotation(body, _JointRig);

                break;

            default: // Same as fullbody
                if (LastModality != _AvatarController.Modality)
                {
                    _AvatarController.LegLeft = true;
                    _AvatarController.LegRight = true;
                    _AvatarController.ArmLeft = true;
                    _AvatarController.ArmRight = true;

                    // check or uncheck the checkboxes according to the modality
                    ArmLeft.isOn = true;
                    ArmRight.isOn = true;
                    LegLeft.isOn = true;
                    LegRight.isOn = true;
                }

                _FullBody.ApplyRotation(body, _JointRig);

                break;
        }

        LastModality = _AvatarController.Modality;
        return;
    }

    /*
    /// <summary>
    /// Apply required modifications when we change the modality.
    /// </summary>
    /// <returns>Void</returns>
    public void Change(Kinect.Body body, Transform[] _JointRig)
    {
        if (_AvatarController.Modality == AvatarController.ModalityEnum.FullBody) // Si modalité == fullbody
        {
            if (LastModality != _AvatarController.Modality)
            {
                _AvatarController.LegLeft = true;
                _AvatarController.LegRight = true;
                _AvatarController.ArmLeft = false;
                _AvatarController.ArmRight = false;
            }
            _FullBody.ApplyRotation(body, _JointRig);
        }
        else if (_AvatarController.Modality == AvatarController.ModalityEnum.LegLeft)
        {
            if (LastModality != _AvatarController.Modality)
            {
                _AvatarController.LegLeft = true;
                _AvatarController.LegRight = true;
                _AvatarController.ArmLeft = false;
                _AvatarController.ArmRight = false;
            }
            _LegLeft.ApplyRotation(body, _JointRig);
        }
        else if (_AvatarController.Modality == AvatarController.ModalityEnum.LegRight)
        {
            if (LastModality != _AvatarController.Modality)
            {
                _AvatarController.LegLeft = true;
                _AvatarController.LegRight = true;
                _AvatarController.ArmLeft = false;
                _AvatarController.ArmRight = false;
            }
            _LegRight.ApplyRotation(body, _JointRig);
        }
        else if (_AvatarController.Modality == AvatarController.ModalityEnum.ArmLeft)
        {
            if (LastModality != _AvatarController.Modality)
            {
                _AvatarController.LegLeft = false;
                _AvatarController.LegRight = false;
                _AvatarController.ArmLeft = true;
                _AvatarController.ArmRight = true;
            }
            _ArmLeft.ApplyRotation(body, _JointRig);
        }
        else if (_AvatarController.Modality == AvatarController.ModalityEnum.ArmRight)
        {
            if (LastModality != _AvatarController.Modality)
            {
                _AvatarController.LegLeft = false;
                _AvatarController.LegRight = false;
                _AvatarController.ArmLeft = true;
                _AvatarController.ArmRight = true;
            }
            _ArmRight.ApplyRotation(body, _JointRig);
        }

        LastModality = _AvatarController.Modality;
        return;
    }
    */

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
