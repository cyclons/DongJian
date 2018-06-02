using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameManager : NetworkBehaviour
{
    public enum PlayerState
    {
        take,
        notTake
    }

    [SyncVar]
    public int Score = 0;
    [SyncVar]
	public int EnemyScore = 0;

    public Text ScoreUi;
    public Transform CameraJoint;
    public PlayerState CurrentPlayerState=PlayerState.notTake;
    public static GameManager Instance;
    public GameObject TakeUi;
    public GameObject PutUi;
    public GameObject cutItem;
    public GameObject GoodPotItem;
    public GameObject BadPotItem;

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
        if (takenObjectName == "GoodPotItem")
        {
            Instantiate(GoodPotItem, CameraJoint.position, CameraJoint.rotation).transform.SetParent(CameraJoint);
            CurrentPlayerState = PlayerState.take;
            TakeUi.SetActive(false);
            PutUi.SetActive(true);
        }
        if (takenObjectName == "BadPotItem")
        {
            Instantiate(GoodPotItem, CameraJoint.position, CameraJoint.rotation).transform.SetParent(CameraJoint);
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

    public void AddScore()
    {
        Score += 15;
        ScoreUi.text = "Score:" + Score;
    }

    public void ReduceScore()
    {
        Score -= 10;
        if (Score <= 0)
        {
            Score = 0;
        }
        ScoreUi.text = "Score:" + Score;

    }
    void Awake()
    {
        Instance = this;
    }

}
