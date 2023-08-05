using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject HybridBall;
    [SerializeField] GameObject Ball;
    [SerializeField] GameObject deathCube;
    [SerializeField] GameObject PowerBall;

    Transform BallParent;

    [SerializeField] public float SpawnInterval=10;
    float lastBallCreatedTime = 0;
    float MaxBallSpeed = 2f;


    [SerializeField] float HybridSpawnInterval;
    [SerializeField] float PowerBallSpawnInterval;
    float lastHybridBallCreatedTime = 0;
    float lastPowerBallCreatedTime = 0;
    [SerializeField] float minInterval= .1f;
    float startInterval = 3f;
    float startTime;
    [SerializeField] float IntervalC = .2f;
    [SerializeField] float SpeedC = .01f;
    Transform SpawnPointZ;
    float speed;
    TextMeshProUGUI SpeedText;
    DeathBallMoveThroughAir deathBallMoveThroughAir;
    DeathBallMoveThroughAir deathCubeMoveThroughAir;
    [SerializeField] int TimerCheck;
    public bool highpointbool = false;
    public bool deathCubeBool =false;
    public float maxHeight = 3.4f;//Medium by default, although this should never happen
    GameObject instantiateBall;
    [SerializeField] ScoreBallRelease scoreBallRelease;
    [SerializeField] float cubeSpeed;
    bool AlreadyResetTimer = false;
    bool AlreadyactiveSelf=false;
    // Start is called before the first frame update
    void Start()
    {
        deathBallMoveThroughAir = Ball.GetComponent<DeathBallMoveThroughAir>();
        deathCubeMoveThroughAir = deathCube.GetComponent<DeathBallMoveThroughAir>();
        
        SpawnPointZ = GameObject.Find("SpawnPointZ").GetComponent<Transform>();
        BallParent = GameObject.Find("Balls").GetComponent<Transform>();
        SpeedText = GameObject.Find("SpeedText").GetComponent<TextMeshProUGUI>();
        switch(PlayerPrefs.GetInt("Height"))
        {
            case 1:
                maxHeight = 3.2f;
                break;
            case 2:
                maxHeight = 3.4f;
                break;
            case 3:
                maxHeight = 3.6f;
                break;
            default:
                maxHeight = 3.4f;
                break;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.gameObject.activeSelf && !AlreadyactiveSelf)
        {
            startTime = Time.time;
            AlreadyactiveSelf = true;
        }
        if (!highpointbool)
        {
            SpawnPointZ.position = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(1, maxHeight), SpawnPointZ.position.z);
        }
        else
        {
            float highpointcoinflip = Random.Range(1, 3);
            if(highpointcoinflip < 1.5)
            {
                SpawnPointZ.position = new Vector3(Random.Range(-1.5f, -.8f), Random.Range(1, maxHeight), SpawnPointZ.position.z);
            }
            else if(highpointcoinflip>=1.5)
            {
                SpawnPointZ.position = new Vector3(Random.Range(.8f, 1.5f), Random.Range(1, maxHeight), SpawnPointZ.position.z);
            }
        }

        float timer = Time.time - startTime;
        if (timer > TimerCheck)
        {
            
            if (!deathCubeBool)
            {
                //Regular ball by default
                instantiateBall = Ball;
            }
            else
            {
                //Regular ball by default
                instantiateBall = deathCube;
                if (!AlreadyResetTimer)
                {
                    startTime=Time.time;
                    AlreadyResetTimer=true;
                }
                    deathCube.GetComponent<DeathCubeMoveBackAndForth>().speed = MaxBallSpeed * (1f - 1 / (Mathf.Exp(timer * cubeSpeed)));
            }

            scoreBallRelease.GetComponent<ScoreBallRelease>().BallObj = instantiateBall;
            if (Time.time - lastBallCreatedTime >= SpawnInterval)
            {
                
                SpawnInterval = minInterval + (startInterval - minInterval) / (Mathf.Exp((timer) * IntervalC));
                lastBallCreatedTime = Time.time;
                GameObject newBall = Instantiate(instantiateBall, SpawnPointZ.position, Quaternion.identity);
                newBall.transform.SetParent(BallParent);
                speed = MaxBallSpeed * (1f - 1 / (Mathf.Exp(timer * SpeedC)));
                SpeedText.text = "Speed: " + Mathf.Round(speed * 20).ToString();
                newBall.GetComponent<DeathBallMoveThroughAir>().speed = speed;
                
            }
            else if (Time.time - lastPowerBallCreatedTime >= PowerBallSpawnInterval)
            {
                Debug.Log("Powerball instantiated!");
                lastPowerBallCreatedTime = Time.time;
                GameObject newPowerBall = Instantiate(PowerBall, SpawnPointZ.position, Quaternion.identity);
                newPowerBall.transform.SetParent(BallParent);


            }
                else if (Time.time - lastHybridBallCreatedTime >= HybridSpawnInterval)
                {
                    lastHybridBallCreatedTime = Time.time;
                    GameObject newHybridBall = Instantiate(HybridBall, SpawnPointZ.position, Quaternion.identity);
                    newHybridBall.transform.SetParent(BallParent);


                }
            
        }
        deathBallMoveThroughAir.speed = speed;

    }
}
