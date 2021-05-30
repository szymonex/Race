using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    Rigidbody2D rBody2D;
    AudioSource audioSource;
    void Start()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log($"speed: {rBody2D.velocity.magnitude}");
        audioSource.pitch = Mathf.Clamp(rBody2D.velocity.magnitude, 1f, 3f); //funkcja obcinająca podaną wartość do zadanego zakresu
        
    }
}
