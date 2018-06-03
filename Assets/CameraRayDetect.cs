using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRayDetect : MonoBehaviour {

    private Ray cameraRay;
    public Image aimUi;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cameraRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if(Physics.Raycast(cameraRay,out hit,1)){
            if(hit.collider.tag!=null){
                aimUi.color = Color.green;
            }else{
                aimUi.color = Color.white;
            }
        }else{
            aimUi.color = Color.white;
        }

	}
}
