using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeathBallMoveThroughAir : MonoBehaviour
{
   
    public float speed = 2;

    TextMeshProUGUI DebugText;
    [SerializeField] bool ConstantSpeedBool;
    //TextMeshProUGUI dbgText;

    // Start is called before the first frame update
    public void Start()
    {
        //dbgText = GameObject.FindGameObjectWithTag("DebugText").GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 thisTransform = this.transform.position;
        if (speed < .1)
        {

            this.transform.position = new Vector3(thisTransform.x, thisTransform.y, thisTransform.z - .1f);
        }
        else
        {
            this.transform.position = new Vector3(thisTransform.x, thisTransform.y, thisTransform.z - speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if (!hybridBool)
        {
            float timer = Time.time - startTime;
            speed = maxSpeed * (1f - 1 / (Mathf.Exp(timer * c)));
            speedText.text = "Speed: " + Mathf.Round(speed).ToString();
        }
        else
        {
            speed = maxSpeed;
        }
        */
    }
    /*private void Debug(string dbugText)
    {
        DebugText.text = dbugText;
    }*/
    
}
