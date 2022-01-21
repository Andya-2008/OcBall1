using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> Balls = new List<GameObject>();
    [SerializeField] TimerHandler GameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("DeathOverHandler script triggered");
        foreach (GameObject Ball in Balls)
        {
            Ball.SetActive(false);
        }
        GameManager.GetComponent<TimerHandler>().enabled = false;
        GameManager.GetComponent<BallSpawner>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
