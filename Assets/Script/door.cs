using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class door : MonoBehaviour {
    public static int points;
    public  Text tPoints;
   public Sprite open;
    public string level = "Level 2";

    // Use this for initialization
    void Start () {
        points = 0;
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(level);
        }
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
