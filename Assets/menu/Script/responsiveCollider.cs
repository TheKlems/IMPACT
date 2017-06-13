using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class responsiveCollider : MonoBehaviour {

    public GameObject palette;
    public GameObject parent;

    // Update is called once per frame
    void Update () {
        palette.GetComponent<BoxCollider2D>().size = new Vector2(parent.GetComponent<RectTransform>().rect.width, parent.GetComponent<RectTransform>().rect.height);
    }
}
