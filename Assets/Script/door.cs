using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class door : MonoBehaviour {
    public static int points;
    public  Text tPoints;
   public Sprite open;
 

    // Use this for initialization
    void Start () {
        points = 0;
       
    }
	
	// Update is called once per frame
	void Update () {
        
       tPoints.text = "Points: " + points.ToString();

        if (points == 6)
        {
            this.GetComponent<SpriteRenderer>().sprite = open;
        }
    }
}
