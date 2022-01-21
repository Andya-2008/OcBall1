using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class deathToBall : MonoBehaviour
{
    GameObject Shield;
    [SerializeField] bool HybridBallBool;
    [SerializeField] bool PowerBallBool;
    DeathPointCounter DeathWall;
    Transform SpawnpointZ;
    //TextMeshProUGUI dbgText;
    ScoreHandler shandler;
    bool isActive=true;
    
    // Start is called before the first frame update
    void Start()
    {
       // dbgText = GameObject.FindGameObjectWithTag("DebugText").GetComponent<TextMeshProUGUI>();
        Shield = GameObject.Find("Shield").GetComponent<GameObject>();
        DeathWall = GameObject.Find("DeathWall").GetComponent<DeathPointCounter>();
        SpawnpointZ = GameObject.Find("SpawnPointZ").GetComponent<Transform>();
        shandler = GameObject.Find("GameManager").GetComponent<ScoreHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            
            if (other.tag == "DeathWall")
            {
                if (!PowerBallBool)
                {
                    GameObject.Find("DeathWall").GetComponent<DeathPointCounter>().AddPoint();
                    GameObject.Find("GameManager").GetComponent<ScoreHandler>().streakNum = 0;
                }

                isActive = false;
                Destroy(this.gameObject);
                
            }
            else if (other.tag == "Ball")
            {
            }
            else if (other.tag == "Player")
            {

                if (!HybridBallBool)
                {
                    isActive = false;
                    GameObject.Find("GameManager").GetComponent<ScoreHandler>().addScore(200);
                    GameObject.Find("GameManager").GetComponent<ScoreHandler>().streakNum += 1;
                    Destroy(this.gameObject);
                    if(PowerBallBool)
                    {
                        GameObject.Find("PowerupHandler").GetComponent<AddPower>().AddThePower("Random");                    }

                }
            }
            else if (other.tag == "Shield")
            {
                if (HybridBallBool)
                {
                    isActive = false;
                    // DebugOnCanvas("hit shield1");
                    GameObject.Find("GameManager").GetComponent<ScoreHandler>().addScore(700);
                    // DebugOnCanvas("hit shield2");
                    GameObject.Find("GameManager").GetComponent<ScoreHandler>().streakNum += 1;
                    Destroy(this.gameObject);

                }

            }
            else
            {
                isActive = false;
                GameObject.Find("DeathWall").GetComponent<DeathPointCounter>().AddPoint();
                Destroy(this.gameObject);
                GameObject.Find("GameManager").GetComponent<ScoreHandler>().streakNum = 0;
            }


        }
    }

    //public void DebugOnCanvas(string Text)
   // {
   //     dbgText.text = Text.ToString();
   // }
}