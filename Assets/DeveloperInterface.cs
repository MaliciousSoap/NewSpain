using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperInterface : MonoBehaviour
{
    public GameObject buggedObject;

    // Start is called before the first frame update
    private void Start()
    {
        print("INIT");
        Application.targetFrameRate = 60;
        print("INITIALIZED FOR 60 FPS");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("TRANSFORM : " + buggedObject.transform.position);
        }
    }
}