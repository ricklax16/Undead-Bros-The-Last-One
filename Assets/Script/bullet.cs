using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LateCall());
    }



    private void OnCollisionEnter2D(Collision2D other)
    {

       
    }




    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(4f);

        gameObject.SetActive(false);
       
    }
}
