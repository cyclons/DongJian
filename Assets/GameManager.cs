using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum PlayerState
    {
        take, // 拿了东西
        notTake // 空
    }
    
    public int Score;

    public Text ScoreUi;
    public Text ClientScoreUi;
    public Transform CameraJoint;
    public PlayerState CurrentPlayerState = PlayerState.notTake;
    public static GameManager Instance;
    public GameObject TakeUi;
    public GameObject PutUi;
    public GameObject cutItem;
    public GameObject GoodPotItem;
    public GameObject BadPotItem;
    public AudioSource AddScoreSound;

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
            Instantiate(BadPotItem, CameraJoint.position, CameraJoint.rotation).transform.SetParent(CameraJoint);
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
		//if (!isClient) {
			Score += 15;
            ScoreUi.text = "PLAYER1 SCORE:" + Score;
        AddScoreSound.Play();
		//} else {
			//ClientScore += 15;
		    //ClientScoreUi.text = "Player2Score:" + ClientScore;
		//}
    }

    public void ReduceScore()
    {
		//if (!isClient)
		//{
			Score -= 10;
            if (Score <= 0)
            {
                Score = 0;
            }
            ScoreUi.text = "PLAYER1 SCORE:" + Score;         
		//}
		//else
		//{
		//	ClientScore -= 10;
		//	if (ClientScore <= 0)
  //          {
		//		ClientScore = 0;
  //          }
		//    ClientScoreUi.text = "Player2Score:" + ClientScore;	
		//}
    }

	void ScoreChanged(int value) {
		Score = value;
		ScoreUi.text = "PLAYER1 SCORE:" + Score;
	}


    void Awake()
    {
        Instance = this;
    }

}
