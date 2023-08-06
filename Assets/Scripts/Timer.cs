using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    public TextMeshProUGUI timerText = null;
    private CutsceneBehaviour cB = null;
    private void Start()
    {
        // Starts the timer automatically
        cB = GetComponent<CutsceneBehaviour>();
        timerIsRunning = true;
    }
    private void FixedUpdate()
    {
        if (timerIsRunning && cB.GetInteractableState())
        {
            timerText.text = timeRemaining.ToString("N0");

            if (timeRemaining > 0.1f)
            {
                timeRemaining -= Time.deltaTime;
                //Debug.Log(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
}