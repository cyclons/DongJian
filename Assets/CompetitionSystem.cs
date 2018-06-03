using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompetitionSystem : MonoBehaviour
{
    public Text CountingTimeUi;
    public GameObject StartBtn;

    private float CountingTimer = 60;
    
    private bool isStart=false;

    private int bestScore = 0;
    public void OnStartCompetionBtnClick()
    {
        GameManager.Instance.Score = 0;
        isStart = true;
        
    }

	// Use this for initialization
	void Start ()
	{
	    CountingTimer = 60;
	}
	
	// Update is called once per frame
	void Update () {
	    if (isStart)
	    {
            StartBtn.SetActive(false);
	        CountingTimer -= Time.deltaTime;
	        CountingTimeUi.text = "TimeLeft:" + CountingTimer;
	    }
	    if (CountingTimer <= 0)
	    {
            StartBtn.SetActive(true);
	        isStart = false;
	        CountingTimer = 60;
	        if (GameManager.Instance.Score > bestScore)
	        {
	            bestScore = GameManager.Instance.Score;
            }
            CountingTimeUi.text = "BestScore:" + bestScore;
	    }

	}
}
