using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class door : MonoBehaviour {
    public static int points;
    public  Text tPoints;
    // Use this for initialization
    void Start () {
        points = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
       tPoints.text = "Points: " + points.ToString();
    }
}
