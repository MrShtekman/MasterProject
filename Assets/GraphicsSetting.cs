using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GraphicsSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //UnityEngine.XR.XRSettings.eyeTextureResolutionScale = 1.3f;
        XRSettings.eyeTextureResolutionScale = 1.3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
