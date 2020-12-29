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

    private void OnMouseOver()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}