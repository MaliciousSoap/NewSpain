using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    private float sizeScale = 1;    //sizeScale Factor

    private Camera currentCanera;
    private float mDelta; //Mouse Delta

    private void Start()
    {
        currentCanera = Camera.main;
    }//Void

    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)  //To reduce lag, only check ro try for scaling when relevant
        {
            mDelta = Input.mouseScrollDelta.y;
            sizeScale -= mDelta; // plus or minus change in mouse scroll

            if (sizeScale < -4) { sizeScale = -4; } //Caps sizeScale at -4 due to cameraSize 0 returning an error
            if (sizeScale > 0) { sizeScale = 0; } //Caps sizeScale at 0

            currentCanera.orthographicSize = 5 + sizeScale;
        }//If
    }//Void
}//Class

//Useful Code   // for (var i = 0; i < GameObject.FindGameObjectsWithTag("Country").Length; i++) //For the length of game object array, sizeScale each gameobject by mouse defined sizeScale
//Useful Code  //gameObject.transform.localsizeScale = new Vector2(sizeScale, sizeScale);