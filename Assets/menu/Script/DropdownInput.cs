using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownInput : MonoBehaviour {

    List<string> ModalityLabel = new List<string>() { "Fullbody", "LegLeft", "LegRight", "ArmLeft", "ArmRight" };

    public Dropdown dropdown;
    public int selectedInput = 0;

    /// <summary>
    /// Event handler for the modality dropdown.
    /// </summary>
    /// <returns>Void</returns>
    public void Dropdown_Input(int index)
    {
        switch (index)
        {
            case 0:
                selectedInput = 0;
                break;

            case 1:
                selectedInput = 1;
                break;

            case 2:
                selectedInput = 2;
                break;

            case 3:
                selectedInput = 3;
                break;

            case 4:
                selectedInput = 4;
                break;

            default:
                selectedInput = 0;
                break;
        }
    }

    void Start()
    {
        dropdown.AddOptions(ModalityLabel); // We add the modality options in the dropdown
    }
}
