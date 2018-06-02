using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour {

    public Text logText;
    public void OnInteractButtonClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));//射线  

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))//发射射线(射线，射线碰撞信息，射线长度，射线会检测的层级)  
        {

            if (hit.collider.tag == "cut" &&
                GameManager.Instance.CurrentPlayerState == GameManager.PlayerState.notTake &&
                hit.collider.GetComponent<CutPlace>().CurrentState == CutPlace.cutState.hasfood)
            {
                hit.collider.SendMessage("DoCut");
            }
        }
    }

    public GameObject FoodItem;
    public void OnTakeButtonClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));//射线  

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))//发射射线(射线，射线碰撞信息，射线长度，射线会检测的层级)  
        {
            if (hit.collider.tag == "food" && GameManager.Instance.CurrentPlayerState == GameManager.PlayerState.notTake)
            {
                logText.text = "takeFood";
                GameManager.Instance.TakeObject(FoodItem);
            }
            if (hit.collider.tag == "cut" &&
                GameManager.Instance.CurrentPlayerState == GameManager.PlayerState.notTake &&
                hit.collider.GetComponent<CutPlace>().CurrentState == CutPlace.cutState.foodOk)
            {
                hit.collider.SendMessage("Reset");
                GameManager.Instance.TakeObject("cutItem");
            }
        }
    }
    public void OnPutButtonClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));//射线  
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))//发射射线(射线，射线碰撞信息，射线长度，射线会检测的层级)  
        {
            if (hit.collider.tag == "cut" && GameManager.Instance.CurrentPlayerState == GameManager.PlayerState.take&&hit.collider.GetComponent<CutPlace>().CurrentState==CutPlace.cutState.nofood)
            {
                logText.text = "putFood";
                GameManager.Instance.PutObject();
                hit.collider.GetComponent<CutPlace>().CurrentState = CutPlace.cutState.hasfood;
            } 
        }
    }
}
