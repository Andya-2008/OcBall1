using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerHandler : MonoBehaviour
{
    TextMeshProUGUI timerText;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        float timer = Time.time - startTime;
        timerText.text ="Timer: " + Mathf.Round(timer).ToString();
    }
}
