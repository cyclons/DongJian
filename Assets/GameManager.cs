using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

    
{
    public enum PlayerState
    {
        take,
        notTake
    }

    public enum PlayerTakeStyle
    {
        
    }

    public Transform CameraJoint;
    public PlayerState CurrentPlayerState=PlayerState.notTake;
    public static GameManager Instance;
    public GameObject TakeUi;
    public GameObject PutUi;
    public GameObject cutItem;

    public void TakeObject(GameObject takenObject)
    {
        Instantiate(takenObject, CameraJoint.position, CameraJoint.rotation).transform.SetParent(CameraJoint);
        CurrentPlayerState=PlayerState.take;
        TakeUi.SetActive(false);
        PutUi.SetActive(true);
    }

    public void TakeObject(string takenObjectName)
    {
        if (takenObjectName == "cutItem")
        {
            Instantiate(cutItem, CameraJoint.position, CameraJoint.rotation).transform.SetParent(CameraJoint);
            CurrentPlayerState = PlayerState.take;
            TakeUi.SetActive(false);
            PutUi.SetActive(true);
        }
    }
    public void PutObject()
    {
        for (int i = 0; i < CameraJoint.childCount; i++)
        {
            Destroy(CameraJoint.GetChild(i).gameObject);
        }
        CurrentPlayerState=PlayerState.notTake;
        TakeUi.SetActive(true);
        PutUi.SetActive(false);

    }

    void Awake()
    {
        Instance = this;
    }

}
