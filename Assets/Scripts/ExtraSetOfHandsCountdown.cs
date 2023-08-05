using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraSetOfHandsCountdown : MonoBehaviour
{
    float startTime;
    // Start is called before the first frame update
    void OnEnable()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > 20)
        {
            this.GetComponent<PowerScript>().DoneWithPower();
        }
    }
}
