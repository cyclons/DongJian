using System.Collections;
using System.Collections.Generic;
using InsightAR;
using UnityEngine;

public class switchCamera : MonoBehaviour {

    public void OnSwitchButtonClick()
    {
        InsightARInterface.GetInterface().SwitchCamera();
    }
}
