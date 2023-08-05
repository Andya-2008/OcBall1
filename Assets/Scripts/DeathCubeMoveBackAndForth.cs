using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCubeMoveBackAndForth : MonoBehaviour
{
    public float speed;
    bool changeDirectionbool;
    int changeDirectionInt = 1;
    float startTime;
    float timer;
    float SpeedC = .01f;
    float MaxCubeXSpeed = 1.8f;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer = Time.time - startTime;
        moveBackandForth();
    }
    public void moveBackandForth()
    {
        //speed = MaxCubeXSpeed * (1f - 1 / (Mathf.Exp(timer * SpeedC)));
        if (changeDirectionbool)
        {
            changeDirectionInt = -1;
        }
        else
        {
            changeDirectionInt = 1;
        }
        Vector3 thisTransform = this.transform.position;
        if(thisTransform.x > 1.8f)
        {
            changeDirectionbool = true;
        }
        else if(thisTransform.x < -1.8f)
        {
            changeDirectionbool = false;
        }
        if (speed < .1)
        {

            this.transform.position = new Vector3(thisTransform.x + .1f*changeDirectionInt, thisTransform.y, thisTransform.z);
        }
        else
        {
            this.transform.position = new Vector3(thisTransform.x + speed*changeDirectionInt, thisTransform.y, thisTransform.z);
        }
    }
}
