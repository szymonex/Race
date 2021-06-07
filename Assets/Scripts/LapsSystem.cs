using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapsSystem : MonoBehaviour
{
    [SerializeField] CheckPoint[] checkpoints;
    [SerializeField] int currentCheckpoint = 0;
    [SerializeField] int currentLap = 0;
    int laps = 3;

    [SerializeField] TimeCounter timeCounter;
    public TextMeshProUGUI lapTime;
    [SerializeField] GameObject restartPanel;

    // Start is called before the first frame update
    void Start()
    {
        timeCounter = GameObject.Find("Canvas").GetComponentInChildren<TimeCounter>();
        restartPanel = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void CheckPointCompleted(CheckPoint hittedCheckpoint)
    {
        if(hittedCheckpoint == checkpoints[currentCheckpoint])// && currentCheckpoint < checkpoints.Length)
        {
            if(currentCheckpoint == 0)
            {
                currentLap++;
                Debug.Log($"New Lap! >> {currentLap}");

                if(currentLap > laps)
                {
                    Debug.Log("GameOver!");
                    RaceCompleted();
                }

                else if (currentLap > 1)
                {
                    ShowLapTime();
                }
            }
            Debug.Log($"CheckPoint {currentCheckpoint}!");
            //currentCheckpoint++;
            checkPointRangeChecker();
        }
        //else if(currentCheckpoint == checkpoints.Length - 1)
        //{
        //    currentCheckpoint = 0;
        //}
    }

    public void checkPointRangeChecker()
    {
        if(currentCheckpoint < checkpoints.Length - 1)
        {
            currentCheckpoint++;
        }
        else if (currentCheckpoint == checkpoints.Length - 1)
        {
            currentCheckpoint = 0;
        }
    }

    private void ShowLapTime()
    {
        lapTime.enabled = true;
        lapTime.text = timeCounter.GetCurrentTimeAsString();
        Invoke("HideLapTime", 3f);
    }

    private void HideLapTime()
    {
        lapTime.enabled = false;
    }

    internal void ConfigureRace(int laps, CheckPoint[] checkpoints)
    {
        this.laps = laps;
        this.checkpoints = checkpoints;
        currentLap = 0;
        currentCheckpoint = 0;
        timeCounter.ResterCounter();
    }

    void RaceCompleted()
    {
        timeCounter.StopCounter();
        restartPanel.SetActive(true);
        PlayerCar playerCar = (PlayerCar)GameObject.FindObjectOfType(typeof(PlayerCar));
        playerCar.enabled = false;
    }
}
