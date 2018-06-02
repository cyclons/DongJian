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

    [SyncVar(hook="ScoreChanged")]
    public int Score;
	[SyncVar(hook = "ClientScoreChanged")]
	public int ClientScore;

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
		if (!isClient) {
			Score += 15;
            ScoreUi.text = "Score:" + Score;
		} else {
			ClientScore += 15;
			ScoreUi.text = "Score:" + ClientScore;
		}
    }

    public void ReduceScore()
    {
		if (!isClient)
		{
			Score -= 10;
            if (Score <= 0)
            {
                Score = 0;
            }
            ScoreUi.text = "Score:" + Score;         
		}
		else
		{
			ClientScore -= 10;
			if (ClientScore <= 0)
            {
				ClientScore = 0;
            }
			ScoreUi.text = "Score:" + ClientScore;	
		}
    }

	void ScoreChanged(int value) {
		Score = value;
		ScoreUi.text = "Score:" + Score;
	}

	void ClientScoreChanged(int value)
    {
        ClientScore = value;
		ScoreUi.text = "Score:" + ClientScore;
    }

    void Awake()
    {
        Instance = this;
    }

}
