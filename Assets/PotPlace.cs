using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotPlace : MonoBehaviour {

    public enum PotState
    {
        empty,
        cooking,
        goodCook,
        badCook
    }

    public GameObject cookingItem;
    public GameObject cookedItem;
    public GameObject overcookedItem;

    public PotState CurrentPotState;

    private float timer = 0;

    public float CookTime = 10;

    public float OverCookTime = 5;

    public Slider ProcessSlider;

    public Text Tip;
	// Use this for initialization
	void Start () {
		CurrentPotState=PotState.empty;
        ProcessSlider.gameObject.SetActive(false);
        Tip.gameObject.SetActive(false);
        cookingItem.SetActive(false);
        cookedItem.SetActive(false);
        overcookedItem.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if (CurrentPotState == PotState.empty)
	    {
	        ProcessSlider.gameObject.SetActive(false);
	        Tip.gameObject.SetActive(false);

        }
        if (CurrentPotState == PotState.cooking)
	    {

            ProcessSlider.gameObject.SetActive(true);
	        Tip.gameObject.SetActive(true);

            timer += Time.deltaTime;
	        ProcessSlider.value = Mathf.Clamp(timer / CookTime,0,1.01f);
	        Tip.text = "Cooking...";
            if (timer >= CookTime)
	        {
	            CurrentPotState=PotState.goodCook;
	            timer = 0;
	            cookingItem.SetActive(false);
	            cookedItem.SetActive(true);
	            overcookedItem.SetActive(false);
            }
	    }
	    if (CurrentPotState == PotState.goodCook)
	    {
	        Tip.text = "IT IS COOKED~~";
            timer += Time.deltaTime;
	        if (timer >= OverCookTime)
	        {
	            CurrentPotState = PotState.badCook;
	            timer = 0;
	            cookingItem.SetActive(false);
	            cookedItem.SetActive(false);
	            overcookedItem.SetActive(true);
            }
        }
	    if (CurrentPotState == PotState.badCook)
	    {
	        Tip.text = "OverCooked...";
	        Tip.color = Color.grey;
            ProcessSlider.gameObject.SetActive(false);

        }
    }

    public void Reset()
    {
        ProcessSlider.value = 0;
        timer = 0;
        Tip.color = Color.yellow;
        CurrentPotState=PotState.empty;
        cookingItem.SetActive(false);
        cookedItem.SetActive(false);
        overcookedItem.SetActive(false);
    }

    public void StartCooking()
    {
        CurrentPotState=PotState.cooking;
        cookingItem.SetActive(true);
        cookedItem.SetActive(false);
        overcookedItem.SetActive(false);
    }
}
