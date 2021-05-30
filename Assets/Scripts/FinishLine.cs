using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] TimeCounter timeCounter;
    [SerializeField] GameObject restartPanel;

    private void Start()
    {
        timeCounter = GameObject.Find("Canvas").GetComponentInChildren<TimeCounter>();
        restartPanel = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            timeCounter.StopCounter();
            restartPanel.SetActive(true);
            GameObject.Find("PlayerCar").GetComponent<PlayerCar>().enabled = false;
        }
    }

}
