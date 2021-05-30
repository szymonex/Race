using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public TextMeshProUGUI UICounter;
    bool isCounterActive = false;
    string lastTime;
    float raceStartTime;

    // Start is called before the first frame update
    void Start()
    {
        UICounter = gameObject.GetComponent<TextMeshProUGUI>();
        //StartCounter();
    }

    // Update is called once per frame
    void Update()
    {
        float timer = Time.time - raceStartTime;
        int minutes = Mathf.FloorToInt(timer / 60); //funkcja Floor pokazuje tylko to co jest przed przecinkiem
        //UICounter.text = minutes.ToString();
        int seconds = (int)timer%60;


        if (isCounterActive)
        {
            UICounter.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            lastTime = UICounter.text;
        }
        else
        {
            UICounter.text = lastTime;
        }
    }

    public void StopCounter()
    {
        isCounterActive = false;
    }

    public void StartCounter()
    {
        isCounterActive = true;
    }

    public void ResterCounter()
    {
        raceStartTime = Time.time;
        isCounterActive = true;
    }

    public string GetCurrentTimeAsString()
    {
        return lastTime;
    }
}
