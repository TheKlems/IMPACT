using System.Collections.Generic;
using UnityEngine;

public class BoneLimits : MonoBehaviour
{
    public GameObject source;
    public Avatar destinationavatar;
    public bool useLimits = true;

    private HumanPoseHandler sourcehandler;
    private HumanPoseHandler destinationhandler;

    private HumanPose humanPose;

    //This dictionary contains references of the bones of the instantiated body
    private Dictionary<int, float> _Muscles = new Dictionary<int, float>();

    public void InitPose(GameObject FullBodySource)
    {
        source = FullBodySource;
        humanPose = new HumanPose();
        sourcehandler = new HumanPoseHandler(source.GetComponent<Animator>().avatar, source.transform);
        destinationhandler = new HumanPoseHandler(destinationavatar, transform);
    }

    void Start()
    {
        int i = 0;
        while (i < HumanTrait.MuscleCount)
        {
            _Muscles[i] = 0;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sourcehandler == null || destinationhandler == null)
        {
            return;
        }
        sourcehandler.GetHumanPose(ref humanPose);

        if (useLimits)
        {
            int i = 0;
            while (i < HumanTrait.MuscleCount)
            {
                float detectedValue = humanPose.muscles[i];
                if (detectedValue >= -1 && detectedValue <= 1)
                {
                    _Muscles[i] = detectedValue;
                    humanPose.muscles[i] = detectedValue;
                }
                else
                {
                    humanPose.muscles[i] = _Muscles[i];
                }

                i++;
            }
        }

        destinationhandler.SetHumanPose(ref humanPose);
    }
}
