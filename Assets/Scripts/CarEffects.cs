using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEffects : MonoBehaviour
{
    public float tiresEffectAngle = 20f;
    private Rigidbody2D rBody2D;
    public ParticleSystem myParticleSystem;

    void Start()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        if (myParticleSystem == null) Debug.LogError("myParticleSystem is null in script CarEffects!!!");
        myParticleSystem.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Vector2.Angle(transform.up, rBody2D.velocity);
        if(angle > tiresEffectAngle && myParticleSystem.isPaused)
        {
            //Debug.LogWarning($"kąt pomiędzy wektorami to: {angle}");
            myParticleSystem.Play();
        }
        else
        {
            myParticleSystem.Pause();
        }
    }
}
