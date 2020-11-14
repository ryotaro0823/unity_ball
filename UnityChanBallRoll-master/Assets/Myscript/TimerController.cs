using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public GoalChecker goalchecker;
    public Text Timer;
    public float totalTime;
    int seconds;
    public AudioSource gameBgm;
    public AudioSource timeoutBgm;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        totalTime = totalTime - Time.deltaTime;
        seconds = (int)totalTime;
        Timer.text = seconds.ToString();
        if(seconds <= 0)
        {
            gameBgm.Stop();
            timeoutBgm.Play();
            goalchecker.Resultfunc();
            enabled = false;
        }

    }
}
