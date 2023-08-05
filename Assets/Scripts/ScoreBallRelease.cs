using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBallRelease : MonoBehaviour
{
    float startTime;
    float origSpawnTime;
    public GameObject BallObj;
    private void OnEnable()
    {
        startTime = Time.time;
    }

    private void FixedUpdate()
    {
        if(Time.time-startTime < 2)
        {
            if (GameObject.Find("GameManager").GetComponent<BallSpawner>().SpawnInterval != 0)
            {
                BallObj.GetComponent<deathToBall>().NoDeathPoint = true;
                BallObj.GetComponent<deathToBall>().score = 50;
                origSpawnTime = GameObject.Find("GameManager").GetComponent<BallSpawner>().SpawnInterval;
                GameObject.Find("GameManager").GetComponent<BallSpawner>().SpawnInterval = 0;
            }
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<BallSpawner>().SpawnInterval = origSpawnTime;
            BallObj.GetComponent<deathToBall>().score = 200;
            BallObj.GetComponent<deathToBall>().NoDeathPoint = false;
            this.GetComponent<PowerScript>().DoneWithPower();
        }
    }

}
