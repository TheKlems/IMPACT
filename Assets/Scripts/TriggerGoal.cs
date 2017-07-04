using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoal : MonoBehaviour {

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name.Contains("Ball"))
        {
            Debug.Log("GOAL !!!");
            Destroy(col.gameObject);
        }
    }
}
