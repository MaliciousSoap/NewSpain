using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    private float sizeScale = 1;    //sizeScale Factor
    public float pan_speed = 2;
    public float orthoMax = 11;

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
            mDelta = Input.mouseScrollDelta.y / 5;
            sizeScale += mDelta; // plus or minus change in mouse scroll

            ///float M_orthographicSize = 5 - sizeScale;

            sizeScale = Mathf.Clamp(sizeScale, 0.0f, orthoMax - 0.1f);    //To try and prevent fustrum errors
            currentCamera.orthographicSize = orthoMax - sizeScale;
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
        cam_pos.y = Mathf.Clamp(cam_pos.y, -(orthoMax - ortho_size), (orthoMax - ortho_size)); //The sum of the intercept and the half height of the viewport (as measured from the center) must not be greater or lower than the bounding box
        currentCamera.transform.position = cam_pos; //Modify the current camera's position by the cam_pos variable
    }//Void
}//Class

//Useful Code   // for (var i = 0; i < GameObject.FindGameObjectsWithTag("Country").Length; i++) //For the length of game object array, sizeScale each gameobject by mouse defined sizeScale
//Useful Code  //gameObject.transform.localsizeScale = new Vector2(sizeScale, sizeScale);