using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutPlace : MonoBehaviour
{

    //public bool HasFood=false;

    public enum cutState
    {
        nofood,
        hasfood,
        foodOk
    }
    public GameObject displayThings;
    public cutState CurrentState=cutState.nofood;
    public float cutProcess=0;
    public Slider ProcesSlider;

    void Update()
    {
        if (CurrentState==cutState.foodOk||CurrentState==cutState.hasfood)
        {
            displayThings.SetActive(true);
        }
        else
        {
            displayThings.SetActive(false);
        }
    }

    public void DoCut()
    {
        cutProcess += 26;
        ProcesSlider.value = Mathf.Clamp(cutProcess / 100, 0, 1.01f);
    }

}
