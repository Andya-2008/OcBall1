using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //THIS SCRIPT IS FOR the ADDPOWER script. This is on every single powerup gameobject.


    public void DoneWithPower()
    {
        this.gameObject.SetActive(false);
    }
}
