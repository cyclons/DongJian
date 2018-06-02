using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustHeight : MonoBehaviour
{
    public GameObject Kitchen;
    public void OnUpClick()
    {
        Kitchen.transform.position+=Vector3.up*0.1f;
    }
    public void OnDownClick()
    {
        Kitchen.transform.position -= Vector3.up * 0.1f;
    }
}
