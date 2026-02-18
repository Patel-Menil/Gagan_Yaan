using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mat {
    Void,
    Interior
}

public class ButtonScripts : MonoBehaviour
{
    [Header("Materials")]
    public Material VoidMat;
    public Material Interior;


    public void SetVoidSkybox() {
        if (VoidMat == null) return;

        RenderSettings.skybox = VoidMat;
        DynamicGI.UpdateEnvironment();
    }

    public void SetInteriorSkybox() {
        if (Interior == null) return;

        RenderSettings.skybox = Interior;
        DynamicGI.UpdateEnvironment();
    }


    public void Log() {
        Debug.Log("OPut");
    }

}


