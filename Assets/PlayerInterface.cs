using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    private float sizeScale = 1;    //sizeScale Factor
    private GameObject currentGameObject;   //To clean up code

    private float positionY;
    private float positionX;

    private float mDelta; //Mouse Delta

    //Declare array to store game object positions                                                                                                            ////private float[] initialPositionX = new float[GameObject.FindGameObjectsWithTag("Country").Length];
    private List<float> initialPositionY = new List<float>();

    private List<float> initialPositionX = new List<float>();

    private void Start()
    {
        for (var i = 0; i < GameObject.FindGameObjectsWithTag("Country").Length; i++) //For the length of game object array, sizeScale each gameobject by mouse defined sizeScale
        {
            currentGameObject = GameObject.FindGameObjectsWithTag("Country")[i];
            initialPositionX.Add(currentGameObject.transform.position.x);
            initialPositionY.Add(currentGameObject.transform.position.y);
        }//for
    }//start

    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)  //To reduce lag, only check ro try for scaling when relevant
        {
            mDelta = Input.mouseScrollDelta.y;
            sizeScale += mDelta; // plus or minus change in mouse scroll

            if (sizeScale < 3) { sizeScale = 3; } //Caps sizeScale at 3
            if (sizeScale > 10) { sizeScale = 10; } //Caps sizeScale at 10

            //gameObject is the current game Object

            for (var i = 0; i < GameObject.FindGameObjectsWithTag("Country").Length; i++) //For the length of game object array, sizeScale each gameobject by mouse defined sizeScale
            {
                currentGameObject = GameObject.FindGameObjectsWithTag("Country")[i];
                currentGameObject.transform.localScale = new Vector2(sizeScale, sizeScale);

                positionX = currentGameObject.transform.position.x; //Get positions for further manipulation
                positionY = currentGameObject.transform.position.y; //Get positions for further manipulation

                currentGameObject.transform.localPosition = new Vector2(positionX * mDelta + initialPositionX[i], positionY * mDelta + initialPositionY[i]);        //Do the same with position
            }//For                                                                                                                                            //gameObject.transform.localsizeScale = new Vector2(sizeScale, sizeScale);
        }//If
    }//Void
}//Class