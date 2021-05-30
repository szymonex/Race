using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Wjechalem w plame oleju!");
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerCar>().ForceFactor *= 0.5f;
        }
        if (collision.tag == "Car")
        {
            collision.GetComponent<AICar>().speedFactor *= 0.5f;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerCar>().ForceFactor *= 2f;
        }
        if(collision.tag == "Car")
        {
            collision.GetComponent<AICar>().speedFactor *= 2f;
        }
    }
}
