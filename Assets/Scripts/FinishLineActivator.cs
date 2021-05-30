using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineActivator : MonoBehaviour
{
    [SerializeField] BoxCollider2D finishLineCollider; // jakby dać tym Collider2D to można wtedy dowolny collider do niego przypisać

    void Start()
    {
        finishLineCollider = GameObject.Find("FinishLine").GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Player")) // można dać też collision.name
        {
            finishLineCollider.enabled = true;
        }
    }
}
