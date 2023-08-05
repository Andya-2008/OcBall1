using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOneBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        GameObject.Find("BulletHandler").GetComponent<BulletHandler>().AddBullet(3);
        this.GetComponent<PowerScript>().DoneWithPower();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
