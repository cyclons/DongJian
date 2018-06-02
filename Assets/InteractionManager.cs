using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour {
    public enum HoldType
    {
        empty,
        food,
        cutThings,
        goodPotThings,
        badPotThings
    }

    public HoldType CurrentHoldType=HoldType.empty;
    public Text logText;

    public Animator CutAnimator;
    //交互
    public void OnInteractButtonClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));//射线  
        //切菜交互
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,1))//发射射线(射线，射线碰撞信息，射线长度，射线会检测的层级)  
        {
            if (hit.collider.tag == "cut" &&
                GameManager.Instance.CurrentPlayerState == GameManager.PlayerState.notTake &&
                hit.collider.GetComponent<CutPlace>().CurrentState == CutPlace.cutState.hasfood)
            {
                hit.collider.SendMessage("DoCut");
                CutAnimator.SetTrigger("cut");
            }
        }
    }
    //拿取
    public GameObject FoodItem;
    public void OnTakeButtonClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));//射线  

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,1))//发射射线(射线，射线碰撞信息，射线长度，射线会检测的层级)  
        {
            //拿食物
            if (hit.collider.tag == "food" && GameManager.Instance.CurrentPlayerState == GameManager.PlayerState.notTake)
            {
                logText.text = "takeFood";
                GameManager.Instance.TakeObject(FoodItem);
                CurrentHoldType=HoldType.food;
            }
            //拿切好的食物
            if (hit.collider.tag == "cut" &&
                GameManager.Instance.CurrentPlayerState == GameManager.PlayerState.notTake &&
                hit.collider.GetComponent<CutPlace>().CurrentState == CutPlace.cutState.foodOk)
            {
                hit.collider.SendMessage("Reset");
                GameManager.Instance.TakeObject("cutItem");
                CurrentHoldType=HoldType.cutThings;
            }


            //todo 拿煮熟的食物
            if (hit.collider.tag == "pot" &&
                GameManager.Instance.CurrentPlayerState == GameManager.PlayerState.notTake &&
                hit.collider.GetComponent<PotPlace>().CurrentPotState == PotPlace.PotState.goodCook )
            {
                hit.collider.SendMessage("Reset");
                GameManager.Instance.TakeObject("GoodPotItem");
                CurrentHoldType = HoldType.goodPotThings;
            }

            //todo 拿煮糊的食物
            if (hit.collider.tag == "pot" &&
                GameManager.Instance.CurrentPlayerState == GameManager.PlayerState.notTake &&
                hit.collider.GetComponent<PotPlace>().CurrentPotState == PotPlace.PotState.badCook)
            {
                hit.collider.SendMessage("Reset");
                GameManager.Instance.TakeObject("BadPotItem");
                CurrentHoldType = HoldType.goodPotThings;
            }
        }
    }
    //放下
    public void OnPutButtonClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));//射线  
        
        RaycastHit hit;
        //从食物放到菜板
        if (Physics.Raycast(ray, out hit,1))//发射射线(射线，射线碰撞信息，射线长度，射线会检测的层级)  
        {
            if (hit.collider.tag == "cut" && 
                CurrentHoldType==HoldType.food&&
                GameManager.Instance.CurrentPlayerState == GameManager.PlayerState.take&&
                hit.collider.GetComponent<CutPlace>().CurrentState==CutPlace.cutState.nofood)
            {
                logText.text = "putFood";
                GameManager.Instance.PutObject();
                hit.collider.GetComponent<CutPlace>().CurrentState = CutPlace.cutState.hasfood;
                CurrentHoldType=HoldType.empty;
            }
            //todo 从菜板到锅子
            if (hit.collider.tag == "pot" &&
                CurrentHoldType == HoldType.cutThings &&
                GameManager.Instance.CurrentPlayerState == GameManager.PlayerState.take && 
                hit.collider.GetComponent<PotPlace>().CurrentPotState == PotPlace.PotState.empty)
            {
                GameManager.Instance.PutObject();
                hit.collider.GetComponent<PotPlace>().CurrentPotState = PotPlace.PotState.cooking;
                CurrentHoldType = HoldType.empty;
            }


            //todo 从锅子到盘子
            if (hit.collider.tag == "plate" &&
                CurrentHoldType == HoldType.goodPotThings &&
                GameManager.Instance.CurrentPlayerState == GameManager.PlayerState.take )
            {
                GameManager.Instance.PutObject();
                //todo 显示加分
                GameManager.Instance.AddScore();
                CurrentHoldType = HoldType.empty;
            }
            //todo 从任何到垃圾桶
            if (hit.collider.tag == "trash" &&
                GameManager.Instance.CurrentPlayerState == GameManager.PlayerState.take)
            {
                GameManager.Instance.PutObject();
                hit.collider.GetComponent<PotPlace>().CurrentPotState = PotPlace.PotState.cooking;
                CurrentHoldType = HoldType.empty;

            }

        }

    }
}
