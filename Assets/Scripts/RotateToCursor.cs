using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour {
   
    
    Camera Cam;


    // Use this for initialization
    void Start () {
        
        Cam = Camera.main;
		
	}
	
	// Update is called once per frame
	void Update () {
        RotateToCamera();
		
	}

    void RotateToCamera()
    {
        //mousePos = Cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - Cam.transform.position.z));
        //rb.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePos.y - transform.position.y), (mousePos.x - transform.position.x) * Mathf.Rad2Deg));

        Vector3 mousePos = Input.mousePosition;
        mousePos = Cam.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x,mousePos.y - transform.position.y);
        transform.up = -direction;


    } 
}
