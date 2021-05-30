using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] LapsSystem lapsSystem;

    void Start()
    {
        lapsSystem = (LapsSystem)GameObject.FindObjectOfType(typeof(LapsSystem)); //będzie znaleziony pierwszy obiekt tego typu, zakładamy więc najlepiej, że mamy tylko jeden obiekt tego typu
        if(lapsSystem == null)
        {
            Debug.LogError("LapsSystem is null in script Checkpoint!!!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            lapsSystem.CheckPointCompleted(this);
        }
    }

}
