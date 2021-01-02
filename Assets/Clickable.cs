using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(PolygonCollider2D))]
[ExecuteInEditMode]
public class Clickable : MonoBehaviour
{
    //#001
    private Color initialColor;

    private Color modificationColor;

    //#002
    public float population = 10;

    private string formattedPopulation;

    private void Start()
    {
        GameObject.Find("PopulationText").GetComponent<TMP_Text>().text = "Population: " + "N/A";

        //Highlight #001
        initialColor = gameObject.GetComponent<SpriteRenderer>().color;
        modificationColor.r = 0.05f;
        modificationColor.g = 0.05f;
        modificationColor.b = 0.05f;
        modificationColor.a = 0;

        //Population word formatter; #002
        if (population > 1000) // 1k
        {
            formattedPopulation = (population / 1000).ToString() + "k";
        }
        else
        {
            formattedPopulation = population.ToString();
        }
        initialColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    private void OnMouseDown() //When game object clicked
    {
        //Colonization Mechanics #003
        if (gameObject.CompareTag("Colonizeable"))
            print("You've colonized " + gameObject.name);

        if (gameObject.CompareTag("Province"))
            print("Open Province Menu");
    }

    //On mouse enter -- Highlight
    private void OnMouseOver()
    {
        //#001

        if (gameObject.GetComponent<SpriteRenderer>().color != initialColor - modificationColor)  //To try and alleviate lag, I assume checking is less of a data load than unnecessarily repeatedly doing it
            gameObject.GetComponent<SpriteRenderer>().color = initialColor - modificationColor;

        //#002
        GameObject.Find("PopulationText").GetComponent<TMP_Text>().text = "Population: " + formattedPopulation;    //Find he who is named "PopulationText" and get the text component and make it equal to population.toString();
    }

    private void OnMouseExit()
    {
        //#001
        if (gameObject.GetComponent<SpriteRenderer>().color != initialColor)  //+ Color.white)
            gameObject.GetComponent<SpriteRenderer>().color = initialColor; //+ Color.white;
        //#002
        GameObject.Find("PopulationText").GetComponent<TMP_Text>().text = "Population: " + "N/A";
    }//void
}//class