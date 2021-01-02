using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperInterface : MonoBehaviour
{
    public float dragSpeed = 2;

    //public GameObject buggedObject;
    [Tooltip("[SPACE] tells camera size, [Y] tells y coord")]
    public GameObject HoverOverMe;

    public Camera m_cam;

    // Start is called before the first frame update
    private void Start()
    {
        print("INIT");
        Application.targetFrameRate = 60;
        print("INITIALIZED FOR 60 FPS");

        m_cam = Camera.main;
    }

    private int n = 0;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            n++;
            print("orthographic size: " + m_cam.orthographicSize + " at index " + n);
        }//If
        if (Input.GetKeyDown(KeyCode.Y))

        {
            print("Position Y: " + m_cam.transform.position.y);
        }//If
    }//Void
}//Classs