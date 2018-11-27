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

        if (other.gameObject.CompareTag("Enemy"))
        {

            other.gameObject.SetActive(false);



        }
    }




    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(4f);

        gameObject.SetActive(false);
       
    }
}
