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
    public GameObject finishedThings;
    public cutState CurrentState=cutState.nofood;
    public float cutProcess=0;
    public Slider ProcesSlider;

    void Start()
    {
        ProcesSlider.value = 0;
    }
    void Update()
    {
        if (CurrentState==cutState.hasfood)
        {
            displayThings.SetActive(true);
            ProcesSlider.gameObject.SetActive(true);
            finishedThings.SetActive(false);
        }
        else if (CurrentState == cutState.foodOk)
        {
            displayThings.SetActive(false);
            finishedThings.SetActive(true);
        }
        else
        {
            finishedThings.SetActive(false);
            displayThings.SetActive(false);
            ProcesSlider.gameObject.SetActive(false);
        }

    }

    public void DoCut()
    {
        cutProcess += 26;
        ProcesSlider.value = Mathf.Clamp(cutProcess / 100, 0, 1.01f);
        if (cutProcess >= 100)
        {
            CurrentState=cutState.foodOk;
        }
    }

    public void Reset()
    {
        CurrentState=cutState.nofood;
        cutProcess = 0;
        ProcesSlider.value = 0;
    }

}
