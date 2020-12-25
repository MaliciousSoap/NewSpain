using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    private void OnMouseDown()
    {
        print("You've colonized " + gameObject.name);
    }
}