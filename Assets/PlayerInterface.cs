using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    private float sizeScale = 1;    //sizeScale Factor
    public float pan_speed = 2;

    private Camera currentCamera;
    private float mDelta; //Mouse Delta

    private void Start()
    {
        currentCamera = Camera.main;
    }//Void

    private void Update()
    {
        Vector3 cam_pos = currentCamera.transform.position;
        if (Input.mouseScrollDelta.y != 0)  //To reduce lag, only check ro try for scaling when relevant
        {
            mDelta = Input.mouseScrollDelta.y / 2;
            sizeScale += mDelta; // plus or minus change in mouse scroll

            // if (sizeScale < -initialCameraSize + 1) { sizeScale = -initialCameraSize + 1; } //Caps sizeScale at -4 due to cameraSize 0 returning an error
            // if (sizeScale > 0) { sizeScale = 0; } //Caps sizeScale at 0

            ///float M_orthographicSize = 5 - sizeScale;
            sizeScale = Mathf.Clamp(sizeScale, 0.0f, 4.5f);
            currentCamera.orthographicSize = 5 - sizeScale;
        }//If

        float ortho_size = currentCamera.orthographicSize;

        if (Input.GetKey(KeyCode.W))
        {
            cam_pos.y += Time.deltaTime * (ortho_size * pan_speed);   //WASD movement, orthographic size 1 is zoomed in, ortho size 5 is zoomed out so this accelerates when
        }
        if (Input.GetKey(KeyCode.A))
        {
            cam_pos.x -= Time.deltaTime * (ortho_size * pan_speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            cam_pos.y -= Time.deltaTime * (ortho_size * pan_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cam_pos.x += Time.deltaTime * (ortho_size * pan_speed);
        }
        cam_pos.y = Mathf.Clamp(cam_pos.y, -(5 - ortho_size), (5 - ortho_size));
        currentCamera.transform.position = cam_pos; //Modify the current camera's position by the cam_pos variable
    }//Void
}//Class

//Useful Code   // for (var i = 0; i < GameObject.FindGameObjectsWithTag("Country").Length; i++) //For the length of game object array, sizeScale each gameobject by mouse defined sizeScale
//Useful Code  //gameObject.transform.localsizeScale = new Vector2(sizeScale, sizeScale);