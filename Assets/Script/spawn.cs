using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {
   public GameObject Zombie1;
    public GameObject Zombie2;
    public GameObject Zombie3;
   public  GameObject Zombie4;
    // Use this for initialization
    void Start () {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Zombie1.gameObject.SetActive(true);
            Zombie2.gameObject.SetActive(true);
            Zombie3.gameObject.SetActive(true);
            Zombie4.gameObject.SetActive(true);
        }
        
    }

}
