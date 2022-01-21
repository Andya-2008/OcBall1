using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> Balls = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StartHandler script triggered");
        foreach (GameObject Ball in Balls)
        {
            Ball.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
