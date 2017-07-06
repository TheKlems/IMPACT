using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour {
    private AudioSource winSound;

    private void Start()
    {
        winSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "goal")
        {
            winSound.Play();
            Destroy(this.gameObject);
        }
        else if (col.gameObject.name == "outZoneLeft" || col.gameObject.name == "outZoneRight")
        {
            Debug.Log("Missed !");
            Destroy(this.gameObject);
        }
    }
}
