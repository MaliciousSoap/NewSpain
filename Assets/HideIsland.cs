using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIsland : MonoBehaviour
{
    private GameObject[] IslandIcons;

    // Start is called before the first frame update
    private void Start()
    {
        IslandIcons = GameObject.FindGameObjectsWithTag("IslandIcon");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {  // Reduce lag {
            if (Camera.main.orthographicSize <= 1.9)
            {
                foreach (GameObject IslandIcon in IslandIcons)
                {
                    print("c001");
                    IslandIcon.SetActive(false);
                }
            }
            else// if (Camera.main.orthographicSize > 1)
            {
                foreach (GameObject IslandIcon in IslandIcons)
                {
                    print("c002");
                    IslandIcon.SetActive(true);
                }
            }
        }//if
    }//Void
}//Class