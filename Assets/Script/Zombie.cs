using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
    public int speed=1;

    private Transform tar;
    public RaycastHit2D hit;
    // Use this for initialization
    void Start () {
        tar = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
         hit = Physics2D.Raycast(transform.position, Vector2.right, 5, 8);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            transform.position = Vector2.MoveTowards(transform.position, tar.position, speed * Time.deltaTime);

    }
    }
}
 