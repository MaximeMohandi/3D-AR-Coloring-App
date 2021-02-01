using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opacityPlane : MonoBehaviour
{
    public float opacity;

    // Start is called before the first frame update
    void Start() {
        Material planeMaterial = this.GetComponent<MeshRenderer>().material;
        Color planeColor = planeMaterial.color;
        planeColor.a = opacity;
        planeMaterial.color = planeColor;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
